namespace IBM.Books.IntegrationTests.Services.Identity
{
    using IBM.Books.Identity.API.ViewModels;
    using IBM.Books.Identity.API.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    [TestClass]
    public class IdentityScenarios
        : IdentityScenarioBase
    {
        #region Test Context

        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {

        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

        }

        #endregion

        [TestMethod]
        public async Task Post_account_register_ok_status_code()
        {
            using (var server = CreateServer())
            {
                var content = new StringContent(BuildValidUser(), UTF8Encoding.UTF8, "application/json");
                var response = await server.CreateClient().PostAsync(Account.Register(), content);

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [TestMethod]
        public async Task Post_account_login_ok_status_code()
        {
            using (var server = CreateServer())
            {
                var content = new StringContent(BuildValidUser(), UTF8Encoding.UTF8, "application/json");
                var response = await server.CreateClient().PostAsync(Account.Login(), content);

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        string BuildValidUser()
        {
            var user = new UserViewModel
            {
                UserName = "adrientorris3@ibm.com",
                Email = "adrientorris3@ibm.com",
                FirstName = "Adrien",
                LastName = "Torris",
                Password = "!TesTest@11"
            };

            return JsonConvert.SerializeObject(user);
        }

        string BuildUserWithInvalidEmail()
        {
            var user = new UserViewModel
            {
                UserName = "adrientorris@gmail.com",
                Email = "adrientorris@gmail.com",
                FirstName = "Adrien",
                LastName = "Torris",
                Password = "!Testest@11"
            };

            return JsonConvert.SerializeObject(user);
        }
    }
}