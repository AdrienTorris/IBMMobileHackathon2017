namespace IBM.Books.Messaging.API.BusinessModel
{
    using IBM.Books.Messaging.API.Infrastructure.Enumerations;
    using System;
    using System.Collections.Generic;

    public class MessageModel
    {
        public int Id { get; set; }

        public int SenderId { get; set; }

        public int ReceiverId { get; set; }

        public MessageStatusEnum Status { get; set; }

        public string Content { get; set; }

        public int? BookItemId { get; set; }

        /// <summary>
        /// Date de création dans IBM Books
        /// </summary>
        public DateTime InsertedDate { get; set; }

        /// <summary>
        /// Date de dernière mise à jour dans IBM Books
        /// </summary>
        public DateTime LastUpdatedDate { get; set; }
    }
}