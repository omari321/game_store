using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideogameCategory_Videogame_GameId",
                schema: "dbo",
                table: "VideogameCategory");

            migrationBuilder.DropIndex(
                name: "IX_VideogameCategory_GameId",
                schema: "dbo",
                table: "VideogameCategory");

            migrationBuilder.DropColumn(
                name: "GameId",
                schema: "dbo",
                table: "VideogameCategory");

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

            migrationBuilder.AddForeignKey(
                name: "FK_VideogameCategory_Videogame_VideogameId",
                schema: "dbo",
                table: "VideogameCategory",
                column: "VideogameId",
                principalSchema: "dbo",
                principalTable: "Videogame",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideogameCategory_Videogame_VideogameId",
                schema: "dbo",
                table: "VideogameCategory");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                schema: "dbo",
                table: "VideogameCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 5, 5, 47, 4, 262, DateTimeKind.Local).AddTicks(4285));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 5, 5, 47, 4, 262, DateTimeKind.Local).AddTicks(4295));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 5, 5, 47, 4, 262, DateTimeKind.Local).AddTicks(4490));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 5, 5, 47, 4, 262, DateTimeKind.Local).AddTicks(4492));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt", "Verified" },
                values: new object[] { "3PtISEJDqaOI1xgzGHYzpkGCbshwLgq7K0Y/0gPObsU=", "mT/0MRWlzYAGTlz4Me+mzw==", new DateTime(2022, 5, 5, 5, 47, 4, 277, DateTimeKind.Local).AddTicks(1303) });

            migrationBuilder.CreateIndex(
                name: "IX_VideogameCategory_GameId",
                schema: "dbo",
                table: "VideogameCategory",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_VideogameCategory_Videogame_GameId",
                schema: "dbo",
                table: "VideogameCategory",
                column: "GameId",
                principalSchema: "dbo",
                principalTable: "Videogame",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
