namespace IBM.Books.Messaging.API.ViewModels
{
    using System;

    public sealed class MessageViewModel
    {
        public int Id { get; set; }

        public int SenderId { get; set; }

        public int ReceiverId { get; set; }

        public string ReceiverMailAddress { get; set; }

        public int Status { get; set; }

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