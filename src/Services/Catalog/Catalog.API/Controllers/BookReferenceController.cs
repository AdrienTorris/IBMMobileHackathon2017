namespace IBM.Books.Catalog.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using IBM.Books.Catalog.API.Infrastructure;
    using IBM.Books.Catalog.API.Infrastructure.Configuration;
    using Microsoft.Extensions.Options;
    using Microsoft.EntityFrameworkCore;
    using IBM.Books.Catalog.API.DomainModel;
    using IBM.Books.Catalog.API.ViewModels;
    using IBM.Books.Catalog.API.Infrastructure.Helpers;
    using IBM.Books.Catalog.API.Infrastructure.ViewModelBuilders;
    using IBM.Books.Catalog.API.Services;
    using IBM.Books.Catalog.API.Infrastructure.Enumerations;
    using IBM.Books.Catalog.API.BusinessModel;

    [Route("api/v1/[controller]")]
    public class BookReferenceController : Controller
    {
        private readonly CatalogContext _catalogContext;
        private readonly CatalogSettings _settings;
        private readonly IAuthorService authorService;
        private readonly IBookReferenceService bookReferenceService;
        private readonly IBookItemService _bookItemService;

        public BookReferenceController(CatalogContext context,
            IOptionsSnapshot<CatalogSettings> settings,
            IAuthorService authorService,
            IBookReferenceService bookReferenceService,
            IBookItemService bookItemService)
        {
            _catalogContext = context ?? throw new ArgumentNullException(nameof(context));
            _settings = settings.Value;
            this.authorService = authorService;
            this.bookReferenceService = bookReferenceService;
            this._bookItemService = bookItemService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> List([FromQuery]int pageIndex = 0, [FromQuery]int pageSize = 15, [FromQuery]string searchQuery = null)
        {
            var totalItems = await bookReferenceService.CountAsync(searchQuery);

            var itemsOnPage = await bookReferenceService.ListAsync(pageIndex, pageSize, searchQuery);

            IList<BookReferenceViewModel> bookReferences = BookReferenceViewModelBuilder.BuildBookReferences(itemsOnPage, _settings.BasePictureUrl, _settings.ImageUnavailableImageFileName);

            var model = new PaginatedItemsViewModel<BookReferenceViewModel>(pageIndex, pageSize, totalItems, bookReferences);

            return Ok(model);
        }

        [HttpGet("{isbn}")]
        public async Task<IActionResult> GetByISBN([FromRoute]string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentNullException(nameof(isbn));

            if (!long.TryParse(isbn, out long _isbn))
                throw new ArgumentOutOfRangeException(nameof(isbn));

            BookReferenceModel bookReference = await bookReferenceService.GetByISBNAsync(_isbn);

            if (bookReference == null || bookReference.Id <= 0)
                return NoContent();

            return Ok(BookReferenceViewModelBuilder.BuildBookReference(bookReference, _settings.BasePictureUrl, _settings.ImageUnavailableImageFileName));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> GetWithItems([FromQuery]int id, [FromQuery]int pageIndex = 0, [FromQuery]int pageSize = 30)
        {
            APIContentResponseViewModel model;
            BookReferenceModel bookReference;
            BookReferenceViewModel bookReferenceViewModel;

            try
            {
                model = new APIContentResponseViewModel();

                // Get reference

                bookReference = await bookReferenceService.GetByIdAsync(id);
                bookReferenceViewModel = BookReferenceViewModelBuilder.BuildBookReference(bookReference, _settings.BasePictureUrl, _settings.ImageUnavailableImageFileName);
                model.AddSection(new APIResponseSectionViewModel(APIResponseContentSections.BookReferenceDetails, bookReferenceViewModel));

                // Get items

                var totalItems = await this._bookItemService.CountByReferenceAsync(id);
                var itemsOnPage = await this._bookItemService.ListByReferenceAsync(id, pageIndex, pageSize);
                IList<BookItemViewModel> bookItems = BookItemViewModelBuilder.BuildBookItems(itemsOnPage);
                model.AddSection(
                    new APIResponseSectionViewModel(
                        APIResponseContentSections.BookItemsList,
                        new BookItemsListViewModel(pageIndex, pageSize, totalItems, bookItems)));

                //

                return new JsonResult(model);
            }
            catch (Exception ex)
            {
                return new JsonResult(new APIContentResponseViewModel("An error occurred", ex.Message));
            }
            finally
            {
                model = null;
                bookReference = null;
                bookReferenceViewModel = null;
            }
        }

        //[HttpPost]
        //[Route("[action]")]
        //public async Task<IActionResult> Add([FromForm]string isbn, [FromForm]string lang, [FromForm]string title, [FromForm]string publisher, [FromForm]string author)
        //{
        //    if (string.IsNullOrWhiteSpace(isbn))
        //        throw new ArgumentNullException(nameof(isbn));

        //    if (!Int32.TryParse(isbn, out int _isbn))
        //        throw new ArgumentOutOfRangeException(nameof(isbn));

        //    BookReference bookReference;

        //    // On vérifie si la ref existe en db

        //    bookReference = await _catalogContext.BookReferences
        //       .Where(x => x.ISBN == _isbn)
        //       .SingleOrDefaultAsync();

        //    if (bookReference != null && bookReference.Id > 0)
        //        throw new Exception("Cet ouvrage est déjà référencé");

        //    // On essaye de récupérer les infos

        //    //bookReference = await _bookExternalService.GetBookReferenceDetailsAsync(isbn);

        //    // Si le service externe n'a rien renvoyé de satisfaisant, on ajoute les infos nous-même

        //    if (bookReference == null || string.IsNullOrWhiteSpace(bookReference.Title))
        //    {
        //        if (string.IsNullOrWhiteSpace(lang))
        //            throw new ArgumentNullException(nameof(lang));

        //        if (string.IsNullOrWhiteSpace(title))
        //            throw new ArgumentNullException(nameof(title));

        //        if (string.IsNullOrWhiteSpace(publisher))
        //            throw new ArgumentNullException(nameof(publisher));

        //        if (string.IsNullOrWhiteSpace(author))
        //            throw new ArgumentNullException(nameof(author));

        //        int? publisherId = await _catalogContext.Publishers
        //            .Where(p => p.NormalizedName == NormalizationHelper.NormalizePublisherName(publisher))
        //            .Select(p => p.Id)
        //            .SingleOrDefaultAsync();

        //        if (!publisherId.HasValue || publisherId.Value <= 0)
        //        {
        //            Publisher _publisher = new Publisher
        //            {
        //                InsertedDate = DateTime.Now,
        //                LastUpdatedDate = DateTime.Now,
        //                Name = publisher,
        //                NormalizedName = NormalizationHelper.NormalizePublisherName(publisher)
        //            };

        //            await _catalogContext.Publishers.AddAsync(_publisher);
        //            await _catalogContext.SaveChangesAsync();
        //            publisherId = _publisher.Id;
        //            _publisher = null;
        //        }

        //        IList<int> authorIds = new List<int>();
        //        if (author.Contains(',') || author.Contains(';'))
        //        {
        //            string[] arr = author.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        //            if (arr == null || arr.Length == 0)
        //                throw new ArgumentOutOfRangeException(nameof(author));

        //            foreach (string _authorId in arr)
        //            {
        //                int __authorId = await authorService.GetIdByNormalizedNameAsync(_authorId);

        //                if (__authorId > 0)
        //                    authorIds.Add(__authorId);
        //            }
        //        }
        //        else
        //        {
        //            int _authorId = await authorService.GetIdByNormalizedNameAsync(author);

        //            if (_authorId > 0)
        //                authorIds.Add(_authorId);
        //        }

        //        bookReference = new BookReference
        //        {
        //            ISBN = _isbn,
        //            Title = title,
        //            Language = lang,
        //            Source = (int)BookReferenceSources.Manual,
        //            PublisherId = publisherId.Value
        //        };

        //        await _catalogContext.BookReferences.AddAsync(bookReference);

        //        foreach (int authorId in authorIds)
        //            await _catalogContext.BookReferenceAuthors.AddAsync(new BookReferenceAuthor
        //            {
        //                AuthorId = authorId,
        //                BookReferenceId = bookReference.Id
        //            });
        //    }
        //    else
        //    {
        //        await _catalogContext.BookReferences.AddAsync(bookReference);
        //    }

        //    // Enregistrement & réponse

        //    await _catalogContext.SaveChangesAsync();
        //    return Ok(BookReferenceViewModelBuilder.BuildBookReference(bookReference));
        //}
    }
}