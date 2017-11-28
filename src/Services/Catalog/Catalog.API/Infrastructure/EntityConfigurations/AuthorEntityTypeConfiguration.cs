namespace IBM.Books.Catalog.API.Infrastructure.EntityConfigurations
{
    using IBM.Books.Catalog.API.DomainModel;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable(nameof(Author));

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
               .ForSqlServerUseSequenceHiLo("author_hilo")
               .IsRequired();

            builder.Property(a => a.FirstName)
                .IsRequired(true)
                .HasMaxLength(80);

            builder.Property(a => a.NormalizedFirstName)
                .IsRequired(true)
                .HasMaxLength(80);

            builder.Property(a => a.LastName)
                .IsRequired(false)
                .HasMaxLength(80);

            builder.Property(a => a.NormalizedLastName)
                .IsRequired(false)
                .HasMaxLength(80);

            builder.Property(a => a.InsertedDate)
                .IsRequired()
                .HasDefaultValue<DateTime>(DateTime.Now)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.LastUpdatedDate)
                .IsRequired()
                .HasDefaultValue<DateTime>(DateTime.Now)
                .ValueGeneratedOnAddOrUpdate();

            // Relationships

            builder.HasMany<BookReferenceAuthor>(a => a.Books)
                .WithOne(bra => bra.Author);
        }
    }
}