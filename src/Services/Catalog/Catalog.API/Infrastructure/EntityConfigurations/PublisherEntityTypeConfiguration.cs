namespace IBM.Books.Catalog.API.Infrastructure.EntityConfigurations
{
    using IBM.Books.Catalog.API.DomainModel;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    class PublisherEntityTypeConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.ToTable(nameof(Publisher));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
               .ForSqlServerUseSequenceHiLo("publisher_hilo")
               .IsRequired();

            builder.Property(p => p.Name)
                .IsRequired(true)
                .HasMaxLength(80);

            builder.Property(p => p.NormalizedName)
                .IsRequired(true)
                .HasMaxLength(80);

            builder.Property(p => p.InsertedDate)
                .IsRequired()
                .HasDefaultValue<DateTime>(DateTime.Now)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.LastUpdatedDate)
                .IsRequired()
                .HasDefaultValue<DateTime>(DateTime.Now)
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}