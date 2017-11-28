﻿// <auto-generated />
using IBM.Books.Catalog.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Catalog.API.Infrastructure.CatalogContextMigrations
{
    [DbContext(typeof(CatalogContext))]
    partial class CatalogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("Relational:Sequence:.author_hilo", "'author_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.book_item_hilo", "'book_item_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.book_reference_hilo", "'book_reference_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.publisher_hilo", "'publisher_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IBM.Books.Catalog.API.DomainModel.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "author_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<DateTime>("InsertedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 10, 21, 22, 37, 21, 192, DateTimeKind.Local));

                    b.Property<string>("LastName")
                        .HasMaxLength(80);

                    b.Property<DateTime>("LastUpdatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValue(new DateTime(2017, 10, 21, 22, 37, 21, 192, DateTimeKind.Local));

                    b.Property<string>("NormalizedFirstName")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("NormalizedLastName")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("IBM.Books.Catalog.API.DomainModel.BookItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "book_item_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<DateTime>("InsertedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 10, 21, 22, 37, 21, 188, DateTimeKind.Local));

                    b.Property<bool>("IsAvailable");

                    b.Property<DateTime>("LastUpdatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValue(new DateTime(2017, 10, 21, 22, 37, 21, 188, DateTimeKind.Local));

                    b.Property<int>("OwnerId");

                    b.Property<string>("OwnerRemarks")
                        .HasMaxLength(320);

                    b.Property<int>("ReferenceId");

                    b.HasKey("Id");

                    b.HasIndex("ReferenceId");

                    b.ToTable("BookItem");
                });

            modelBuilder.Entity("IBM.Books.Catalog.API.DomainModel.BookReference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "book_reference_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Description");

                    b.Property<long>("ISBN");

                    b.Property<string>("Image");

                    b.Property<DateTime>("InsertedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 10, 21, 22, 37, 21, 178, DateTimeKind.Local));

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<DateTime>("LastUpdatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValue(new DateTime(2017, 10, 21, 22, 37, 21, 181, DateTimeKind.Local));

                    b.Property<string>("NormalizedTitle")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<int>("PageCount");

                    b.Property<int>("PrintedPageCount");

                    b.Property<DateTime>("PublishedDate");

                    b.Property<int>("PublisherId");

                    b.Property<int>("Source");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("BookReference");
                });

            modelBuilder.Entity("IBM.Books.Catalog.API.DomainModel.BookReferenceAuthor", b =>
                {
                    b.Property<int>("BookReferenceId");

                    b.Property<int>("AuthorId");

                    b.HasKey("BookReferenceId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookReferenceAuthor");
                });

            modelBuilder.Entity("IBM.Books.Catalog.API.DomainModel.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "publisher_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<DateTime>("InsertedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 10, 21, 22, 37, 21, 195, DateTimeKind.Local));

                    b.Property<DateTime>("LastUpdatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValue(new DateTime(2017, 10, 21, 22, 37, 21, 195, DateTimeKind.Local));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("IBM.Books.Catalog.API.DomainModel.BookItem", b =>
                {
                    b.HasOne("IBM.Books.Catalog.API.DomainModel.BookReference", "Reference")
                        .WithMany("Items")
                        .HasForeignKey("ReferenceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IBM.Books.Catalog.API.DomainModel.BookReference", b =>
                {
                    b.HasOne("IBM.Books.Catalog.API.DomainModel.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IBM.Books.Catalog.API.DomainModel.BookReferenceAuthor", b =>
                {
                    b.HasOne("IBM.Books.Catalog.API.DomainModel.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IBM.Books.Catalog.API.DomainModel.BookReference", "BookReference")
                        .WithMany("Authors")
                        .HasForeignKey("BookReferenceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
