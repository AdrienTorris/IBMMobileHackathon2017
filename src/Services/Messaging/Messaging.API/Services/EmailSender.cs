namespace IBM.Books.Messaging.API.Services
{
    using IBM.Books.Messaging.API.Infrastructure.Configuration;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    public sealed class EmailSender : IEmailSender
    {
        private readonly MailSettings _mailSettings;

        public EmailSender(IOptionsSnapshot<MessagingSettings> settings)
        {
            _mailSettings = settings.Value.Mail;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                using (SmtpClient client = new SmtpClient(_mailSettings.SMTP.Host))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(_mailSettings.SMTP.NetworkCredential.Username, _mailSettings.SMTP.NetworkCredential.Password);
                    client.Port = _mailSettings.SMTP.Port;

                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(_mailSettings.From);
                        mailMessage.To.Add(email);
                        mailMessage.Body = message;
                        mailMessage.Subject = subject;
                        if (!string.IsNullOrWhiteSpace(_mailSettings.CCs))
                        {
                            mailMessage.To.Add(_mailSettings.CCs);
                        }

                        //client.Send(mailMessage);
                        await client.SendMailAsync(mailMessage);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public async Task SendEmailAsync(MailSettings settings, string email, string subject, string message)
        //{
        //    try
        //    {
        //        using (SmtpClient client = new SmtpClient(settings.SMTP.Host))
        //        {
        //            client.UseDefaultCredentials = false;
        //            client.Credentials = new NetworkCredential(settings.SMTP.NetworkCredential.Username, settings.SMTP.NetworkCredential.Password);
        //            client.Port = settings.SMTP.Port;

        //            using (MailMessage mailMessage = new MailMessage())
        //            {
        //                mailMessage.From = new MailAddress(settings.From);
        //                mailMessage.To.Add(email);
        //                mailMessage.Body = message;
        //                mailMessage.Subject = subject;
        //                if (!string.IsNullOrWhiteSpace(settings.CCs))
        //                {
        //                    mailMessage.To.Add(settings.CCs);
        //                }

        //                //client.Send(mailMessage);
        //                await client.SendMailAsync(mailMessage);
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}