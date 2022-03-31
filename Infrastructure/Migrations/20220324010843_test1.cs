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
                name: "Developer",
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
                    table.PrimaryKey("PK_Developer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountInfo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountInfo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PaymentPercentage = table.Column<double>(type: "float", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentInfo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CSV = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
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
                name: "VideoGame",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoGameName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PublicsherId = table.Column<int>(type: "int", nullable: false),
                    AvailQuantity = table.Column<int>(type: "int", nullable: false),
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatformId = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoGame_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalSchema: "dbo",
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoGame_DiscountInfo_DiscountId",
                        column: x => x.DiscountId,
                        principalSchema: "dbo",
                        principalTable: "DiscountInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoGame_Publisher_PublicsherId",
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
                    Adress = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PaymentInfoId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_User_PaymentInfo_PaymentInfoId",
                        column: x => x.PaymentInfoId,
                        principalSchema: "dbo",
                        principalTable: "PaymentInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GameCategories",
                schema: "dbo",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCategories", x => new { x.GameId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_GameCategories_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameCategories_VideoGame_GameId",
                        column: x => x.GameId,
                        principalSchema: "dbo",
                        principalTable: "VideoGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamesReview",
                schema: "dbo",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    PositiveReview = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_GamesReview_VideoGame_GameId",
                        column: x => x.GameId,
                        principalSchema: "dbo",
                        principalTable: "VideoGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameVisits",
                schema: "dbo",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_GameVisits_VideoGame_GameId",
                        column: x => x.GameId,
                        principalSchema: "dbo",
                        principalTable: "VideoGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalGamesKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Game = table.Column<int>(type: "int", nullable: false),
                    GameIdId = table.Column<int>(type: "int", nullable: false),
                    AlreadyUsed = table.Column<bool>(type: "bit", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalGamesKeys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalGamesKeys_VideoGame_GameIdId",
                        column: x => x.GameIdId,
                        principalSchema: "dbo",
                        principalTable: "VideoGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoughtGames",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoGameId = table.Column<int>(type: "int", nullable: false),
                    VideoGameEntityId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDigital = table.Column<bool>(type: "bit", nullable: false),
                    key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoughtPrice = table.Column<double>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoughtGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoughtGames_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoughtGames_VideoGame_VideoGameEntityId",
                        column: x => x.VideoGameEntityId,
                        principalSchema: "dbo",
                        principalTable: "VideoGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoGameId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_VideoGame_VideoGameId",
                        column: x => x.VideoGameId,
                        principalSchema: "dbo",
                        principalTable: "VideoGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnedGames",
                schema: "dbo",
                columns: table => new
                {
                    VideoGameId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedGames", x => new { x.VideoGameId, x.UserId });
                    table.ForeignKey(
                        name: "FK_OwnedGames_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnedGames_VideoGame_VideoGameId",
                        column: x => x.VideoGameId,
                        principalSchema: "dbo",
                        principalTable: "VideoGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserShoppingCart",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoGameId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserShoppingCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserShoppingCart_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserShoppingCart_VideoGame_VideoGameId",
                        column: x => x.VideoGameId,
                        principalSchema: "dbo",
                        principalTable: "VideoGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentLikes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    commentId = table.Column<int>(type: "int", nullable: false),
                    PositiveComment = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentLikes_Comments_commentId",
                        column: x => x.commentId,
                        principalSchema: "dbo",
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Country",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Name" },
                values: new object[] { 1, new DateTime(2022, 3, 24, 5, 8, 43, 727, DateTimeKind.Local).AddTicks(5521), null, "USA" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Country",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Name" },
                values: new object[] { 2, new DateTime(2022, 3, 24, 5, 8, 43, 727, DateTimeKind.Local).AddTicks(5532), null, "Japan(OwO)" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "City",
                columns: new[] { "Id", "CountryId", "DateCreated", "DateUpdated", "Name" },
                values: new object[] { 1, 1, new DateTime(2022, 3, 24, 5, 8, 43, 727, DateTimeKind.Local).AddTicks(5691), null, "Seattle" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "City",
                columns: new[] { "Id", "CountryId", "DateCreated", "DateUpdated", "Name" },
                values: new object[] { 2, 2, new DateTime(2022, 3, 24, 5, 8, 43, 727, DateTimeKind.Local).AddTicks(5693), null, "Tokyo" });

            migrationBuilder.CreateIndex(
                name: "IX_BoughtGames_UserId",
                schema: "dbo",
                table: "BoughtGames",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BoughtGames_VideoGameEntityId",
                schema: "dbo",
                table: "BoughtGames",
                column: "VideoGameEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                schema: "dbo",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_commentId_PositiveComment",
                schema: "dbo",
                table: "CommentLikes",
                columns: new[] { "commentId", "PositiveComment" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                schema: "dbo",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_VideoGameId",
                schema: "dbo",
                table: "Comments",
                column: "VideoGameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameCategories_CategoryId",
                schema: "dbo",
                table: "GameCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesReview_GameId_PositiveReview",
                schema: "dbo",
                table: "GamesReview",
                columns: new[] { "GameId", "PositiveReview" });

            migrationBuilder.CreateIndex(
                name: "IX_GameVisits_GameId",
                schema: "dbo",
                table: "GameVisits",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedGames_UserId",
                schema: "dbo",
                table: "OwnedGames",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalGamesKeys_GameIdId",
                table: "PhysicalGamesKeys",
                column: "GameIdId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CityId",
                schema: "dbo",
                table: "User",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PaymentInfoId",
                schema: "dbo",
                table: "User",
                column: "PaymentInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserShoppingCart_UserId",
                schema: "dbo",
                table: "UserShoppingCart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserShoppingCart_VideoGameId",
                schema: "dbo",
                table: "UserShoppingCart",
                column: "VideoGameId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGame_DeveloperId",
                schema: "dbo",
                table: "VideoGame",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGame_DiscountId",
                schema: "dbo",
                table: "VideoGame",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGame_PublicsherId",
                schema: "dbo",
                table: "VideoGame",
                column: "PublicsherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoughtGames",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CommentLikes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GameCategories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GamesReview",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GameVisits",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OwnedGames",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PhysicalGamesKeys");

            migrationBuilder.DropTable(
                name: "UserShoppingCart",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Comments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VideoGame",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "City",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PaymentInfo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Developer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DiscountInfo",
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
