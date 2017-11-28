namespace IBM.Books.IntegrationTests.Services.Catalog
{
    using Microsoft.Extensions.Configuration;
    using IBM.Books.Catalog.API;

    public class CatalogTestsStartup : Startup
    {
        public CatalogTestsStartup(IConfiguration env) : base(env)
        {
        }
    }
}