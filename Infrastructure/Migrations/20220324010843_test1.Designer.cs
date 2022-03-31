﻿// <auto-generated />
using System;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(EntityDbContext))]
    [Migration("20220324010843_test1")]
    partial class test1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Infrastructure.Entities.BoughtGames.BoughtGamesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("BoughtPrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDigital")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VideoGameEntityId")
                        .HasColumnType("int");

                    b.Property<int>("VideoGameId")
                        .HasColumnType("int");

                    b.Property<string>("key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VideoGameEntityId");

                    b.ToTable("BoughtGames", "dbo");
                });

            modelBuilder.Entity("Infrastructure.Entities.City.CityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(65)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(65)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("City", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            DateCreated = new DateTime(2022, 3, 24, 5, 8, 43, 727, DateTimeKind.Local).AddTicks(5691),
                            Name = "Seattle"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 2,
                            DateCreated = new DateTime(2022, 3, 24, 5, 8, 43, 727, DateTimeKind.Local).AddTicks(5693),
                            Name = "Tokyo"
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.CommentLikes.CommentLikesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("PositiveComment")
                        .HasColumnType("bit");

                    b.Property<int>("commentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("commentId", "PositiveComment");

                    b.ToTable("CommentLikes", "dbo");
                });

            modelBuilder.Entity("Infrastructure.Entities.Comments.CommentsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VideoGameId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VideoGameId");

                    b.ToTable("Comments", "dbo");
                });

            modelBuilder.Entity("Infrastructure.Entities.Country.CountryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Country", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2022, 3, 24, 5, 8, 43, 727, DateTimeKind.Local).AddTicks(5521),
                            Name = "USA"
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(2022, 3, 24, 5, 8, 43, 727, DateTimeKind.Local).AddTicks(5532),
                            Name = "Japan(OwO)"
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.Developer.DeveloperEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Developer", "dbo");
                });

            modelBuilder.Entity("Infrastructure.Entities.DiscountInfo.DiscountInfoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiscountInfo")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<double>("PaymentPercentage")
                        .HasColumnType("float");

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("DiscountInfo", "dbo");
                });

            modelBuilder.Entity("Infrastructure.Entities.GameCategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Category", "dbo");
                });

            modelBuilder.Entity("Infrastructure.Entities.GameReviews.GameReviewsEntity", b =>
                {
                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<bool>("PositiveReview")
                        .HasColumnType("bit");

                    b.HasIndex("GameId", "PositiveReview");

                    b.ToTable("GamesReview", "dbo");
                });

            modelBuilder.Entity("Infrastructure.Entities.GamesCategories.GamesCategoriesEntity", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.HasKey("GameId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("GameCategories", "dbo");
                });

            modelBuilder.Entity("Infrastructure.Entities.GameVisits.GameVisitsEntity", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("datetime2");

                    b.HasIndex("GameId");

                    b.ToTable("GameVisits", "dbo");
                });

            modelBuilder.Entity("Infrastructure.Entities.OwnedGames.OwnedGamesEntity", b =>
                {
                    b.Property<int>("VideoGameId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VideoGameId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("OwnedGames", "dbo");
                });

            modelBuilder.Entity("Infrastructure.Entities.PaymentInfo.PaymentInfoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CSV")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("PaymentInfo", "dbo");
                });

            modelBuilder.Entity("Infrastructure.Entities.PhysicalGamesKey.PhysicalGamesKeysEntitys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AlreadyUsed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Game")
                        .HasColumnType("int");

                    b.Property<int>("GameIdId")
                        .HasColumnType("int");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("GameIdId");

                    b.ToTable("PhysicalGamesKeys");
                });

            modelBuilder.Entity("Infrastructure.Entities.Publisher.PublisherEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeveloperName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Publisher", "dbo");
                });

            modelBuilder.Entity("Infrastructure.Entities.User.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int?>("PaymentInfoId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("PaymentInfoId");

                    b.ToTable("User", "dbo");
                });

            modelBuilder.Entity("Infrastructure.Entities.UserShoppingCart.UserShoppingCartEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VideoGameId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VideoGameId");

                    b.ToTable("UserShoppingCart", "dbo");
                });

            modelBuilder.Entity("Infrastructure.Entities.VideoGame.VideoGameEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AvailQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<int>("DiscountId")
                        .HasColumnType("int");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("PublicsherId")
                        .HasColumnType("int");

                    b.Property<string>("VideoGameName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("DiscountId");

                    b.HasIndex("PublicsherId");

                    b.ToTable("VideoGame", "dbo");
                });

            modelBuilder.Entity("Infrastructure.Entities.BoughtGames.BoughtGamesEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.User.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.VideoGame.VideoGameEntity", "VideoGameEntity")
                        .WithMany()
                        .HasForeignKey("VideoGameEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("VideoGameEntity");
                });

            modelBuilder.Entity("Infrastructure.Entities.City.CityEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.Country.CountryEntity", "Country")
                        .WithMany("cityEntity")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Infrastructure.Entities.CommentLikes.CommentLikesEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.Comments.CommentsEntity", "comment")
                        .WithMany()
                        .HasForeignKey("commentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("comment");
                });

            modelBuilder.Entity("Infrastructure.Entities.Comments.CommentsEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.User.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.VideoGame.VideoGameEntity", "VideoGame")
                        .WithMany("commentsEntity")
                        .HasForeignKey("VideoGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("VideoGame");
                });

            modelBuilder.Entity("Infrastructure.Entities.GameReviews.GameReviewsEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.VideoGame.VideoGameEntity", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Infrastructure.Entities.GamesCategories.GamesCategoriesEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.GameCategoryEntity", "Category")
                        .WithMany("gamesCategoriesEntities")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.VideoGame.VideoGameEntity", "Game")
                        .WithMany("gamesCategoriesEntities")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Infrastructure.Entities.GameVisits.GameVisitsEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.VideoGame.VideoGameEntity", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Infrastructure.Entities.OwnedGames.OwnedGamesEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.User.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.VideoGame.VideoGameEntity", "VideoGame")
                        .WithMany()
                        .HasForeignKey("VideoGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("VideoGame");
                });

            modelBuilder.Entity("Infrastructure.Entities.PhysicalGamesKey.PhysicalGamesKeysEntitys", b =>
                {
                    b.HasOne("Infrastructure.Entities.VideoGame.VideoGameEntity", "GameId")
                        .WithMany("physicalGamesKeysEntitys")
                        .HasForeignKey("GameIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameId");
                });

            modelBuilder.Entity("Infrastructure.Entities.User.UserEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.City.CityEntity", "City")
                        .WithMany("userEntities")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.PaymentInfo.PaymentInfoEntity", "PaymentInfo")
                        .WithMany("userEntities")
                        .HasForeignKey("PaymentInfoId");

                    b.Navigation("City");

                    b.Navigation("PaymentInfo");
                });

            modelBuilder.Entity("Infrastructure.Entities.UserShoppingCart.UserShoppingCartEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.User.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.VideoGame.VideoGameEntity", "VideoGame")
                        .WithMany()
                        .HasForeignKey("VideoGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("VideoGame");
                });

            modelBuilder.Entity("Infrastructure.Entities.VideoGame.VideoGameEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.Developer.DeveloperEntity", "Developer")
                        .WithMany("videoGameEntities")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.DiscountInfo.DiscountInfoEntity", "Discount")
                        .WithMany("videoGameEntities")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Publisher.PublisherEntity", "Publicsher")
                        .WithMany("videoGameEntities")
                        .HasForeignKey("PublicsherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");

                    b.Navigation("Discount");

                    b.Navigation("Publicsher");
                });

            modelBuilder.Entity("Infrastructure.Entities.City.CityEntity", b =>
                {
                    b.Navigation("userEntities");
                });

            modelBuilder.Entity("Infrastructure.Entities.Country.CountryEntity", b =>
                {
                    b.Navigation("cityEntity");
                });

            modelBuilder.Entity("Infrastructure.Entities.Developer.DeveloperEntity", b =>
                {
                    b.Navigation("videoGameEntities");
                });

            modelBuilder.Entity("Infrastructure.Entities.DiscountInfo.DiscountInfoEntity", b =>
                {
                    b.Navigation("videoGameEntities");
                });

            modelBuilder.Entity("Infrastructure.Entities.GameCategoryEntity", b =>
                {
                    b.Navigation("gamesCategoriesEntities");
                });

            modelBuilder.Entity("Infrastructure.Entities.PaymentInfo.PaymentInfoEntity", b =>
                {
                    b.Navigation("userEntities");
                });

            modelBuilder.Entity("Infrastructure.Entities.Publisher.PublisherEntity", b =>
                {
                    b.Navigation("videoGameEntities");
                });

            modelBuilder.Entity("Infrastructure.Entities.VideoGame.VideoGameEntity", b =>
                {
                    b.Navigation("commentsEntity");

                    b.Navigation("gamesCategoriesEntities");

                    b.Navigation("physicalGamesKeysEntitys");
                });
#pragma warning restore 612, 618
        }
    }
}
