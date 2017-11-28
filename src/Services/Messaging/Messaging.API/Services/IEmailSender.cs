namespace IBM.Books.Messaging.API.Services
{
    using IBM.Books.Messaging.API.Infrastructure.Configuration;
    using System.Threading.Tasks;

    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}