using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Catalog.API.Infrastructure.CatalogContextMigrations
{
    public partial class AddMultipleRelationshipBetweenBooksAndAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_BookReference_BookReferenceId",
                table: "Author");

            migrationBuilder.DropForeignKey(
                name: "FK_BookReference_Author_AuthorId",
                table: "BookReference");

            migrationBuilder.DropIndex(
                name: "IX_BookReference_AuthorId",
                table: "BookReference");

            migrationBuilder.DropIndex(
                name: "IX_Author_BookReferenceId",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "BookReference");

            migrationBuilder.DropColumn(
                name: "BookReferenceId",
                table: "Author");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Publisher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 603, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 802, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Publisher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 603, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 802, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "BookReference",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 591, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 791, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "BookReference",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 588, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 788, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "BookItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 596, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 796, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "BookItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 596, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 796, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 600, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 799, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 600, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 799, DateTimeKind.Local));

            migrationBuilder.CreateTable(
                name: "BookReferenceAuthor",
                columns: table => new
                {
                    BookReferenceId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReferenceAuthor", x => new { x.BookReferenceId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_BookReferenceAuthor_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookReferenceAuthor_BookReference_BookReferenceId",
                        column: x => x.BookReferenceId,
                        principalTable: "BookReference",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookReferenceAuthor_AuthorId",
                table: "BookReferenceAuthor",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookReferenceAuthor");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Publisher",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 802, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 603, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Publisher",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 802, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 603, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "BookReference",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 791, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 591, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "BookReference",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 788, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 588, DateTimeKind.Local));

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "BookReference",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "BookItem",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 796, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 596, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "BookItem",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 796, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 596, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Author",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 799, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 600, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Author",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 799, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 600, DateTimeKind.Local));

            migrationBuilder.AddColumn<int>(
                name: "BookReferenceId",
                table: "Author",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookReference_AuthorId",
                table: "BookReference",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Author_BookReferenceId",
                table: "Author",
                column: "BookReferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_BookReference_BookReferenceId",
                table: "Author",
                column: "BookReferenceId",
                principalTable: "BookReference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookReference_Author_AuthorId",
                table: "BookReference",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
