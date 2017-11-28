namespace IBM.Books.Catalog.API.BusinessModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Livre disponible dans le catalogue, possédé par un IBMer
    /// </summary>
    public class BookItemModel
    {
        /// <summary>
        /// Identifiant interne de l'ouvrage
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identifiant de la référence qui porte les informations de l'ouvrage en question
        /// </summary>
        public int ReferenceId { get; set; }

        /// <summary>
        /// Identifiant de l'IBMer possédant ce livre
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// Remarques du détenteur de l'ouvrage à propos de ce dernier
        /// Permet d'indiquer si le livre est abîmé ou autre
        /// </summary>
        public string OwnerRemarks { get; set; }

        /// <summary>
        /// Le livre est-il disponible pour un prêt ou pas ?
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Date de création dans IBM Books
        /// </summary>
        public DateTime InsertedDate { get; set; }

        /// <summary>
        /// Date de dernière mise à jour dans IBM Books
        /// </summary>
        public DateTime LastUpdatedDate { get; set; }

        public BookReferenceModel Reference { get; set; }
    }
}