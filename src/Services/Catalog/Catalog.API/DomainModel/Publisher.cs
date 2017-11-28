using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM.Books.Catalog.API.DomainModel
{
    /// <summary>
    /// Editeur d'un ou pusieurs livres référencés dans IBM Books
    /// </summary>
    public class Publisher
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }

        /// <summary>
        /// Date de création dans IBM Books
        /// </summary>
        public DateTime InsertedDate { get; set; }

        /// <summary>
        /// Date de dernière mise à jour dans IBM Books
        /// </summary>
        public DateTime LastUpdatedDate { get; set; }

        public IEnumerable<BookReference> Books { get; set; }
    }
}