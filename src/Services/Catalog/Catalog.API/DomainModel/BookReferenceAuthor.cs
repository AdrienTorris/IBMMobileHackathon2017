using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM.Books.Catalog.API.DomainModel
{
    public class BookReferenceAuthor
    {
        public int BookReferenceId { get; set; }
        public int AuthorId { get; set; }

        public BookReference BookReference { get; set; }
        public Author Author { get; set; }
    }
}