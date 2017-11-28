namespace IBM.Books.IntegrationTests.Services.Catalog
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Net;
    using System.Threading.Tasks;

    [TestClass]
    public class CatalogScenarios
          : CatalogScenarioBase
    {
        [TestMethod]
        public async Task Get_get_all_book_references_and_response_ok_status_code()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(Get.BookReferences());

                response.EnsureSuccessStatusCode();

                string responseHtml = await response.Content.ReadAsStringAsync();

                Assert.IsNotNull(responseHtml);
                Assert.IsFalse(string.IsNullOrWhiteSpace(responseHtml));

                // 
                response = null;
                responseHtml = null;
            }
        }

        [TestMethod]
        public async Task Get_get_all_book_items_by_reference_and_response_ok_status_code()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(Get.BookItemsByReference(1));

                response.EnsureSuccessStatusCode();

                string responseHtml = await response.Content.ReadAsStringAsync();

                Assert.IsNotNull(responseHtml);
                Assert.IsFalse(string.IsNullOrWhiteSpace(responseHtml));

                // 
                response = null;
                responseHtml = null;
            }
        }

        [TestMethod]
        public async Task Add_book_item_by_reference_response_ok_status_code()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(Get.BookItemsByReference(1));

                response.EnsureSuccessStatusCode();

                string responseHtml = await response.Content.ReadAsStringAsync();

                Assert.IsNotNull(responseHtml);
                Assert.IsFalse(string.IsNullOrWhiteSpace(responseHtml));

                // 
                response = null;
                responseHtml = null;
            }
        }
    }
}