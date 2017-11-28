namespace IBM.Books.Catalog.API.Services
{
    using IBM.Books.Catalog.API.BusinessModel;
    using IBM.Books.Catalog.API.Data.Repositories;
    using IBM.Books.Catalog.API.Infrastructure.Enumerations;
    using IBM.Books.Catalog.API.Infrastructure.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public sealed class BookItemService : IBookItemService
    {
        private readonly IBookItemRepository bookItemRepository;
        private readonly IBookReferenceService bookReferenceService;
        private readonly IAuthorService authorService;
        private readonly IPublisherService publisherService;

        public BookItemService(IBookItemRepository bookItemRepository,
            IBookReferenceService bookReferenceService,
            IAuthorService authorService,
            IPublisherService publisherService)
        {
            this.bookItemRepository = bookItemRepository;
            this.bookReferenceService = bookReferenceService;
            this.authorService = authorService;
            this.publisherService = publisherService;
        }

        public async Task<int> CountByReferenceAsync(int referenceId) =>
             await bookItemRepository.CountByReferenceAsync(referenceId);

        public async Task<IList<BookItemModel>> ListByReferenceAsync(int referenceId, int pageIndex, int pageSize) =>
             await bookItemRepository.ListByReferenceAsync(referenceId, pageIndex, pageSize);

        public async Task<int?> CreateAsync(int referenceId, int ownerId, string ownerRemarks)
        {
            if (referenceId <= 0)
                throw new ArgumentOutOfRangeException(nameof(referenceId));

            if (!await bookReferenceService.IsIdExistAsync(referenceId))
                throw new Exception("The book reference doesn't exist");

            if (ownerId <= 0)
                throw new ArgumentOutOfRangeException(nameof(ownerId));

            return await bookItemRepository.CreateAsync(referenceId, ownerId, ownerRemarks);
        }

        public async Task<int?> CreateAsync(int ownerId, string ownerRemarks, string isbn, string lang, string title, string publisher, string author)
        {
            if (ownerId <= 0)
                throw new ArgumentOutOfRangeException(nameof(ownerId));

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title));

            if (string.IsNullOrWhiteSpace(lang))
                throw new ArgumentNullException(nameof(lang));

            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentNullException(nameof(author));

            if (string.IsNullOrWhiteSpace(publisher))
                throw new ArgumentNullException(nameof(publisher));

            if (!long.TryParse(isbn, out long _isbn))
                throw new ArgumentOutOfRangeException(nameof(isbn));

            if (_isbn <= 0)
                throw new ArgumentOutOfRangeException(nameof(isbn));

            int? referenceId = null;

            if (await bookReferenceService.IsIsbnExistAsync(_isbn))
                await bookReferenceService.GetByISBNAsync(_isbn);
            else
            {
                IList<int> authorIds = await this.authorService.ParseIdsAsync(author);
                if (authorIds == null || authorIds.Count == 0)
                    throw new Exception("Unable to retreive the author");

                int? publisherId = await this.publisherService.GetIdAsync(NormalizationHelper.NormalizePublisherName(publisher));
                if (!publisherId.HasValue || publisherId.Value <= 0)
                    throw new Exception("Unable to retreive the publisher");

                BookReferenceModel bookReference = new BookReferenceModel
                {
                    AuthorIds = authorIds,
                    Description = null,
                    InsertedDate = DateTime.Now,
                    ISBN = _isbn,
                    Language = lang,
                    Title = title,
                    NormalizedTitle = NormalizationHelper.NormalizeBookTitle(title),
                    Source = BookReferenceSources.Manual,
                    LastUpdatedDate = DateTime.Now,
                    PublisherId = publisherId.Value
                };

                referenceId = await bookReferenceService.CreateAsync(bookReference);
            }

            if (!referenceId.HasValue || referenceId.Value <= 0)
                throw new Exception("Unable to retreive the reference of the book");

            return await bookItemRepository.CreateAsync(referenceId.Value, ownerId, ownerRemarks);
        }

        public async Task<BookItemModel> GetAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            return await this.bookItemRepository.GetAsync(id);
        }

        public async Task<bool> UpdateAvailabilityAsync(int id, bool availability)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            return await this.bookItemRepository.UpdateAvailabilityAsync(id, availability);
        }

        public async Task<IList<BookItemModel>> ListByOwnerIdAsync(int ownerId, int pageIndex, int pageSize)
        {
            if (ownerId <= 0)
                throw new ArgumentNullException(nameof(ownerId));

            return await this.bookItemRepository.ListByOwnerIdAsync(ownerId, pageIndex, pageSize);
        }
    }
}