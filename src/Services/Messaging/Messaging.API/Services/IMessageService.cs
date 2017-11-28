namespace IBM.Books.Messaging.API.Services
{
    using IBM.Books.Messaging.API.BusinessModel;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMessageService
    {
        Task<int?> CreateAsync(MessageModel message);
    }
}
