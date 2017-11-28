namespace IBM.Books.Catalog.API.BusinessModel
{
    using IBM.Books.Catalog.API.Infrastructure.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Editeur d'un ou pusieurs livres référencés dans IBM Books
    /// </summary>
    public class PublisherModel
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

        public PublisherModel(string name)
        {
            this.Name = name;
            this.NormalizedName = NormalizationHelper.NormalizePublisherName(name);
        }
    }
}