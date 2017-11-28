namespace IBM.Books.Catalog.API.Services
{
    using IBM.Books.Catalog.API.BusinessModel;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBookExternalService
    {
        Task<BookReferenceModel> GetBookReferenceDetailsAsync(string isbn);
    }
}