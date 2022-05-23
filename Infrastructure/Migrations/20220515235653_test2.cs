using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                schema: "dbo",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "paymentType",
                schema: "dbo",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserBalanceEntity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    balance = table.Column<double>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBalanceEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBalanceEntity_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 16, 3, 56, 52, 754, DateTimeKind.Local).AddTicks(7927));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 16, 3, 56, 52, 754, DateTimeKind.Local).AddTicks(7938));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 16, 3, 56, 52, 754, DateTimeKind.Local).AddTicks(8127));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 16, 3, 56, 52, 754, DateTimeKind.Local).AddTicks(8128));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt", "Verified" },
                values: new object[] { "vWgp3VVmtVvmlqKF/wAopfv00jeVWHLBy4CAriTHoJ4=", "wAyNEGnlGf3Of37FPq7ISw==", new DateTime(2022, 5, 16, 3, 56, 52, 769, DateTimeKind.Local).AddTicks(7392) });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserBalanceEntity",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "UserId", "balance" },
                values: new object[] { 1, new DateTime(2022, 5, 16, 3, 56, 52, 771, DateTimeKind.Local).AddTicks(6236), null, 1, 1.0 });

            migrationBuilder.CreateIndex(
                name: "IX_UserBalanceEntity_UserId",
                schema: "dbo",
                table: "UserBalanceEntity",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBalanceEntity",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                schema: "dbo",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "paymentType",
                schema: "dbo",
                table: "Transactions");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 16, 1, 41, 5, 694, DateTimeKind.Local).AddTicks(4598));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 16, 1, 41, 5, 694, DateTimeKind.Local).AddTicks(4608));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 16, 1, 41, 5, 694, DateTimeKind.Local).AddTicks(4787));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 16, 1, 41, 5, 694, DateTimeKind.Local).AddTicks(4788));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt", "Verified" },
                values: new object[] { "ZOq8IjqEpX5NKEaBqN8dTr/Up8IT9a8kg9Dqjs5VLSk=", "Y+aEHkUVwCN9pO6AoeLk4Q==", new DateTime(2022, 5, 16, 1, 41, 5, 708, DateTimeKind.Local).AddTicks(8762) });
        }
    }
}
