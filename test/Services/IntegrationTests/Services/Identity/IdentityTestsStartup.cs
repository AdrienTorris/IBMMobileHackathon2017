namespace IBM.Books.IntegrationTests.Services.Identity
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using IBM.Books.Identity.API;

    public class IdentityTestsStartup : Startup
    {
        public IdentityTestsStartup(IConfiguration env) : base(env)
        {
        }
    }
}