namespace IBM.Books.Messaging.API.Infrastructure.EntityConfigurations
{
    using IBM.Books.Messaging.API.DomainModel;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    class MessageEntityTypeConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable(nameof(Message));

            builder.HasKey(bi => bi.Id);

            builder.Property(bi => bi.Id)
               .ForSqlServerUseSequenceHiLo("message_hilo")
               .IsRequired();

            builder.Property(bi => bi.SenderId)
                .IsRequired();

            builder.Property(bi => bi.ReceiverId)
                .IsRequired();

            builder.Property(bi => bi.Status)
                .IsRequired();

            builder.Property(bi => bi.Content)
                .IsRequired(true)
                .HasMaxLength(800);

            builder.Property(bi => bi.BookItemId)
                .IsRequired(false);

            builder.Property(br => br.InsertedDate)
                .IsRequired()
                .HasDefaultValue<DateTime>(DateTime.Now)
                .ValueGeneratedOnAdd();

            builder.Property(br => br.LastUpdatedDate)
                .IsRequired()
                .HasDefaultValue<DateTime>(DateTime.Now)
                .ValueGeneratedOnAddOrUpdate();

            // Relationships
        }
    }
}