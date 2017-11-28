using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Catalog.API.Infrastructure.CatalogContextMigrations
{
    public partial class AddAvailabilityOnItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Publisher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 21, 22, 37, 21, 195, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 655, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Publisher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 21, 22, 37, 21, 195, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 655, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "BookReference",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 21, 22, 37, 21, 181, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 644, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "BookReference",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 21, 22, 37, 21, 178, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 641, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "BookItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 21, 22, 37, 21, 188, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 649, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "BookItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 21, 22, 37, 21, 188, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 649, DateTimeKind.Local));

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "BookItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 21, 22, 37, 21, 192, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 652, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 21, 22, 37, 21, 192, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 652, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "BookItem");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Publisher",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 655, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 21, 22, 37, 21, 195, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Publisher",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 655, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 21, 22, 37, 21, 195, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "BookReference",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 644, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 21, 22, 37, 21, 181, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "BookReference",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 641, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 21, 22, 37, 21, 178, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "BookItem",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 649, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 21, 22, 37, 21, 188, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "BookItem",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 649, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 21, 22, 37, 21, 188, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Author",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 652, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 21, 22, 37, 21, 192, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Author",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 652, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 21, 22, 37, 21, 192, DateTimeKind.Local));
        }
    }
}
