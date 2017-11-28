namespace IBM.Books.Catalog.API.Services
{
    using IBM.Books.Catalog.API.BusinessModel;
    using IBM.Books.Catalog.API.Data.Repositories;
    using IBM.Books.Catalog.API.Infrastructure.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public sealed class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<int> GetIdByNormalizedNameAsync(string normalizedName) =>
            await authorRepository.GetIdByNormalizedNameAsync(normalizedName);

        public async Task<int> GetIdByNormalizedNamesAsync(string normalizedFirstName, string normalizedLastName) =>
        await authorRepository.GetIdByNormalizedNamesAsync(normalizedFirstName, normalizedLastName);

        public async Task<IList<int>> ParseIdsAsync(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
                return new List<int>();

            IList<int> ret = new List<int>();

            if (inputString.Contains(';') || inputString.Contains(',') || inputString.Contains('&') || inputString.Contains('|'))
            {
                string[] arr = inputString.Split(new char[] { ';', ',', '&', '|' });
                foreach (string s in arr)
                {
                    int i = await GetIdByNormalizedNameAsync(NormalizationHelper.NormalizeAuthorName(s));

                    if (i > 0)
                        ret.Add(i);
                }
            }
            else
            {
                int i = await GetIdByNormalizedNameAsync(NormalizationHelper.NormalizeAuthorName(inputString));

                if (i > 0)
                    ret.Add(i);
            }

            return ret;
        }

        public async Task<int> CreateAsync(AuthorModel author) =>
            await authorRepository.CreateAsync(author);
    }
}