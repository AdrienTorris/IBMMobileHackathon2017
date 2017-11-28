using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM.Books.Catalog.API.DomainModel
{
    /// <summary>
    /// Référence d'un ouvrage enregistré dans IBM Books
    /// </summary>
    public class BookReference
    {
        /// <summary>
        /// Identifiant interne du livre
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Titre du livre
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Titre normalisé du livre (sans accents, caractères spéciaux, ...)
        /// </summary>
        public string NormalizedTitle { get; set; }

        /// <summary>
        /// Identifiant interne de l'éditeur
        /// </summary>
        public int PublisherId { get; set; }

        /// <summary>
        /// Numéro ISBN de l'ouvrage
        /// </summary>
        public long ISBN { get; set; }

        /// <summary>
        /// Source des informations
        /// </summary>
        public int Source { get; set; }

        /// <summary>
        /// Description du livre
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Nombre de pages imprimé au total
        /// </summary>
        public int PrintedPageCount { get; set; }

        /// <summary>
        /// Nombre de pages du livre
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Langue du livre
        /// </summary>
        /// <example>fr</example>
        public string Language { get; set; }

        /// <summary>
        /// Nom de l'image
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Date de publication de l'ouvrage
        /// </summary>
        public DateTime PublishedDate { get; set; }

        /// <summary>
        /// Date de création de la référence dans IBM Books
        /// </summary>
        public DateTime InsertedDate { get; set; }

        /// <summary>
        /// Date de dernière mise à jour des informations dans IBM Books
        /// </summary>
        public DateTime LastUpdatedDate { get; set; }

        public IEnumerable<BookItem> Items { get; set; }

        public IEnumerable<BookReferenceAuthor> Authors { get; set; }

        public Publisher Publisher { get; set; }
    }
}