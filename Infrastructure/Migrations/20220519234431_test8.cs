using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class test8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideogameFiles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideogameId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideogameFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    UserEntityId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideogameFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideogameFiles_User_UserEntityId",
                        column: x => x.UserEntityId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VideogameFiles_Videogame_VideogameId",
                        column: x => x.VideogameId,
                        principalSchema: "dbo",
                        principalTable: "Videogame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 20, 3, 44, 30, 446, DateTimeKind.Local).AddTicks(12));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 20, 3, 44, 30, 430, DateTimeKind.Local).AddTicks(862));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 20, 3, 44, 30, 430, DateTimeKind.Local).AddTicks(872));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 20, 3, 44, 30, 430, DateTimeKind.Local).AddTicks(1045));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 20, 3, 44, 30, 430, DateTimeKind.Local).AddTicks(1047));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 20, 3, 44, 30, 445, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt", "Verified" },
                values: new object[] { "LzRuUFhWpGfRyjziS05djRa6sjwA48b11CcZ+cKzkZM=", "eEOZcZvC9Si06CXuhW6gLQ==", new DateTime(2022, 5, 20, 3, 44, 30, 444, DateTimeKind.Local).AddTicks(1412) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserBalance",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 20, 3, 44, 30, 445, DateTimeKind.Local).AddTicks(9724));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Videogame",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 20, 3, 44, 30, 445, DateTimeKind.Local).AddTicks(9938));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "VideogameCategory",
                keyColumns: new[] { "CategoryId", "VideogameId" },
                keyValues: new object[] { 1, 1 },
                column: "DateCreated",
                value: new DateTime(2022, 5, 20, 3, 44, 30, 446, DateTimeKind.Local).AddTicks(95));

            migrationBuilder.CreateIndex(
                name: "IX_VideogameFiles_UserEntityId",
                schema: "dbo",
                table: "VideogameFiles",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_VideogameFiles_VideogameId",
                schema: "dbo",
                table: "VideogameFiles",
                column: "VideogameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideogameFiles",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 20, 1, 9, 51, 695, DateTimeKind.Local).AddTicks(4442));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 20, 1, 9, 51, 679, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 20, 1, 9, 51, 679, DateTimeKind.Local).AddTicks(8060));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 20, 1, 9, 51, 679, DateTimeKind.Local).AddTicks(8256));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 20, 1, 9, 51, 679, DateTimeKind.Local).AddTicks(8257));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 20, 1, 9, 51, 695, DateTimeKind.Local).AddTicks(4274));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt", "Verified" },
                values: new object[] { "4a0CHoVTXHSaXGpX0kHWiRV2s6Hx3suEYfcPgt9cDIM=", "4Tn/9w3bmQ+AJ6Amy4l8nQ==", new DateTime(2022, 5, 20, 1, 9, 51, 693, DateTimeKind.Local).AddTicks(7472) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserBalance",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 20, 1, 9, 51, 695, DateTimeKind.Local).AddTicks(4178));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Videogame",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 20, 1, 9, 51, 695, DateTimeKind.Local).AddTicks(4371));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "VideogameCategory",
                keyColumns: new[] { "CategoryId", "VideogameId" },
                keyValues: new object[] { 1, 1 },
                column: "DateCreated",
                value: new DateTime(2022, 5, 20, 1, 9, 51, 695, DateTimeKind.Local).AddTicks(4508));
        }
    }
}
