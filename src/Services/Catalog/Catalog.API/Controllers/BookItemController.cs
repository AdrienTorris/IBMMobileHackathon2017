namespace Catalog.API.Controllers
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
    using IBM.Books.Catalog.API.ViewModels;
    using IBM.Books.Catalog.API.Infrastructure.ViewModelBuilders;
    using IBM.Books.Catalog.API.Services;
    using IBM.Books.Catalog.API.Infrastructure.Enumerations;

    [Route("api/v1/[controller]")]
    public class BookItemController : Controller
    {
        private readonly CatalogContext _catalogContext;
        private readonly CatalogSettings _settings;
        private readonly IBookItemService bookItemService;
        private readonly IBookReferenceService _bookReferenceService;

        public BookItemController(CatalogContext context,
            IOptionsSnapshot<CatalogSettings> settings,
            IBookItemService bookItemService,
            IBookReferenceService bookReferenceService)
        {
            _catalogContext = context ?? throw new ArgumentNullException(nameof(context));
            _settings = settings.Value;
            this.bookItemService = bookItemService;
            _bookReferenceService = bookReferenceService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> ListByReference([FromQuery]int id, [FromQuery]int pageIndex = 0, [FromQuery]int pageSize = 15)
        {
            //var totalItems = await bookItemService.CountByReferenceAsync(id);

            //var itemsOnPage = await bookItemService.ListByReferenceAsync(id, pageIndex, pageSize);

            //IList<BookItemViewModel> bookItems = BookItemViewModelBuilder.BuildBookItems(itemsOnPage);

            //var model = new PaginatedItemsViewModel<BookItemViewModel>(pageIndex, pageSize, totalItems, bookItems);

            //return Ok(model);

            var totalItems = await bookItemService.CountByReferenceAsync(id);

            var itemsOnPage = await bookItemService.ListByReferenceAsync(id, pageIndex, pageSize);

            IList<BookItemViewModel> bookItems = BookItemViewModelBuilder.BuildBookItems(itemsOnPage);

            BookItemListViewModel model = new BookItemListViewModel
            {
                BookReference = BookReferenceViewModelBuilder.BuildBookReference(await this._bookReferenceService.GetByIdAsync(id), _settings.BasePictureUrl, _settings.ImageUnavailableImageFileName),
                BookItems = new BookItemsListViewModel(pageIndex, pageSize, totalItems, bookItems)
            };

            return new JsonResult(model);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> AddByReference([FromForm]int referenceId, [FromForm]int ownerId, [FromForm]string ownerRemarks)
        {
            APIContentResponseViewModel model;
            int? id;

            try
            {
                id = await this.bookItemService.CreateAsync(referenceId, ownerId, ownerRemarks);

                if (!id.HasValue || id.Value <= 0)
                    return new JsonResult(new APIResponseBaseViewModel("error", "an error occurred"));

                model = new APIContentResponseViewModel(new APIResponseSectionViewModel(
                    APIResponseContentSections.BookItemDetails,
                    BookItemViewModelBuilder.BuildBookItem(await bookItemService.GetAsync(id.Value))
                    ));

                return new JsonResult(model);
            }
            catch (Exception ex)
            {
                return new JsonResult(new APIResponseBaseViewModel(ex.Message, ex.Message));
            }
            finally
            {
                model = null;
                id = null;
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> Add([FromForm]int ownerId, [FromForm]string ownerRemarks, [FromForm]string isbn, [FromForm]string lang, [FromForm]string title, [FromForm]string publisher, [FromForm]string author)
        {
            APIContentResponseViewModel model;
            int? id;

            try
            {
                id = await this.bookItemService.CreateAsync(ownerId, ownerRemarks, isbn, lang, title, publisher, author);

                if (!id.HasValue || id.Value <= 0)
                    return new JsonResult(new APIResponseBaseViewModel("error", "an error occurred"));

                model = new APIContentResponseViewModel(new APIResponseSectionViewModel(
                    APIResponseContentSections.BookItemDetails,
                    BookItemViewModelBuilder.BuildBookItem(await bookItemService.GetAsync(id.Value))
                    ));

                return new JsonResult(model);
            }
            catch (Exception ex)
            {
                return new JsonResult(new APIResponseBaseViewModel(ex.Message, ex.Message));
            }
            finally
            {
                model = null;
                id = null;
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> UpdateAvailability([FromForm]int id, [FromForm]bool availability)
        {
            APIActionResponseViewModel model;

            try
            {
                bool b = await this.bookItemService.UpdateAvailabilityAsync(id, availability);
                if (!b)
                    return new JsonResult(new APIActionResponseViewModel("error", "error"));

                return new JsonResult(new APIActionResponseViewModel());
            }
            catch (Exception ex)
            {
                return new JsonResult(new APIActionResponseViewModel(ex.Message, ex.Message));
            }
            finally
            {
                model = null;
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> ListByOwner([FromQuery]int id, [FromQuery]int pageIndex = 0, [FromQuery]int pageSize = 30)
        {
            var totalItems = await bookItemService.CountByReferenceAsync(id);

            var itemsOnPage = await bookItemService.ListByOwnerIdAsync(id, pageIndex, pageSize);

            IList<BookItemViewModel> bookItems = BookItemViewModelBuilder.BuildBookItems(itemsOnPage);

            var model = new PaginatedItemsViewModel<BookItemViewModel>(pageIndex, pageSize, totalItems, bookItems);

            return Ok(model);
        }
    }
}