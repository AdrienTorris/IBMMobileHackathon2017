namespace IBM.Books.Catalog.API.Infrastructure.EntityConfigurations
{
    using IBM.Books.Catalog.API.DomainModel;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    class BookReferenceEntityTypeConfiguration : IEntityTypeConfiguration<BookReference>
    {
        public void Configure(EntityTypeBuilder<BookReference> builder)
        {
            builder.ToTable(nameof(BookReference));

            builder.HasKey(br => br.Id);

            builder.Property(br => br.Id)
               .ForSqlServerUseSequenceHiLo("book_reference_hilo")
               .IsRequired();

            builder.Property(br => br.Title)
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(br => br.NormalizedTitle)
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(br => br.Language)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(br => br.ISBN)
                .IsRequired();

            builder.Property(br => br.PublisherId)
                .IsRequired();

            builder.Property(br => br.Source)
                .IsRequired();

            builder.Property(br => br.InsertedDate)
                .IsRequired()
                .HasDefaultValue<DateTime>(DateTime.Now)
                .ValueGeneratedOnAdd();

            builder.Property(br => br.LastUpdatedDate)
                .IsRequired()
                .HasDefaultValue<DateTime>(DateTime.Now)
                .ValueGeneratedOnAddOrUpdate();

            // Relationships

            builder.HasMany<BookItem>(br => br.Items)
                .WithOne(bi => bi.Reference);

            builder.HasMany<BookReferenceAuthor>(br => br.Authors)
                .WithOne(bra => bra.BookReference);

            builder.HasOne<Publisher>(br => br.Publisher)
                .WithMany(p => p.Books);
        }
    }
}