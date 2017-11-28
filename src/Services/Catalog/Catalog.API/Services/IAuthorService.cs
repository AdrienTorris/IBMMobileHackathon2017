namespace IBM.Books.Catalog.API.Services
{
    using IBM.Books.Catalog.API.BusinessModel;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAuthorService
    {
        Task<int> GetIdByNormalizedNameAsync(string normalizedName);
        Task<int> GetIdByNormalizedNamesAsync(string normalizedFirstName, string normalizedLastName);
        Task<IList<int>> ParseIdsAsync(string inputString);
        Task<int> CreateAsync(AuthorModel author);
    }
}