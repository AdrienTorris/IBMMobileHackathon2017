using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Services.Indentity
{
    using IBM.Books.IdentityCore.Infrastructure.Helpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IdentityInfrastructureTests
    {
        [TestMethod]
        public void User_password_cryptography_scenarios_success()
        {
            string clearPassword1 = "testest";

            string encryptedPassword1 = CryptographyHelper.EncryptUserPassword(clearPassword1);
            Assert.IsNotNull(encryptedPassword1);
            Assert.IsFalse(string.IsNullOrWhiteSpace(encryptedPassword1));
            Assert.AreNotEqual<string>(clearPassword1, encryptedPassword1);

            string decryptedPassword1 = CryptographyHelper.DecryptUserPassword(encryptedPassword1);
            Assert.IsNotNull(decryptedPassword1);
            Assert.IsFalse(string.IsNullOrWhiteSpace(decryptedPassword1));
            Assert.AreEqual<string>(clearPassword1, decryptedPassword1);

            string encryptedPassword2 = CryptographyHelper.EncryptUserPassword(clearPassword1);
            Assert.IsNotNull(encryptedPassword2);
            Assert.IsFalse(string.IsNullOrWhiteSpace(encryptedPassword2));
            Assert.AreNotEqual<string>(clearPassword1, encryptedPassword2);

            string decryptedPassword2 = CryptographyHelper.DecryptUserPassword(encryptedPassword2);
            Assert.IsNotNull(decryptedPassword2);
            Assert.IsFalse(string.IsNullOrWhiteSpace(decryptedPassword2));
            Assert.AreEqual<string>(clearPassword1, decryptedPassword2);

            //Assert.AreEqual<string>(encryptedPassword1, encryptedPassword2);
        }
    }
}