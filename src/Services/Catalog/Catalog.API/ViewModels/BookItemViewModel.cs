namespace IBM.Books.Catalog.API.ViewModels
{
    using System;
    using System.Collections.Generic;

    public sealed class BookItemViewModel : IContent
    {
        /// <summary>
        /// Identifiant interne du livre (et pas de la référence)
        /// </summary>
        public int Id { get; internal set; }

        /// <summary>
        /// Titre du livre
        /// </summary>
        public string Title { get; internal set; }

        /// <summary>
        /// Numéro ISBN de l'ouvrage
        /// </summary>
        public long ISBN { get; internal set; }

        /// <summary>
        /// Description du livre
        /// </summary>
        public string Description { get; internal set; }

        /// <summary>
        /// Nombre de pages imprimé au total
        /// </summary>
        public int PrintedPageCount { get; internal set; }

        /// <summary>
        /// Nombre de pages du livre
        /// </summary>
        public int PageCount { get; internal set; }

        /// <summary>
        /// Langue du livre
        /// </summary>
        /// <example>fr</example>
        public string Language { get; internal set; }

        /// <summary>
        /// Nom de l'image
        /// </summary>
        public string Image { get; internal set; }

        /// <summary>
        /// Le livre est-il disponible pour un prêt ou pas ?
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Date de publication de l'ouvrage
        /// </summary>
        public DateTime PublishedDate { get; internal set; }

        /// <summary>
        /// Date de création de la référence dans IBM Books
        /// </summary>
        public DateTime InsertedDate { get; internal set; }

        /// <summary>
        /// Date de dernière mise à jour des informations dans IBM Books
        /// </summary>
        public DateTime LastUpdatedDate { get; internal set; }

        public int OwnerId { get; internal set; }

        public string OwnerUsername { get; internal set; }

        public string OwnerRemarks { get; internal set; }
    }
}