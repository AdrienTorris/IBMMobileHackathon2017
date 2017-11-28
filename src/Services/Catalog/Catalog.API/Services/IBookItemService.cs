namespace IBM.Books.Catalog.API.Services
{
    using IBM.Books.Catalog.API.BusinessModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IBookItemService
    {
        Task<int> CountByReferenceAsync(int referenceId);

        Task<IList<BookItemModel>> ListByReferenceAsync(int referenceId, int pageIndex, int pageSize);

        Task<int?> CreateAsync(int referenceId, int ownerId, string ownerRemarks);

        Task<BookItemModel> GetAsync(int id);

        Task<int?> CreateAsync(int ownerId, string ownerRemarks, string isbn, string lang, string title, string publisher, string author);

        Task<bool> UpdateAvailabilityAsync(int id, bool availability);

        Task<IList<BookItemModel>> ListByOwnerIdAsync(int ownerId, int pageIndex, int pageSize);
    }
}