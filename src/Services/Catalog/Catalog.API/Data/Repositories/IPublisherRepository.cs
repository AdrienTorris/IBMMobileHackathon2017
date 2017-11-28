namespace IBM.Books.Catalog.API.Data.Repositories
{
    using IBM.Books.Catalog.API.BusinessModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Class to deal with publishers persistent data
    /// </summary>
    public interface IPublisherRepository
    {
        Task<int> GetIdAsync(string normalizedName);

        Task<int?> CreateAsync(PublisherModel publisher);
    }
}