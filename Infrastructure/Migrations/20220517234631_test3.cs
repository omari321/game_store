using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Videogame_VideogameId",
                schema: "dbo",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBalanceEntity_User_UserId",
                schema: "dbo",
                table: "UserBalanceEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBalanceEntity",
                schema: "dbo",
                table: "UserBalanceEntity");

            migrationBuilder.RenameTable(
                name: "UserBalanceEntity",
                schema: "dbo",
                newName: "UserBalance",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "VideogameId",
                schema: "dbo",
                table: "Transactions",
                newName: "VideogameEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_VideogameId",
                schema: "dbo",
                table: "Transactions",
                newName: "IX_Transactions_VideogameEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBalanceEntity_UserId",
                schema: "dbo",
                table: "UserBalance",
                newName: "IX_UserBalance_UserId");

            migrationBuilder.AddColumn<string>(
                name: "TransactionDescription",
                schema: "dbo",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "transactionType",
                schema: "dbo",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBalance",
                schema: "dbo",
                table: "UserBalance",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GameTransactionHistory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transactionId = table.Column<int>(type: "int", nullable: false),
                    VideogameId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTransactionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameTransactionHistory_Transactions_transactionId",
                        column: x => x.transactionId,
                        principalSchema: "dbo",
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameTransactionHistory_Videogame_VideogameId",
                        column: x => x.VideogameId,
                        principalSchema: "dbo",
                        principalTable: "Videogame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Publisher",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "PublisherName" },
                values: new object[] { 1, new DateTime(2022, 5, 18, 3, 46, 30, 868, DateTimeKind.Local).AddTicks(628), null, "valve" });

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
                columns: new[] { "DateCreated", "balance" },
                values: new object[] { new DateTime(2022, 5, 18, 3, 46, 30, 868, DateTimeKind.Local).AddTicks(470), 0.0 });

            migrationBuilder.CreateIndex(
                name: "IX_GameTransactionHistory_transactionId",
                schema: "dbo",
                table: "GameTransactionHistory",
                column: "transactionId");

            migrationBuilder.CreateIndex(
                name: "IX_GameTransactionHistory_VideogameId",
                schema: "dbo",
                table: "GameTransactionHistory",
                column: "VideogameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Videogame_VideogameEntityId",
                schema: "dbo",
                table: "Transactions",
                column: "VideogameEntityId",
                principalSchema: "dbo",
                principalTable: "Videogame",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBalance_User_UserId",
                schema: "dbo",
                table: "UserBalance",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Videogame_VideogameEntityId",
                schema: "dbo",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBalance_User_UserId",
                schema: "dbo",
                table: "UserBalance");

            migrationBuilder.DropTable(
                name: "GameTransactionHistory",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBalance",
                schema: "dbo",
                table: "UserBalance");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "TransactionDescription",
                schema: "dbo",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "transactionType",
                schema: "dbo",
                table: "Transactions");

            migrationBuilder.RenameTable(
                name: "UserBalance",
                schema: "dbo",
                newName: "UserBalanceEntity",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "VideogameEntityId",
                schema: "dbo",
                table: "Transactions",
                newName: "VideogameId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_VideogameEntityId",
                schema: "dbo",
                table: "Transactions",
                newName: "IX_Transactions_VideogameId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBalance_UserId",
                schema: "dbo",
                table: "UserBalanceEntity",
                newName: "IX_UserBalanceEntity_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBalanceEntity",
                schema: "dbo",
                table: "UserBalanceEntity",
                column: "Id");

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

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserBalanceEntity",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "balance" },
                values: new object[] { new DateTime(2022, 5, 16, 3, 56, 52, 771, DateTimeKind.Local).AddTicks(6236), 1.0 });

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Videogame_VideogameId",
                schema: "dbo",
                table: "Transactions",
                column: "VideogameId",
                principalSchema: "dbo",
                principalTable: "Videogame",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBalanceEntity_User_UserId",
                schema: "dbo",
                table: "UserBalanceEntity",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
