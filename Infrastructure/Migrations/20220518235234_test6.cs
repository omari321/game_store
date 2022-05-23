using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class test6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                schema: "dbo",
                table: "VideogameImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 52, 33, 969, DateTimeKind.Local).AddTicks(1358));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 52, 33, 953, DateTimeKind.Local).AddTicks(2799));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 52, 33, 953, DateTimeKind.Local).AddTicks(2808));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 52, 33, 953, DateTimeKind.Local).AddTicks(3023));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 52, 33, 953, DateTimeKind.Local).AddTicks(3025));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 52, 33, 969, DateTimeKind.Local).AddTicks(1179));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt", "Verified" },
                values: new object[] { "8K/07eBeRyFK4nldE3O2HCrHEC1yDIUEz7MPCKtaQoI=", "/Ec8xN+gEaDy5OLCSJWmaw==", new DateTime(2022, 5, 19, 3, 52, 33, 967, DateTimeKind.Local).AddTicks(4203) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserBalance",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 52, 33, 969, DateTimeKind.Local).AddTicks(1011));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Videogame",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 52, 33, 969, DateTimeKind.Local).AddTicks(1286));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "VideogameCategory",
                keyColumns: new[] { "CategoryId", "VideogameId" },
                keyValues: new object[] { 1, 1 },
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 52, 33, 969, DateTimeKind.Local).AddTicks(1428));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                schema: "dbo",
                table: "VideogameImages");

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
    }
}
