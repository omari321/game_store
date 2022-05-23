using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class test10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideogameLikesListEntities_User_UserId",
                table: "VideogameLikesListEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_VideogameLikesListEntities_Videogame_VideogameId",
                table: "VideogameLikesListEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideogameLikesListEntities",
                table: "VideogameLikesListEntities");

            migrationBuilder.RenameTable(
                name: "VideogameLikesListEntities",
                newName: "VideogameLikesList",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_VideogameLikesListEntities_VideogameId",
                schema: "dbo",
                table: "VideogameLikesList",
                newName: "IX_VideogameLikesList_VideogameId");

            migrationBuilder.RenameIndex(
                name: "IX_VideogameLikesListEntities_UserId",
                schema: "dbo",
                table: "VideogameLikesList",
                newName: "IX_VideogameLikesList_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideogameLikesList",
                schema: "dbo",
                table: "VideogameLikesList",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_VideogameLikesList_User_UserId",
                schema: "dbo",
                table: "VideogameLikesList",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideogameLikesList_Videogame_VideogameId",
                schema: "dbo",
                table: "VideogameLikesList",
                column: "VideogameId",
                principalSchema: "dbo",
                principalTable: "Videogame",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideogameLikesList_User_UserId",
                schema: "dbo",
                table: "VideogameLikesList");

            migrationBuilder.DropForeignKey(
                name: "FK_VideogameLikesList_Videogame_VideogameId",
                schema: "dbo",
                table: "VideogameLikesList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideogameLikesList",
                schema: "dbo",
                table: "VideogameLikesList");

            migrationBuilder.RenameTable(
                name: "VideogameLikesList",
                schema: "dbo",
                newName: "VideogameLikesListEntities");

            migrationBuilder.RenameIndex(
                name: "IX_VideogameLikesList_VideogameId",
                table: "VideogameLikesListEntities",
                newName: "IX_VideogameLikesListEntities_VideogameId");

            migrationBuilder.RenameIndex(
                name: "IX_VideogameLikesList_UserId",
                table: "VideogameLikesListEntities",
                newName: "IX_VideogameLikesListEntities_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideogameLikesListEntities",
                table: "VideogameLikesListEntities",
                column: "Id");

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

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "VideogameLikes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_VideogameLikesListEntities_User_UserId",
                table: "VideogameLikesListEntities",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideogameLikesListEntities_Videogame_VideogameId",
                table: "VideogameLikesListEntities",
                column: "VideogameId",
                principalSchema: "dbo",
                principalTable: "Videogame",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
