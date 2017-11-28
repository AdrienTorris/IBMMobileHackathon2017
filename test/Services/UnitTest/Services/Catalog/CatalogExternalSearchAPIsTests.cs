using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Services.Catalog
{
    using IBM.Books.Catalog.API.BusinessModel;
    using IBM.Books.Catalog.API.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading.Tasks;

    [TestClass]
    public class CatalogExternalSearchAPIsTests
    {
        [TestMethod]
        public async Task ISBNDB_Search_by_isbn_success()
        {
            IBookExternalService svc = new ISBNDBAPIService();
            string isbn = "9780735676824";

            BookReferenceModel bookReference = await svc.GetBookReferenceDetailsAsync(isbn);

            //
            svc = null;
            bookReference = null;
            isbn = null;
        }
    }
}