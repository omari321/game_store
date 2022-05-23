using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class test9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideogameLikes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideogameId = table.Column<int>(type: "int", nullable: false),
                    LikesCount = table.Column<int>(type: "int", nullable: false),
                    DislikesCount = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideogameLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideogameLikes_Videogame_VideogameId",
                        column: x => x.VideogameId,
                        principalSchema: "dbo",
                        principalTable: "Videogame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideogameLikesListEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsLike = table.Column<bool>(type: "bit", nullable: false),
                    VideogameId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideogameLikesListEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideogameLikesListEntities_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideogameLikesListEntities_Videogame_VideogameId",
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
                value: new DateTime(2022, 5, 22, 3, 51, 42, 972, DateTimeKind.Local).AddTicks(5454));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 22, 3, 51, 42, 956, DateTimeKind.Local).AddTicks(1057));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 22, 3, 51, 42, 956, DateTimeKind.Local).AddTicks(1067));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 22, 3, 51, 42, 956, DateTimeKind.Local).AddTicks(1251));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 22, 3, 51, 42, 956, DateTimeKind.Local).AddTicks(1292));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 22, 3, 51, 42, 972, DateTimeKind.Local).AddTicks(5282));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt", "Verified" },
                values: new object[] { "gstMSoMqGceImi5/dTRoYIJzLBSA2tJo723OAxNBwfk=", "VFYyo8EaGvRIOarZQj8vfA==", new DateTime(2022, 5, 22, 3, 51, 42, 970, DateTimeKind.Local).AddTicks(9344) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserBalance",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 22, 3, 51, 42, 972, DateTimeKind.Local).AddTicks(5120));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Videogame",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 22, 3, 51, 42, 972, DateTimeKind.Local).AddTicks(5380));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "VideogameCategory",
                keyColumns: new[] { "CategoryId", "VideogameId" },
                keyValues: new object[] { 1, 1 },
                column: "DateCreated",
                value: new DateTime(2022, 5, 22, 3, 51, 42, 972, DateTimeKind.Local).AddTicks(5540));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "VideogameLikes",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "DislikesCount", "LikesCount", "VideogameId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_VideogameLikes_VideogameId",
                schema: "dbo",
                table: "VideogameLikes",
                column: "VideogameId");

            migrationBuilder.CreateIndex(
                name: "IX_VideogameLikesListEntities_UserId",
                table: "VideogameLikesListEntities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VideogameLikesListEntities_VideogameId",
                table: "VideogameLikesListEntities",
                column: "VideogameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideogameLikes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VideogameLikesListEntities");

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
        }
    }
}
