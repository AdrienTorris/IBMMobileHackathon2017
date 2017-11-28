namespace IBM.Books.Catalog.API.Data.Repositories
{
    using IBM.Books.Catalog.API.BusinessModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Access to book references persistent data
    /// </summary>
    public interface IBookReferenceRepository
    {
        Task<BookReferenceModel> GetByISBNAsync(long isbn);

        Task<bool> IsIsbnExistAsync(long isbn);

        Task<bool> IsIdExistAsync(int id);

        Task<int?> CreateAsync(BookReferenceModel bookReference);

        Task<int> CountAsync(string searchQuery);

        Task<IList<BookReferenceModel>> ListAsync(int pageIndex, int pageSize, string searchQuery);

        Task<bool> IsExistAsync(int id);

        Task<BookReferenceModel> GetByIdAsync(int id);
    }
}