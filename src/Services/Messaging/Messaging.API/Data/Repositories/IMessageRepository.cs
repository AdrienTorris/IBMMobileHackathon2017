namespace IBM.Books.Messaging.API.Data.Repositories
{
    using IBM.Books.Messaging.API.BusinessModel;
    using System;
    using System.Threading.Tasks;

    public interface IMessageRepository
    {
        Task<int> CreateAsync(MessageModel message);
    }
}