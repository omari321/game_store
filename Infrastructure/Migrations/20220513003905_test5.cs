using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 13, 4, 39, 5, 364, DateTimeKind.Local).AddTicks(9391));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 13, 4, 39, 5, 364, DateTimeKind.Local).AddTicks(9401));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 13, 4, 39, 5, 364, DateTimeKind.Local).AddTicks(9591));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 13, 4, 39, 5, 364, DateTimeKind.Local).AddTicks(9593));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt", "Verified" },
                values: new object[] { "w64WeP4KxriUBxQJIbCl1V1U10PdKvobXXUNkj/8ZTs=", "Gyg5UOAeWdsD3myAupeBvA==", new DateTime(2022, 5, 13, 4, 39, 5, 379, DateTimeKind.Local).AddTicks(6529) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 12, 23, 6, 13, 913, DateTimeKind.Local).AddTicks(7391));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 12, 23, 6, 13, 913, DateTimeKind.Local).AddTicks(7403));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 12, 23, 6, 13, 913, DateTimeKind.Local).AddTicks(7734));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 12, 23, 6, 13, 913, DateTimeKind.Local).AddTicks(7737));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt", "Verified" },
                values: new object[] { "T5/m3SNLrZYW2V4XXE7/1O45oVHKRSCduGOG7ThKlqQ=", "pDzC/S+MlJ5bKZwI9+PqGg==", new DateTime(2022, 5, 12, 23, 6, 13, 929, DateTimeKind.Local).AddTicks(9515) });
        }
    }
}
