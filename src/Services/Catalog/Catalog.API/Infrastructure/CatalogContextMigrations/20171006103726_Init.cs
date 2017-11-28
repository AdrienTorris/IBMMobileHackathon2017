using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Catalog.API.Infrastructure.CatalogContextMigrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "author_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "book_item_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "book_reference_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "publisher_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 612, DateTimeKind.Local)),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 612, DateTimeKind.Local)),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookReference",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISBN = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 598, DateTimeKind.Local)),
                    Language = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 602, DateTimeKind.Local)),
                    NormalizedTitle = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    PrintedPageCount = table.Column<int>(type: "int", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookReference_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BookReferenceId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 609, DateTimeKind.Local)),
                    LastName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 609, DateTimeKind.Local))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Author_BookReference_BookReferenceId",
                        column: x => x.BookReferenceId,
                        principalTable: "BookReference",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 607, DateTimeKind.Local)),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 607, DateTimeKind.Local)),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    OwnerRemarks = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: true),
                    ReferenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookItem_BookReference_ReferenceId",
                        column: x => x.ReferenceId,
                        principalTable: "BookReference",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Author_BookReferenceId",
                table: "Author",
                column: "BookReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_BookItem_ReferenceId",
                table: "BookItem",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReference_AuthorId",
                table: "BookReference",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReference_PublisherId",
                table: "BookReference",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookReference_Author_AuthorId",
                table: "BookReference",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_BookReference_BookReferenceId",
                table: "Author");

            migrationBuilder.DropTable(
                name: "BookItem");

            migrationBuilder.DropTable(
                name: "BookReference");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropSequence(
                name: "author_hilo");

            migrationBuilder.DropSequence(
                name: "book_item_hilo");

            migrationBuilder.DropSequence(
                name: "book_reference_hilo");

            migrationBuilder.DropSequence(
                name: "publisher_hilo");
        }
    }
}
