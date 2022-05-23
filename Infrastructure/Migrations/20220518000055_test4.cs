using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "paymentType",
                schema: "dbo",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Category",
                columns: new[] { "Id", "CategoryName", "DateCreated", "DateUpdated" },
                values: new object[] { 1, "moba", new DateTime(2022, 5, 18, 4, 0, 55, 168, DateTimeKind.Local).AddTicks(3767), null });

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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Videogame",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "DownloadFileUrl", "OldPrice", "Price", "PublicsherId", "ThumbnailUrl", "VideogameName" },
                values: new object[] { 1, new DateTime(2022, 5, 18, 4, 0, 55, 168, DateTimeKind.Local).AddTicks(3696), null, "Mobile battle arena where 10 players play vs each other in teams of 5", null, null, 0.0, 1, null, "dota2" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "VideogameCategory",
                columns: new[] { "CategoryId", "VideogameId", "DateCreated", "DateUpdated" },
                values: new object[] { 1, 1, new DateTime(2022, 5, 18, 4, 0, 55, 168, DateTimeKind.Local).AddTicks(3848), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "VideogameCategory",
                keyColumns: new[] { "CategoryId", "VideogameId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Videogame",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "paymentType",
                schema: "dbo",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 18, 3, 46, 30, 850, DateTimeKind.Local).AddTicks(8623));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 18, 3, 46, 30, 850, DateTimeKind.Local).AddTicks(8636));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 18, 3, 46, 30, 850, DateTimeKind.Local).AddTicks(8834));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 18, 3, 46, 30, 850, DateTimeKind.Local).AddTicks(8835));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 18, 3, 46, 30, 868, DateTimeKind.Local).AddTicks(628));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt", "Verified" },
                values: new object[] { "zrSB6ON+EWPgi7NQKPwjybvyMKmz6gF/OfnoMxWX+xs=", "LHCs0g7btpF1VXZJ+HMh9g==", new DateTime(2022, 5, 18, 3, 46, 30, 865, DateTimeKind.Local).AddTicks(8814) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserBalance",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 18, 3, 46, 30, 868, DateTimeKind.Local).AddTicks(470));
        }
    }
}
