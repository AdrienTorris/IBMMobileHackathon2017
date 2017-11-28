namespace IBM.Books.Messaging.API.Data.Repositories
{
    using IBM.Books.Messaging.API.BusinessModel;
    using IBM.Books.Messaging.API.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public sealed class MessageRepository : BaseDataAccessRepository, IMessageRepository
    {
        public MessageRepository(MessagingContext messagingContext)
            : base(messagingContext)
        { }

        public async Task<int> CreateAsync(MessageModel message)
        {
            DomainModel.Message msg = new DomainModel.Message
            {
                BookItemId = message.BookItemId,
                Content = message.Content,
                ReceiverId = message.ReceiverId,
                SenderId = message.SenderId,
                Status = (int)message.Status,
                InsertedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            await _messagingContext.Messages.AddAsync(msg);
            await _messagingContext.SaveChangesAsync();
            return msg.Id;
        }
    }
}