using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Services.Messaging
{
    using IBM.Books.Messaging.API.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading.Tasks;

    [TestClass]
    public class MessagingEmailSenderTests
    {
        [TestMethod]
        public async Task SendMailAsync_success()
        {
            //IEmailSender emailSender = new EmailSender();
            //await emailSender.SendEmailAsync("adrientorris@gmail.com", "test", "test contenu");
        }
    }
}