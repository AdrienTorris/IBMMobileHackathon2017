namespace IBM.Books.IntegrationTests.Services.Identity
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using System.IO;
    using IBM.Books.Identity.API;
    using Microsoft.Extensions.Configuration;

    public class IdentityScenarioBase
    {
        public TestServer CreateServer()
        {
            //var webHostBuilder = new WebHostBuilder();
            //webHostBuilder.UseContentRoot(Directory.GetCurrentDirectory() + "\\Services\\Identity");
            //webHostBuilder.UseStartup<Startup>();

            //return new TestServer(webHostBuilder);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////

            //var webHostBuilder = new WebHostBuilder();
            //webHostBuilder.UseContentRoot(Directory.GetCurrentDirectory() + "\\Services\\Identity");
            //webHostBuilder.UseStartup<IdentityTestsStartup>();

            //return new TestServer(webHostBuilder);


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////

            var webHostBuilder = new WebHostBuilder();
            webHostBuilder.UseContentRoot(Directory.GetCurrentDirectory() + "\\Services\\Identity");
            webHostBuilder.UseStartup<IdentityTestsStartup>();

            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory() + "\\Services\\Identity")
              .AddJsonFile("appsettings.json", optional: true)
              .Build();
            
            webHostBuilder.UseConfiguration(config);

            return new TestServer(webHostBuilder);
        }
        
        public static class Account
        {
            public static string Login()
            {
                return $"api/v1/account/login";
            }

            public static string Register()
            {
                return $"api/v1/account/register";
            }
        }
    }
}