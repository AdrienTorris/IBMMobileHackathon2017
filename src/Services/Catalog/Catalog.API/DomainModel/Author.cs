using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM.Books.Catalog.API.DomainModel
{
    /// <summary>
    /// Auteur d'un ou plusieurs livres référencés dans IBM Books
    /// </summary>
    public class Author
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string NormalizedFirstName { get; set; }

        public string LastName { get; set; }

        public string NormalizedLastName { get; set; }

        /// <summary>
        /// Date de création dans IBM Books
        /// </summary>
        public DateTime InsertedDate { get; set; }

        /// <summary>
        /// Date de dernière mise à jour dans IBM Books
        /// </summary>
        public DateTime LastUpdatedDate { get; set; }

        public IEnumerable<BookReferenceAuthor> Books { get; set; }
    }
}