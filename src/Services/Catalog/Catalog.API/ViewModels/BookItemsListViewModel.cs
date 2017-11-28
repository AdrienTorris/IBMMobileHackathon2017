using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM.Books.Catalog.API.ViewModels
{
    public sealed class BookItemsListViewModel : PaginatedItemsViewModel<BookItemViewModel>, IContent
    {
        public BookItemsListViewModel(int pageIndex, int pageSize, long count, IEnumerable<BookItemViewModel> data)
            : base(pageIndex, pageSize, count, data)
        {
        }
    }
}