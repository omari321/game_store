using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videogame",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideogameName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    OldPrice = table.Column<double>(type: "float", nullable: true),
                    PublicsherId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DownloadFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videogame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videogame_Publisher_PublicsherId",
                        column: x => x.PublicsherId,
                        principalSchema: "dbo",
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    VerificationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailSent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Verified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "dbo",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideogameCategory",
                schema: "dbo",
                columns: table => new
                {
                    VideogameId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideogameCategory", x => new { x.VideogameId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_VideogameCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideogameCategory_Videogame_VideogameId",
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
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentCreditentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentCreditentials_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_User_UserEntityId",
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
                    VideogameId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TransactionAmount = table.Column<double>(type: "float", nullable: false),
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
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Country",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Name" },
                values: new object[] { 1, new DateTime(2022, 5, 16, 1, 41, 5, 694, DateTimeKind.Local).AddTicks(4787), null, "USA" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Country",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Name" },
                values: new object[] { 2, new DateTime(2022, 5, 16, 1, 41, 5, 694, DateTimeKind.Local).AddTicks(4788), null, "Japan(OwO)" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "City",
                columns: new[] { "Id", "CountryId", "DateCreated", "DateUpdated", "Name" },
                values: new object[] { 1, 1, new DateTime(2022, 5, 16, 1, 41, 5, 694, DateTimeKind.Local).AddTicks(4598), null, "Seattle" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "City",
                columns: new[] { "Id", "CountryId", "DateCreated", "DateUpdated", "Name" },
                values: new object[] { 2, 2, new DateTime(2022, 5, 16, 1, 41, 5, 694, DateTimeKind.Local).AddTicks(4608), null, "Tokyo" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "User",
                columns: new[] { "Id", "Adress", "CityId", "DateCreated", "DateUpdated", "Email", "FirstName", "LastName", "MailSent", "Password", "Role", "Salt", "TelephoneNumber", "UserName", "VerificationToken", "Verified" },
                values: new object[] { 1, "admin", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "O_pirtskhalaishvili@cu.edu.ge", "admin", "admin", null, "ZOq8IjqEpX5NKEaBqN8dTr/Up8IT9a8kg9Dqjs5VLSk=", 1, "Y+aEHkUVwCN9pO6AoeLk4Q==", "551001100", "string", null, new DateTime(2022, 5, 16, 1, 41, 5, 708, DateTimeKind.Local).AddTicks(8762) });

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                schema: "dbo",
                table: "City",
                column: "CountryId");

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
                name: "IX_PaymentCreditentials_UserId",
                schema: "dbo",
                table: "PaymentCreditentials",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserEntityId",
                table: "RefreshToken",
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
                name: "IX_User_CityId",
                schema: "dbo",
                table: "User",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Videogame_PublicsherId",
                schema: "dbo",
                table: "Videogame",
                column: "PublicsherId");

            migrationBuilder.CreateIndex(
                name: "IX_VideogameCategory_CategoryId",
                schema: "dbo",
                table: "VideogameCategory",
                column: "CategoryId");

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
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "Transactions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VideogameCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VideogameImages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Videogame",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "City",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Publisher",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "dbo");
        }
    }
}
