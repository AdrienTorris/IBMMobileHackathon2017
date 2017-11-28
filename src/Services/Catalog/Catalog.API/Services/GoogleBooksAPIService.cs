using IBM.Books.Catalog.API.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM.Books.Catalog.API.Services
{
    [Obsolete("Please use ISBNDBAPIService", true)]
    public sealed class GoogleBooksAPIService : IBookExternalService
    {
        public GoogleBooksAPIService()
        { }

        public async Task<BookReferenceModel> GetBookReferenceDetailsAsync(string isbn) =>
            null;
    }
}