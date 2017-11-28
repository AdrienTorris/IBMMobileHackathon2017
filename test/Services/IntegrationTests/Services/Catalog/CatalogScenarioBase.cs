namespace IBM.Books.IntegrationTests.Services.Catalog
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using System.IO;
    using IBM.Books.Catalog.API;
    using Microsoft.Extensions.Configuration;

    public class CatalogScenarioBase
    {
        protected static string catalogApiUrl;

        public TestServer CreateServer()
        {
            var webHostBuilder = new WebHostBuilder();
            webHostBuilder.UseContentRoot(Directory.GetCurrentDirectory() + "\\Services\\Catalog");
            webHostBuilder.UseStartup<CatalogTestsStartup>();

            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory() + "\\Services\\Catalog")
              .AddJsonFile("appsettings.json", optional: true)
              .Build();

            catalogApiUrl = config["ExternalCatalogBaseUrl"];

            webHostBuilder.UseConfiguration(config);

            return new TestServer(webHostBuilder);
        }

        public static class Get
        {
            private const int PageIndex = 0;
            private const int PageCount = 3;

            public static string BookReferences(bool paginated = false)
            {
                return paginated
                    ? catalogApiUrl + "/api/v1/bookreference/list" + Paginated(PageIndex, PageCount)
                    : catalogApiUrl + "/api/v1/bookreference/list";
            }

            public static string BookReferenceByISBN(int isbn)
            {
                return $"{catalogApiUrl}/api/v1/bookreference/{isbn}";
            }

            private static string Paginated(int pageIndex, int pageCount)
            {
                return $"{catalogApiUrl}?pageIndex={pageIndex}&pageSize={pageCount}";
            }

            public static string BookItemsByReference(int referenceId, bool paginated = false)
            {
                return paginated
                    ? catalogApiUrl + "/api/v1/bookitem/listbyreference" + Paginated(PageIndex, PageCount) + "&?id=" + referenceId
                    : catalogApiUrl + "/api/v1/bookitem/listbyreference?id=" + referenceId;
            }
        }
    }
}