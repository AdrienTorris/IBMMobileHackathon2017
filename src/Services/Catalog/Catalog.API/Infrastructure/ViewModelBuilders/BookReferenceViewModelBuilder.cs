namespace IBM.Books.Catalog.API.Infrastructure.ViewModelBuilders
{
    using IBM.Books.Catalog.API.ViewModels;
    using IBM.Books.Catalog.API.DomainModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using IBM.Books.Catalog.API.BusinessModel;

    internal static class BookReferenceViewModelBuilder
    {
        [Obsolete("Use the business models instead of domain model", true)]
        public static BookReferenceViewModel BuildBookReference(BookReference bookReference)
        {
            return new BookReferenceViewModel
            {
                Title = bookReference.Title,
                Description = bookReference.Description,
                Id = bookReference.Id,
                InsertedDate = bookReference.InsertedDate,
                ISBN = bookReference.ISBN,
                PageCount = bookReference.PageCount,
                //Image = bookReference.Image,
                Language = bookReference.Language,
                LastUpdatedDate = bookReference.LastUpdatedDate,
                PrintedPageCount = bookReference.PrintedPageCount,
                PublishedDate = bookReference.PublishedDate
            };
        }

        public static BookReferenceViewModel BuildBookReference(BookReferenceModel bookReference, string basePictureUrl, string noPictureFileName)
        {
            return new BookReferenceViewModel
            {
                Title = bookReference.Title,
                Description = bookReference.Description,
                Id = bookReference.Id,
                InsertedDate = bookReference.InsertedDate,
                ISBN = bookReference.ISBN,
                PageCount = bookReference.PageCount,
                ImageUrl = basePictureUrl + (!string.IsNullOrWhiteSpace(bookReference.Image) ? bookReference.Image : noPictureFileName),
                Language = bookReference.Language,
                LastUpdatedDate = bookReference.LastUpdatedDate,
                PrintedPageCount = bookReference.PrintedPageCount,
                PublishedDate = bookReference.PublishedDate
            };
        }

        [Obsolete("Use the business models instead of domain model", true)]
        public static IList<BookReferenceViewModel> BuildBookReferences(IEnumerable<BookReference> bookReferences)
        {
            IList<BookReferenceViewModel> ret = new List<BookReferenceViewModel>();

            bookReferences.ToList().ForEach(delegate (BookReference bookReference)
            {
                ret.Add(BuildBookReference(bookReference));
            });

            return ret;
        }

        public static IList<BookReferenceViewModel> BuildBookReferences(IEnumerable<BookReferenceModel> bookReferences, string basePictureUrl, string noPictureFileName)
        {
            IList<BookReferenceViewModel> ret = new List<BookReferenceViewModel>();

            bookReferences.ToList().ForEach(delegate (BookReferenceModel bookReference)
            {
                ret.Add(BuildBookReference(bookReference, basePictureUrl, noPictureFileName));
            });

            return ret;
        }
    }
}