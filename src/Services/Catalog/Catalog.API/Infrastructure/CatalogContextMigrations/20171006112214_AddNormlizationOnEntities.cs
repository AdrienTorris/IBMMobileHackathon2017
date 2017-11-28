using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Catalog.API.Infrastructure.CatalogContextMigrations
{
    public partial class AddNormlizationOnEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookReference_Publisher_PublisherId",
                table: "BookReference");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Publisher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 802, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 612, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Publisher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 802, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 612, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                table: "Publisher",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "PublisherId",
                table: "BookReference",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "BookReference",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 791, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 602, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "BookReference",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 788, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 598, DateTimeKind.Local));

            migrationBuilder.AddColumn<int>(
                name: "Source",
                table: "BookReference",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "BookItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 796, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 607, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "BookItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 796, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 607, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 799, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 609, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 799, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 609, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "NormalizedFirstName",
                table: "Author",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedLastName",
                table: "Author",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookReference_Publisher_PublisherId",
                table: "BookReference",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookReference_Publisher_PublisherId",
                table: "BookReference");

            migrationBuilder.DropColumn(
                name: "NormalizedName",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "BookReference");

            migrationBuilder.DropColumn(
                name: "NormalizedFirstName",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "NormalizedLastName",
                table: "Author");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Publisher",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 612, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 802, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Publisher",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 612, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 802, DateTimeKind.Local));

            migrationBuilder.AlterColumn<int>(
                name: "PublisherId",
                table: "BookReference",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "BookReference",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 602, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 791, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "BookReference",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 598, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 788, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "BookItem",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 607, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 796, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "BookItem",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 607, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 796, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Author",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 609, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 799, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Author",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 12, 37, 25, 609, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 22, 14, 799, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_BookReference_Publisher_PublisherId",
                table: "BookReference",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
