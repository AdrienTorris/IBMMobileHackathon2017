namespace IBM.Books.Catalog.API.Data.Repositories
{
    using IBM.Books.Catalog.API.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using IBM.Books.Catalog.API.BusinessModel;
    using IBM.Books.Catalog.API.Infrastructure.Helpers;

    /// <summary>
    /// Access to authors persistent data
    /// </summary>
    public sealed class AuthorRepository : BaseDataAccessRepository, IAuthorRepository
    {
        public AuthorRepository(CatalogContext catalogContext)
            : base(catalogContext)
        { }

        public async Task<int> GetIdByNormalizedNameAsync(string normalizedName)
        {
            if (string.IsNullOrWhiteSpace(normalizedName))
                throw new ArgumentNullException(nameof(normalizedName));

            return await catalogContext.Authors
                .Where(a =>
                    a.NormalizedFirstName.Contains(normalizedName)
                    || a.NormalizedLastName.Contains(normalizedName)
                    || (a.NormalizedFirstName + " " + a.NormalizedLastName).Contains(normalizedName))
                .Select(a => a.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetIdByNormalizedNamesAsync(string normalizedFirstName, string normalizedLastName) =>
         await catalogContext.Authors
                .Where(a =>
                    a.NormalizedFirstName.Contains(normalizedFirstName)
                    && a.NormalizedLastName.Contains(normalizedLastName))
                .Select(a => a.Id)
                .FirstOrDefaultAsync();

        public async Task<int> GetIdByNormalizedNamesAsync(IList<string> normalizedName)
        {
            return await catalogContext.Authors
                .Where(a =>
                   normalizedName.Contains(a.NormalizedFirstName)
                   && normalizedName.Contains(a.NormalizedLastName))
                .Select(a => a.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(AuthorModel author)
        {
            DomainModel.Author _author = new DomainModel.Author
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                NormalizedFirstName = NormalizationHelper.NormalizeAuthorName(author.FirstName),
                NormalizedLastName = NormalizationHelper.NormalizeAuthorName(author.LastName),
                InsertedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            await catalogContext.Authors.AddAsync(_author);
            await catalogContext.SaveChangesAsync();
            return _author.Id;
        }
    }
}