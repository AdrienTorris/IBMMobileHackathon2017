namespace IBM.Books.Messaging.API.Infrastructure.Configuration
{
    public class MessagingSettings
    {
        public MailSettings Mail { get; set; }
    }

    public class MailSettings
    {
        public string From { get; set; }
        public string CCs { get; set; }
        public SMTP SMTP { get; set; }
    }

    public class SMTP
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public NetworkCredentials NetworkCredential { get; set; }
    }

    public class NetworkCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}