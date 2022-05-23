using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailUrl",
                schema: "dbo",
                table: "Videogame",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailPath",
                schema: "dbo",
                table: "Videogame",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 24, 6, 766, DateTimeKind.Local).AddTicks(6416));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 24, 6, 750, DateTimeKind.Local).AddTicks(3481));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 24, 6, 750, DateTimeKind.Local).AddTicks(3495));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 24, 6, 750, DateTimeKind.Local).AddTicks(3723));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 24, 6, 750, DateTimeKind.Local).AddTicks(3725));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 24, 6, 766, DateTimeKind.Local).AddTicks(6147));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt", "Verified" },
                values: new object[] { "YTUTx9yEMxyjx+/QnFx6SWo/loqmqmpbJI+IU17uGOQ=", "Y+thTlETJKl0bB2RmNpUjA==", new DateTime(2022, 5, 19, 3, 24, 6, 764, DateTimeKind.Local).AddTicks(2713) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserBalance",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 24, 6, 766, DateTimeKind.Local).AddTicks(5898));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Videogame",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 24, 6, 766, DateTimeKind.Local).AddTicks(6300));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "VideogameCategory",
                keyColumns: new[] { "CategoryId", "VideogameId" },
                keyValues: new object[] { 1, 1 },
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 24, 6, 766, DateTimeKind.Local).AddTicks(6572));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailPath",
                schema: "dbo",
                table: "Videogame");

            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailUrl",
                schema: "dbo",
                table: "Videogame",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 18, 4, 0, 55, 168, DateTimeKind.Local).AddTicks(3767));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 18, 4, 0, 55, 152, DateTimeKind.Local).AddTicks(3054));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 18, 4, 0, 55, 152, DateTimeKind.Local).AddTicks(3064));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 18, 4, 0, 55, 152, DateTimeKind.Local).AddTicks(3302));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 18, 4, 0, 55, 152, DateTimeKind.Local).AddTicks(3304));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 18, 4, 0, 55, 168, DateTimeKind.Local).AddTicks(3595));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt", "Verified" },
                values: new object[] { "ZbrVjd0NWSImapaAq5igKMHK7BsHJqSU2z/TVZJs5RI=", "8EziRLHQek1WJ2tBB1XT1g==", new DateTime(2022, 5, 18, 4, 0, 55, 166, DateTimeKind.Local).AddTicks(4711) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserBalance",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 18, 4, 0, 55, 168, DateTimeKind.Local).AddTicks(3480));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Videogame",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 18, 4, 0, 55, 168, DateTimeKind.Local).AddTicks(3696));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "VideogameCategory",
                keyColumns: new[] { "CategoryId", "VideogameId" },
                keyValues: new object[] { 1, 1 },
                column: "DateCreated",
                value: new DateTime(2022, 5, 18, 4, 0, 55, 168, DateTimeKind.Local).AddTicks(3848));
        }
    }
}
