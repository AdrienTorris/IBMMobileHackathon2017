namespace IBM.Books.Catalog.API.Services
{
    using IBM.Books.Catalog.API.BusinessModel;
    using IBM.Books.Catalog.API.Data.Repositories;
    using IBM.Books.Catalog.API.Infrastructure.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public sealed class BookReferenceService : IBookReferenceService
    {
        private readonly IBookReferenceRepository bookReferenceRepository;
        private readonly IBookExternalService bookExternalService;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _publisherService;

        public BookReferenceService(IBookReferenceRepository bookReferenceRepository,
            IBookExternalService bookExternalService,
            IAuthorService authorService,
            IPublisherService publisherService)
        {
            this.bookReferenceRepository = bookReferenceRepository;
            this.bookExternalService = bookExternalService;
            this._authorService = authorService;
            this._publisherService = publisherService;
        }

        public async Task<BookReferenceModel> GetByISBNAsync(long isbn)
        {
            if (isbn <= 0)
                throw new ArgumentOutOfRangeException(nameof(isbn));

            BookReferenceModel ret = await this.bookReferenceRepository.GetByISBNAsync(isbn);
            if (ret != null)
                return ret;

            try
            {
                ret = await bookExternalService.GetBookReferenceDetailsAsync(isbn.ToString());
                if (ret == null)
                    return null;

                if (ret.AuthorIds == null || ret.AuthorIds.Count == 0)
                {
                    if (ret.AuthorNames == null || ret.AuthorNames.Count == 0)
                        return null;

                    IList<int> authorIds = new List<int>();
                    foreach (string s in ret.AuthorNames)
                    {
                        if (!string.IsNullOrWhiteSpace(s))
                        {
                            string[] _arr = s.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                            int i = await this._authorService.GetIdByNormalizedNamesAsync(NormalizationHelper.NormalizeAuthorName(_arr[1]), NormalizationHelper.NormalizeAuthorName(_arr[0]));
                            if (i > 0)
                                authorIds.Add(i);
                            else
                            {
                                i = await this._authorService.CreateAsync(new AuthorModel
                                {
                                    FirstName = _arr[1],
                                    LastName = _arr[0],
                                });
                                if (i > 0)
                                    authorIds.Add(i);
                            }
                        }
                    }
                    ret.AuthorIds = authorIds;
                    authorIds = null;
                }

                if (ret.PublisherId <= 0)
                {
                    if (string.IsNullOrWhiteSpace(ret.PublisherName))
                        return null;

                    int? _i = await this._publisherService.GetIdAsync(NormalizationHelper.NormalizePublisherName(ret.PublisherName));
                    if (_i.HasValue && _i.Value > 0)
                        ret.PublisherId = _i.Value;
                    else
                    {
                        _i = await this._publisherService.CreateAsync(new PublisherModel(ret.PublisherName));
                        if (_i.HasValue && _i.Value > 0)
                            ret.PublisherId = _i.Value;
                    }
                }

                int? retId = await this.bookReferenceRepository.CreateAsync(ret);
                if (retId.HasValue && retId.Value > 0)
                    ret = await this.bookReferenceRepository.GetByIdAsync(retId.Value);
                return ret;
            }
            catch (Exception ex)
            {
                return ret;
            }
            finally
            {

            }
        }

        public async Task<bool> IsIsbnExistAsync(long isbn)
        {
            if (isbn <= 0)
                throw new ArgumentOutOfRangeException(nameof(isbn));

            return await this.bookReferenceRepository.IsIsbnExistAsync(isbn);
        }

        public async Task<bool> IsIdExistAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            return await this.bookReferenceRepository.IsIdExistAsync(id);
        }

        public async Task<int> CountAsync(string searchQuery) =>
            await this.bookReferenceRepository.CountAsync(searchQuery);

        public async Task<IList<BookReferenceModel>> ListAsync(int pageIndex, int pageSize, string searchQuery) =>
            await this.bookReferenceRepository.ListAsync(pageIndex, pageSize, searchQuery);

        public async Task<int?> CreateAsync(BookReferenceModel bookReference) =>
            await this.bookReferenceRepository.CreateAsync(bookReference);

        public async Task<BookReferenceModel> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            return await this.bookReferenceRepository.GetByIdAsync(id);
        }
    }
}