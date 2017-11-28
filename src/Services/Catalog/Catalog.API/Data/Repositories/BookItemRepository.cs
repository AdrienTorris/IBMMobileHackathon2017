namespace IBM.Books.Catalog.API.Data.Repositories
{
    using IBM.Books.Catalog.API.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using IBM.Books.Catalog.API.BusinessModel;
    using IBM.Books.Catalog.API.Infrastructure.BusinessModelBuilders;

    public sealed class BookItemRepository : BaseDataAccessRepository, IBookItemRepository
    {
        public BookItemRepository(CatalogContext catalogContext)
            : base(catalogContext)
        { }

        public async Task<int> CountByReferenceAsync(int referenceId) =>
            await catalogContext.BookItems
                .Where(x => x.ReferenceId == referenceId)
                .CountAsync();

        public async Task<IList<BookItemModel>> ListByReferenceAsync(int referenceId, int pageIndex, int pageSize) =>
            BookItemModelBuilder.Build(await catalogContext.BookItems
                    .Where(x => x.ReferenceId == referenceId)
                   .Skip(pageSize * pageIndex)
                   .Take(pageSize)
                   .ToListAsync());

        public async Task<int?> CreateAsync(int referenceId, int ownerId, string ownerRemarks)
        {
            DomainModel.BookItem bookItem = new DomainModel.BookItem
            {
                ReferenceId = referenceId,
                OwnerId = ownerId,
                InsertedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                OwnerRemarks = ownerRemarks,
                IsAvailable = true
            };
            await catalogContext.BookItems.AddAsync(bookItem);
            await catalogContext.SaveChangesAsync();
            return bookItem.Id;
        }

        public async Task<BookItemModel> GetAsync(int id) =>
            BookItemModelBuilder.Build(await catalogContext.BookItems
                    .Where(x => x.Id == id)
                .SingleOrDefaultAsync());

        public async Task<bool> UpdateAvailabilityAsync(int id, bool availability)
        {
            DomainModel.BookItem bookItem = await catalogContext.BookItems
                    .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (bookItem == null)
                return false;

            bookItem.IsAvailable = availability;
            await catalogContext.SaveChangesAsync();
            return true;
        }

        public async Task<IList<BookItemModel>> ListByOwnerIdAsync(int ownerId, int pageIndex, int pageSize) =>
            BookItemModelBuilder.Build(await catalogContext.BookItems
                    .Where(x => x.OwnerId == ownerId)
                   .Skip(pageSize * pageIndex)
                   .Take(pageSize)
                   .ToListAsync());
    }
}