namespace IBM.Books.Catalog.API.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using EntityConfigurations;
    using DomainModel;
    using Microsoft.EntityFrameworkCore.Design;

    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }

        public DbSet<BookReference> BookReferences { get; set; }
        public DbSet<BookItem> BookItems { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookReferenceAuthor> BookReferenceAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BookReferenceEntityTypeConfiguration());
            builder.ApplyConfiguration(new BookItemEntityTypeConfiguration());
            builder.ApplyConfiguration(new AuthorEntityTypeConfiguration());
            builder.ApplyConfiguration(new PublisherEntityTypeConfiguration());
            builder.ApplyConfiguration(new BookReferenceAuthorEntityTypeConfiguration());
        }
    }
}