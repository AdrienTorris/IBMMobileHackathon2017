namespace IBM.Books.Catalog.API.Data.Repositories
{
    using IBM.Books.Catalog.API.BusinessModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IBookItemRepository
    {
        Task<int> CountByReferenceAsync(int referenceId);

        Task<IList<BookItemModel>> ListByReferenceAsync(int referenceId, int pageIndex, int pageSize);

        Task<int?> CreateAsync(int referenceId, int ownerId, string ownerRemarks);

        Task<BookItemModel> GetAsync(int id);

        Task<bool> UpdateAvailabilityAsync(int id, bool availability);

        Task<IList<BookItemModel>> ListByOwnerIdAsync(int ownerId, int pageIndex, int pageSize);
    }
}