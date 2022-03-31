using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "GameVisits",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "GamesReview",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameVisits",
                schema: "dbo",
                table: "GameVisits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamesReview",
                schema: "dbo",
                table: "GamesReview",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 3, 26, 2, 32, 53, 319, DateTimeKind.Local).AddTicks(5218));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 3, 26, 2, 32, 53, 319, DateTimeKind.Local).AddTicks(5220));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 3, 26, 2, 32, 53, 319, DateTimeKind.Local).AddTicks(5094));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 3, 26, 2, 32, 53, 319, DateTimeKind.Local).AddTicks(5104));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GameVisits",
                schema: "dbo",
                table: "GameVisits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GamesReview",
                schema: "dbo",
                table: "GamesReview");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "GameVisits");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "GamesReview");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 3, 24, 5, 8, 43, 727, DateTimeKind.Local).AddTicks(5691));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 3, 24, 5, 8, 43, 727, DateTimeKind.Local).AddTicks(5693));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 3, 24, 5, 8, 43, 727, DateTimeKind.Local).AddTicks(5521));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 3, 24, 5, 8, 43, 727, DateTimeKind.Local).AddTicks(5532));
        }
    }
}
