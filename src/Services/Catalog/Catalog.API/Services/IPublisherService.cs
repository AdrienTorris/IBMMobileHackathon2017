namespace IBM.Books.Catalog.API.Services
{
    using IBM.Books.Catalog.API.BusinessModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IPublisherService
    {
        Task<int?> GetIdAsync(string normalizedName);

        Task<int?> CreateAsync(PublisherModel publisher);
    }
}