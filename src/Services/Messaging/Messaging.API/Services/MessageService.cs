namespace IBM.Books.Messaging.API.Services
{
    using IBM.Books.Messaging.API.BusinessModel;
    using IBM.Books.Messaging.API.Data.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public sealed class MessageService: IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            this._messageRepository = messageRepository;
        }

        public async Task<int?> CreateAsync(MessageModel message)
        {
            int id = await this._messageRepository.CreateAsync(message);
            if (id <= 0)
                return null;
            return id;
        }
    }
}