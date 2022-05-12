using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class longtimenoSee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlatformId",
                schema: "dbo",
                table: "Videogame");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                schema: "dbo",
                table: "Videogame",
                newName: "ThumbnailUrl");

            migrationBuilder.AddColumn<string>(
                name: "DownloadFileUrl",
                schema: "dbo",
                table: "Videogame",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OwnedGames",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideogameId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnedGames_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnedGames_Videogame_VideogameId",
                        column: x => x.VideogameId,
                        principalSchema: "dbo",
                        principalTable: "Videogame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentCreditentials",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CSV = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserEntityId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentCreditentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentCreditentials_User_UserEntityId",
                        column: x => x.UserEntityId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideogameId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PayedAmount = table.Column<double>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Videogame_VideogameId",
                        column: x => x.VideogameId,
                        principalSchema: "dbo",
                        principalTable: "Videogame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideogameImages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideogameId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideogameImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideogameImages_Videogame_VideogameId",
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

            migrationBuilder.CreateIndex(
                name: "IX_OwnedGames_UserId",
                schema: "dbo",
                table: "OwnedGames",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedGames_VideogameId",
                schema: "dbo",
                table: "OwnedGames",
                column: "VideogameId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentCreditentials_UserEntityId",
                schema: "dbo",
                table: "PaymentCreditentials",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                schema: "dbo",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_VideogameId",
                schema: "dbo",
                table: "Transactions",
                column: "VideogameId");

            migrationBuilder.CreateIndex(
                name: "IX_VideogameImages_VideogameId",
                schema: "dbo",
                table: "VideogameImages",
                column: "VideogameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnedGames",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PaymentCreditentials",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Transactions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VideogameImages",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "DownloadFileUrl",
                schema: "dbo",
                table: "Videogame");

            migrationBuilder.RenameColumn(
                name: "ThumbnailUrl",
                schema: "dbo",
                table: "Videogame",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<int>(
                name: "PlatformId",
                schema: "dbo",
                table: "Videogame",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 5, 22, 53, 25, 889, DateTimeKind.Local).AddTicks(2800));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 5, 22, 53, 25, 889, DateTimeKind.Local).AddTicks(2812));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 5, 22, 53, 25, 889, DateTimeKind.Local).AddTicks(2982));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 5, 22, 53, 25, 889, DateTimeKind.Local).AddTicks(2984));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt", "Verified" },
                values: new object[] { "VKyRBHt9qXbYVjS8mGcDiYkB/6ALNPiXiOB58jDJdl0=", "XkeKegH7vYyxrY1ux+u2sQ==", new DateTime(2022, 5, 5, 22, 53, 25, 903, DateTimeKind.Local).AddTicks(7764) });
        }
    }
}
