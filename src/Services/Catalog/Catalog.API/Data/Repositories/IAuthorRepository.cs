namespace IBM.Books.Catalog.API.Data.Repositories
{
    using IBM.Books.Catalog.API.BusinessModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Access to authors persistent data
    /// </summary>
    public interface IAuthorRepository
    {
        Task<int> GetIdByNormalizedNameAsync(string normalizedName);
        Task<int> GetIdByNormalizedNamesAsync(string normalizedFirstName, string normalizedLastName);

        Task<int> GetIdByNormalizedNamesAsync(IList<string> normalizedName);

        Task<int> CreateAsync(AuthorModel author);
    }
}