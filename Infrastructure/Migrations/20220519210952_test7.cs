using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class test7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MailSent",
                schema: "dbo",
                table: "User");

            migrationBuilder.CreateTable(
                name: "confirmationMailToSendEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmationLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_confirmationMailToSendEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_confirmationMailToSendEntities_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_confirmationMailToSendEntities_UserId",
                table: "confirmationMailToSendEntities",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "confirmationMailToSendEntities");

            migrationBuilder.AddColumn<DateTime>(
                name: "MailSent",
                schema: "dbo",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 52, 33, 969, DateTimeKind.Local).AddTicks(1358));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 52, 33, 953, DateTimeKind.Local).AddTicks(2799));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 52, 33, 953, DateTimeKind.Local).AddTicks(2808));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 52, 33, 953, DateTimeKind.Local).AddTicks(3023));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 52, 33, 953, DateTimeKind.Local).AddTicks(3025));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 52, 33, 969, DateTimeKind.Local).AddTicks(1179));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt", "Verified" },
                values: new object[] { "8K/07eBeRyFK4nldE3O2HCrHEC1yDIUEz7MPCKtaQoI=", "/Ec8xN+gEaDy5OLCSJWmaw==", new DateTime(2022, 5, 19, 3, 52, 33, 967, DateTimeKind.Local).AddTicks(4203) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserBalance",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 52, 33, 969, DateTimeKind.Local).AddTicks(1011));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Videogame",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 52, 33, 969, DateTimeKind.Local).AddTicks(1286));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "VideogameCategory",
                keyColumns: new[] { "CategoryId", "VideogameId" },
                keyValues: new object[] { 1, 1 },
                column: "DateCreated",
                value: new DateTime(2022, 5, 19, 3, 52, 33, 969, DateTimeKind.Local).AddTicks(1428));
        }
    }
}
