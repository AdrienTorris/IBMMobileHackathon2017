namespace IBM.Books.Catalog.API.Infrastructure.EntityConfigurations
{
    using IBM.Books.Catalog.API.DomainModel;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    class BookReferenceAuthorEntityTypeConfiguration : IEntityTypeConfiguration<BookReferenceAuthor>
    {
        public void Configure(EntityTypeBuilder<BookReferenceAuthor> builder)
        {
            builder.ToTable(nameof(BookReferenceAuthor));

            builder.HasKey(bi => new { bi.BookReferenceId, bi.AuthorId });

            // Relationships

            builder.HasOne<BookReference>(bra => bra.BookReference)
                .WithMany(br => br.Authors);

            builder.HasOne<Author>(bra => bra.Author)
                .WithMany(a => a.Books);
        }
    }
}