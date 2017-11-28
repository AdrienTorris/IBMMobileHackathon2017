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
    using IBM.Books.Catalog.API.Infrastructure.Helpers;

    /// <summary>
    /// Access to book references persistent data
    /// </summary>
    public sealed class BookReferenceRepository : BaseDataAccessRepository, IBookReferenceRepository
    {
        public BookReferenceRepository(CatalogContext catalogContext)
            : base(catalogContext)
        { }

        public async Task<BookReferenceModel> GetByISBNAsync(long isbn)
        {
            DomainModel.BookReference book = await catalogContext.BookReferences
               .Where(x => x.ISBN == isbn)
               .SingleOrDefaultAsync();

            if (book == null)
                return null;

            return BookReferenceModelBuilder.Build(book);
        }

        public async Task<bool> IsIsbnExistAsync(long isbn) =>
            await catalogContext.BookReferences
               .Where(x => x.ISBN == isbn)
                .Select(x => x.Id)
               .SingleOrDefaultAsync() <= 0 ? false : true;

        public async Task<bool> IsIdExistAsync(int id) =>
            await catalogContext.BookReferences
               .Where(x => x.Id == id)
                .Select(x => x.Id)
               .SingleOrDefaultAsync() <= 0 ? false : true;

        public async Task<int?> CreateAsync(BookReferenceModel bookReference)
        {
            DomainModel.BookReference _bookReference = new DomainModel.BookReference
            {
                Description = bookReference.Description,
                Title = bookReference.Title,
                NormalizedTitle = NormalizationHelper.NormalizeBookTitle(bookReference.Title),
                Image = bookReference.Image,
                ISBN = bookReference.ISBN,
                Language = bookReference.Language,
                InsertedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                PublisherId = bookReference.PublisherId,
                Source = (int)bookReference.Source,
                PublishedDate = bookReference.PublishedDate,
                PageCount = bookReference.PageCount,
                PrintedPageCount = bookReference.PrintedPageCount
            };

            await catalogContext.BookReferences.AddAsync(_bookReference);
            await catalogContext.SaveChangesAsync();

            foreach (int authorId in bookReference.AuthorIds)
                await catalogContext.BookReferenceAuthors.AddAsync(new DomainModel.BookReferenceAuthor
                {
                    AuthorId = authorId,
                    BookReferenceId = _bookReference.Id
                });

            await catalogContext.SaveChangesAsync();
            return _bookReference.Id;
        }

        public async Task<int> CountAsync(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
                return await catalogContext.BookReferences
                    .CountAsync();
            else
                return await catalogContext.BookReferences
                    .Where(
                        x => x.NormalizedTitle.Contains(NormalizationHelper.NormalizeBookTitle(searchQuery))
                        || x.Publisher.NormalizedName.Contains(NormalizationHelper.NormalizeBookTitle(searchQuery))
                    )
                    .CountAsync();
        }

        public async Task<IList<BookReferenceModel>> ListAsync(int pageIndex, int pageSize, string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                return BookReferenceModelBuilder.Build(await catalogContext.BookReferences
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync());
            }
            else
            {
                return BookReferenceModelBuilder.Build(await catalogContext.BookReferences
                        .Where(
                            x => x.NormalizedTitle.Contains(NormalizationHelper.NormalizeBookTitle(searchQuery))
                            || x.Publisher.NormalizedName.Contains(NormalizationHelper.NormalizeBookTitle(searchQuery))
                        )
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync());
            }
        }

        public async Task<bool> IsExistAsync(int id) =>
            await catalogContext.BookReferences
               .Where(x => x.Id == id)
                .Select(x => x.Id)
               .SingleOrDefaultAsync() <= 0 ? false : true;

        public async Task<BookReferenceModel> GetByIdAsync(int id)
            => BookReferenceModelBuilder.Build(
                await catalogContext.BookReferences
               .Where(x => x.Id == id)
               .SingleOrDefaultAsync());
    }
}