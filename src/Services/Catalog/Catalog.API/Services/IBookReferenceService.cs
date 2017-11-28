namespace IBM.Books.Catalog.API.Services
{
    using IBM.Books.Catalog.API.BusinessModel;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBookReferenceService
    {
        Task<BookReferenceModel> GetByISBNAsync(long isbn);

        Task<bool> IsIsbnExistAsync(long isbn);

        Task<bool> IsIdExistAsync(int id);

        Task<int> CountAsync(string searchQuery);

        Task<IList<BookReferenceModel>> ListAsync(int pageIndex, int pageSize,string searchQuery);

        Task<int?> CreateAsync(BookReferenceModel bookReference);

        Task<BookReferenceModel> GetByIdAsync(int id);
    }
}