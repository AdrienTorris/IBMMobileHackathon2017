namespace IBM.Books.Catalog.API.Data.Repositories
{
    using IBM.Books.Catalog.API.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using IBM.Books.Catalog.API.BusinessModel;

    /// <summary>
    /// Class to deal with publishers persistent data
    /// </summary>
    public sealed class PublisherRepository : BaseDataAccessRepository, IPublisherRepository
    {
        public PublisherRepository(CatalogContext catalogContext)
            : base(catalogContext)
        { }

        public async Task<int> GetIdAsync(string normalizedName) =>
            await catalogContext.Publishers
                    .Where(p => p.NormalizedName == normalizedName)
                    .Select(p => p.Id)
                    .SingleOrDefaultAsync();

        public async Task<int?> CreateAsync(PublisherModel publisher)
        {
            DomainModel.Publisher p = new DomainModel.Publisher
            {
                InsertedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = publisher.Name,
                NormalizedName = publisher.NormalizedName
            };
            await catalogContext.Publishers.AddAsync(p);
            await catalogContext.SaveChangesAsync();
            return p.Id;
        }
    }
}