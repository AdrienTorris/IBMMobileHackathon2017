namespace IBM.Books.Messaging.API.Data.Repositories
{
    using IBM.Books.Messaging.API.Infrastructure;

    /// <summary>
    /// Base class to access to application persistent data
    /// </summary>
    public abstract class BaseDataAccessRepository
    {
        /// <summary>
        /// Database context
        /// </summary>
        protected readonly MessagingContext _messagingContext;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="messagingContext">database context</param>
        public BaseDataAccessRepository(MessagingContext messagingContext)
        {
            this._messagingContext = messagingContext;
        }
    }
}