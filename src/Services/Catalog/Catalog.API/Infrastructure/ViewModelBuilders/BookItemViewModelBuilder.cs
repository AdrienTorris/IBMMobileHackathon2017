namespace IBM.Books.Catalog.API.Infrastructure.ViewModelBuilders
{
    using IBM.Books.Catalog.API.BusinessModel;
    using IBM.Books.Catalog.API.DomainModel;
    using IBM.Books.Catalog.API.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal static class BookItemViewModelBuilder
    {
        public static BookItemViewModel BuildBookItem(BookItemModel bookItem)
        {
            var model = new BookItemViewModel
            {
                Id = bookItem.Id,
                OwnerRemarks = bookItem.OwnerRemarks,
                IsAvailable = bookItem.IsAvailable,
                OwnerId = bookItem.OwnerId
            };

            if (bookItem.Reference != null)
            {
                model.Title = bookItem.Reference.Title;
                model.Description = bookItem.Reference.Description;
                model.ISBN = bookItem.Reference.ISBN;
                model.Language = bookItem.Reference.Language;
                model.PageCount = bookItem.Reference.PageCount;
            }

            return model;
        }

        public static IList<BookItemViewModel> BuildBookItems(IEnumerable<BookItemModel> bookItems)
        {
            IList<BookItemViewModel> ret = new List<BookItemViewModel>();

            bookItems.ToList().ForEach(delegate (BookItemModel bookItem)
            {
                ret.Add(BuildBookItem(bookItem));
            });

            return ret;
        }

        public static BookItemViewModel BuildBookItem(BookItem bookItem)
        {
            var model = new BookItemViewModel
            {
                Id = bookItem.Id,
                OwnerRemarks = bookItem.OwnerRemarks,
                IsAvailable = bookItem.IsAvailable
            };

            if (bookItem.Reference != null)
            {
                model.Title = bookItem.Reference.Title;
                model.Description = bookItem.Reference.Description;
                model.ISBN = bookItem.Reference.ISBN;
                model.Language = bookItem.Reference.Language;
                model.PageCount = bookItem.Reference.PageCount;
            }

            return model;
        }

        public static IList<BookItemViewModel> BuildBookItems(IEnumerable<BookItem> bookItems)
        {
            IList<BookItemViewModel> ret = new List<BookItemViewModel>();

            bookItems.ToList().ForEach(delegate (BookItem bookItem)
            {
                ret.Add(BuildBookItem(bookItem));
            });

            return ret;
        }
    }
}