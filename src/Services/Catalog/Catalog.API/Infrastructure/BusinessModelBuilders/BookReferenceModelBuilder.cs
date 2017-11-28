namespace IBM.Books.Catalog.API.Infrastructure.BusinessModelBuilders
{
    using IBM.Books.Catalog.API.BusinessModel;
    using IBM.Books.Catalog.API.Infrastructure.Enumerations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class BookReferenceModelBuilder
    {
        public static BookReferenceModel Build(DomainModel.BookReference data)
        {
            if (data == null)
                return null;

            return new BookReferenceModel
            {
                Description = data.Description,
                Id = data.Id,
                Image = data.Image,
                InsertedDate = data.InsertedDate,
                ISBN = data.ISBN,
                Language = data.Language,
                LastUpdatedDate = data.LastUpdatedDate,
                NormalizedTitle = data.NormalizedTitle,
                PageCount = data.PageCount,
                PrintedPageCount = data.PrintedPageCount,
                PublishedDate = data.PublishedDate,
                PublisherId = data.PublisherId,
                Source = (BookReferenceSources)data.Source,
                Title = data.Title
            };
        }

        public static IList<BookReferenceModel> Build(IList<DomainModel.BookReference> data)
        {
            IList<BookReferenceModel> ret = new List<BookReferenceModel>();

            foreach (DomainModel.BookReference book in data)
                ret.Add(Build(book));

            return ret;
        }
    }
}