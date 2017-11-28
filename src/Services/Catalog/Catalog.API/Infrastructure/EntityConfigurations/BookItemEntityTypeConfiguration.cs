namespace IBM.Books.Catalog.API.Infrastructure.EntityConfigurations
{
    using IBM.Books.Catalog.API.DomainModel;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    class BookItemEntityTypeConfiguration : IEntityTypeConfiguration<BookItem>
    {
        public void Configure(EntityTypeBuilder<BookItem> builder)
        {
            builder.ToTable(nameof(BookItem));

            builder.HasKey(bi => bi.Id);

            builder.Property(bi => bi.Id)
               .ForSqlServerUseSequenceHiLo("book_item_hilo")
               .IsRequired();

            builder.Property(bi => bi.OwnerId)
                .IsRequired();

            builder.Property(bi => bi.ReferenceId)
                .IsRequired();

            builder.Property(bi => bi.IsAvailable)
                .IsRequired();

            builder.Property(bi => bi.OwnerRemarks)
                .IsRequired(false)
                .HasMaxLength(320);

            builder.Property(br => br.InsertedDate)
                .IsRequired()
                .HasDefaultValue<DateTime>(DateTime.Now)
                .ValueGeneratedOnAdd();

            builder.Property(br => br.LastUpdatedDate)
                .IsRequired()
                .HasDefaultValue<DateTime>(DateTime.Now)
                .ValueGeneratedOnAddOrUpdate();

            // Relationships

            builder.HasOne<BookReference>(bi => bi.Reference)
                .WithMany(br => br.Items);
        }
    }
}