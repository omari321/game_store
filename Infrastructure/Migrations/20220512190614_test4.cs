using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MailSent",
                schema: "dbo",
                table: "User",
                type: "datetime2",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MailSent",
                schema: "dbo",
                table: "User");

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
    }
}
