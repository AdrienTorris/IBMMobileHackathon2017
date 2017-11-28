using IBM.Books.Catalog.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM.Books.Catalog.API.ViewModels
{
    public class BookItemListViewModel
    {
        public BookReferenceViewModel BookReference { get; set; }

        public BookItemsListViewModel BookItems { get; set; }

        public BookItemListViewModel()
        { }
    }
}