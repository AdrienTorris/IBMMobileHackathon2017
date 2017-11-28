using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM.Books.Catalog.API.BusinessModel
{
    /// <summary>
    /// Auteur d'un ou plusieurs livres référencés dans IBM Books
    /// </summary>
    public class AuthorModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string NormalizedFirstName { get; set; }

        public string LastName { get; set; }

        public string NormalizedLastName { get; set; }
    }
}