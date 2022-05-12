using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 12, 21, 35, 1, 246, DateTimeKind.Local).AddTicks(6319));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 12, 21, 35, 1, 246, DateTimeKind.Local).AddTicks(6328));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 12, 21, 35, 1, 246, DateTimeKind.Local).AddTicks(6543));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 12, 21, 35, 1, 246, DateTimeKind.Local).AddTicks(6545));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt", "Verified" },
                values: new object[] { "e2FcKkUxmCNDwZ+VdoRkbL0v1ae4q9S+LkH59o+80LE=", "iLROhq0dPwQl569lm9szTQ==", new DateTime(2022, 5, 12, 21, 35, 1, 262, DateTimeKind.Local).AddTicks(1668) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 12, 5, 10, 43, 607, DateTimeKind.Local).AddTicks(5292));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 12, 5, 10, 43, 607, DateTimeKind.Local).AddTicks(5306));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 12, 5, 10, 43, 607, DateTimeKind.Local).AddTicks(5513));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 12, 5, 10, 43, 607, DateTimeKind.Local).AddTicks(5514));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt", "Verified" },
                values: new object[] { "SasID+4Izl12BnH710fbEoQ/xJxU45JnMtg+Y9KaPBE=", "LQWDkig25xGtqw2tKj7Cng==", new DateTime(2022, 5, 12, 5, 10, 43, 622, DateTimeKind.Local).AddTicks(6305) });
        }
    }
}
