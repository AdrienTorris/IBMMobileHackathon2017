using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Catalog.API.Infrastructure.CatalogContextMigrations
{
    public partial class ConvertISBNFromIntToLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Publisher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 655, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 603, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Publisher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 655, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 603, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "BookReference",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 644, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 591, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "BookReference",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 641, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 588, DateTimeKind.Local));

            migrationBuilder.AlterColumn<long>(
                name: "ISBN",
                table: "BookReference",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "BookItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 649, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 596, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "BookItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 649, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 596, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 652, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 600, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 652, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 600, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Publisher",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 603, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 655, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Publisher",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 603, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 655, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "BookReference",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 591, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 644, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "BookReference",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 588, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 641, DateTimeKind.Local));

            migrationBuilder.AlterColumn<int>(
                name: "ISBN",
                table: "BookReference",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "BookItem",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 596, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 649, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "BookItem",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 596, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 649, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Author",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 600, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 652, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Author",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 6, 13, 36, 57, 600, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 10, 12, 41, 34, 652, DateTimeKind.Local));
        }
    }
}
