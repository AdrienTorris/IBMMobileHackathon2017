namespace IBM.Books.Catalog.API.Infrastructure.BusinessModelBuilders
{
    using IBM.Books.Catalog.API.BusinessModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class BookItemModelBuilder
    {
        public static BookItemModel Build(DomainModel.BookItem data)
        {
            return new BookItemModel
            {
                Id = data.Id,
                InsertedDate = data.InsertedDate,
                LastUpdatedDate = data.LastUpdatedDate,
                OwnerId = data.OwnerId,
                OwnerRemarks = data.OwnerRemarks,
                ReferenceId = data.ReferenceId,
                IsAvailable = data.IsAvailable
            };
        }

        public static IList<BookItemModel> Build(IList<DomainModel.BookItem> data)
        {
            IList<BookItemModel> ret = new List<BookItemModel>();

            foreach (DomainModel.BookItem book in data)
                ret.Add(Build(book));

            return ret;
        }
    }
}