using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class test11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideogameRequirements",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideogameId = table.Column<int>(type: "int", nullable: false),
                    MinRequirements = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecomendedRequirements = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideogameRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideogameRequirements_Videogame_VideogameId",
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
                value: new DateTime(2022, 5, 23, 3, 12, 30, 995, DateTimeKind.Local).AddTicks(8127));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 23, 3, 12, 30, 979, DateTimeKind.Local).AddTicks(9439));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 23, 3, 12, 30, 979, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 23, 3, 12, 30, 979, DateTimeKind.Local).AddTicks(9631));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 23, 3, 12, 30, 979, DateTimeKind.Local).AddTicks(9633));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 23, 3, 12, 30, 995, DateTimeKind.Local).AddTicks(7966));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt", "Verified" },
                values: new object[] { "TDYB9VTGXgVK37xtrTT/UpfWFuCsq338ISblbQafP7A=", "U5++OplSHmOYBezCt27MNQ==", new DateTime(2022, 5, 23, 3, 12, 30, 994, DateTimeKind.Local).AddTicks(2804) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserBalance",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 23, 3, 12, 30, 995, DateTimeKind.Local).AddTicks(7849));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Videogame",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 23, 3, 12, 30, 995, DateTimeKind.Local).AddTicks(8048));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "VideogameCategory",
                keyColumns: new[] { "CategoryId", "VideogameId" },
                keyValues: new object[] { 1, 1 },
                column: "DateCreated",
                value: new DateTime(2022, 5, 23, 3, 12, 30, 995, DateTimeKind.Local).AddTicks(8206));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "VideogameLikes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 23, 3, 12, 30, 995, DateTimeKind.Local).AddTicks(8282));

            migrationBuilder.CreateIndex(
                name: "IX_VideogameRequirements_VideogameId",
                schema: "dbo",
                table: "VideogameRequirements",
                column: "VideogameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideogameRequirements",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 22, 4, 16, 49, 334, DateTimeKind.Local).AddTicks(8768));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 22, 4, 16, 49, 317, DateTimeKind.Local).AddTicks(8608));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 22, 4, 16, 49, 317, DateTimeKind.Local).AddTicks(8619));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 22, 4, 16, 49, 317, DateTimeKind.Local).AddTicks(8813));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 22, 4, 16, 49, 317, DateTimeKind.Local).AddTicks(8815));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 22, 4, 16, 49, 334, DateTimeKind.Local).AddTicks(8616));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt", "Verified" },
                values: new object[] { "Pr6fQwlSEID5O+Ri2NbPOtG32sTwa1yglVvTned795w=", "v4J2nNfd+rwJuDoolTIXpg==", new DateTime(2022, 5, 22, 4, 16, 49, 333, DateTimeKind.Local).AddTicks(2428) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserBalance",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 22, 4, 16, 49, 334, DateTimeKind.Local).AddTicks(8484));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Videogame",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 22, 4, 16, 49, 334, DateTimeKind.Local).AddTicks(8695));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "VideogameCategory",
                keyColumns: new[] { "CategoryId", "VideogameId" },
                keyValues: new object[] { 1, 1 },
                column: "DateCreated",
                value: new DateTime(2022, 5, 22, 4, 16, 49, 334, DateTimeKind.Local).AddTicks(8853));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "VideogameLikes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 22, 4, 16, 49, 334, DateTimeKind.Local).AddTicks(8939));
        }
    }
}
