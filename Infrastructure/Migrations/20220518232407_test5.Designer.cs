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
    [Migration("20220518232407_test5")]
    partial class test5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Infrastructure.Entities.Categories.CategoryEntity", b =>
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "moba",
                            DateCreated = new DateTime(2022, 5, 19, 3, 24, 6, 766, DateTimeKind.Local).AddTicks(6416)
                        });
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
                            DateCreated = new DateTime(2022, 5, 19, 3, 24, 6, 750, DateTimeKind.Local).AddTicks(3481),
                            Name = "Seattle"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 2,
                            DateCreated = new DateTime(2022, 5, 19, 3, 24, 6, 750, DateTimeKind.Local).AddTicks(3495),
                            Name = "Tokyo"
                        });
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
                            DateCreated = new DateTime(2022, 5, 19, 3, 24, 6, 750, DateTimeKind.Local).AddTicks(3723),
                            Name = "USA"
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(2022, 5, 19, 3, 24, 6, 750, DateTimeKind.Local).AddTicks(3725),
                            Name = "Japan(OwO)"
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.OwnedGames.OwnedGamesEntity", b =>
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

                    b.Property<int>("VideogameId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VideogameId");

                    b.ToTable("OwnedGames", "dbo");
                });

            modelBuilder.Entity("Infrastructure.Entities.PaymentCreditentials.PaymentCredentialsEntity", b =>
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

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PaymentCreditentials", "dbo");
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

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Publisher", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2022, 5, 19, 3, 24, 6, 766, DateTimeKind.Local).AddTicks(6147),
                            PublisherName = "valve"
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.Token.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedByIp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReasonRevoked")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime2");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserEntityId")
                        .HasColumnType("int");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("Infrastructure.Entities.Transactions.TransactionsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<double>("TransactionAmount")
                        .HasColumnType("float");

                    b.Property<string>("TransactionDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("VideogameEntityId")
                        .HasColumnType("int");

                    b.Property<int>("paymentType")
                        .HasColumnType("int");

                    b.Property<int>("transactionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VideogameEntityId");

                    b.ToTable("Transactions", "dbo");
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

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<DateTime?>("MailSent")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("Role")
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

                    b.Property<string>("VerificationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Verified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("User", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adress = "admin",
                            CityId = 1,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "O_pirtskhalaishvili@cu.edu.ge",
                            FirstName = "admin",
                            LastName = "admin",
                            Password = "YTUTx9yEMxyjx+/QnFx6SWo/loqmqmpbJI+IU17uGOQ=",
                            Role = 1,
                            Salt = "Y+thTlETJKl0bB2RmNpUjA==",
                            TelephoneNumber = "551001100",
                            UserName = "string",
                            Verified = new DateTime(2022, 5, 19, 3, 24, 6, 764, DateTimeKind.Local).AddTicks(2713)
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.UserBalance.UserBalanceEntity", b =>
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

                    b.Property<double>("balance")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserBalance", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2022, 5, 19, 3, 24, 6, 766, DateTimeKind.Local).AddTicks(5898),
                            UserId = 1,
                            balance = 0.0
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.Videogame.VideogameEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("DownloadFileUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("OldPrice")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("PublicsherId")
                        .HasColumnType("int");

                    b.Property<string>("ThumbnailPath")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideogameName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("PublicsherId");

                    b.ToTable("Videogame", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2022, 5, 19, 3, 24, 6, 766, DateTimeKind.Local).AddTicks(6300),
                            Description = "Mobile battle arena where 10 players play vs each other in teams of 5",
                            Price = 0.0,
                            PublicsherId = 1,
                            VideogameName = "dota2"
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.VideogameCategories.VideogameCategoryEntity", b =>
                {
                    b.Property<int>("VideogameId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.HasKey("VideogameId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("VideogameCategory", "dbo");

                    b.HasData(
                        new
                        {
                            VideogameId = 1,
                            CategoryId = 1,
                            DateCreated = new DateTime(2022, 5, 19, 3, 24, 6, 766, DateTimeKind.Local).AddTicks(6572)
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.VideogameImages.VideogameImagesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VideogameId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VideogameId");

                    b.ToTable("VideogameImages", "dbo");
                });

            modelBuilder.Entity("Infrastructure.Entities.VideogameTransaction.GameTransactionHistoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("VideogameId")
                        .HasColumnType("int");

                    b.Property<int>("transactionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VideogameId");

                    b.HasIndex("transactionId");

                    b.ToTable("GameTransactionHistory", "dbo");
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

            modelBuilder.Entity("Infrastructure.Entities.OwnedGames.OwnedGamesEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.User.UserEntity", "User")
                        .WithMany("ownedGamesEntities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Videogame.VideogameEntity", "Videogame")
                        .WithMany("ownedGamesEntities")
                        .HasForeignKey("VideogameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Videogame");
                });

            modelBuilder.Entity("Infrastructure.Entities.PaymentCreditentials.PaymentCredentialsEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.User.UserEntity", "User")
                        .WithMany("paymentCreditentials")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Entities.Token.RefreshToken", b =>
                {
                    b.HasOne("Infrastructure.Entities.User.UserEntity", null)
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserEntityId");
                });

            modelBuilder.Entity("Infrastructure.Entities.Transactions.TransactionsEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.User.UserEntity", "User")
                        .WithMany("transactionsEntities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Videogame.VideogameEntity", null)
                        .WithMany("transactionsEntities")
                        .HasForeignKey("VideogameEntityId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Entities.User.UserEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.City.CityEntity", "City")
                        .WithMany("userEntities")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Infrastructure.Entities.UserBalance.UserBalanceEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.User.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Entities.Videogame.VideogameEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.Publisher.PublisherEntity", "Publicsher")
                        .WithMany("videoGameEntities")
                        .HasForeignKey("PublicsherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publicsher");
                });

            modelBuilder.Entity("Infrastructure.Entities.VideogameCategories.VideogameCategoryEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.Categories.CategoryEntity", "Category")
                        .WithMany("videogameCategoryEntities")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Videogame.VideogameEntity", "Videogame")
                        .WithMany("videogameCategoryEntities")
                        .HasForeignKey("VideogameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Videogame");
                });

            modelBuilder.Entity("Infrastructure.Entities.VideogameImages.VideogameImagesEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.Videogame.VideogameEntity", "Videogame")
                        .WithMany("videogameImagesEntities")
                        .HasForeignKey("VideogameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Videogame");
                });

            modelBuilder.Entity("Infrastructure.Entities.VideogameTransaction.GameTransactionHistoryEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.Videogame.VideogameEntity", "videogame")
                        .WithMany()
                        .HasForeignKey("VideogameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Transactions.TransactionsEntity", "transaction")
                        .WithMany("videogameTransactionEntity")
                        .HasForeignKey("transactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("transaction");

                    b.Navigation("videogame");
                });

            modelBuilder.Entity("Infrastructure.Entities.Categories.CategoryEntity", b =>
                {
                    b.Navigation("videogameCategoryEntities");
                });

            modelBuilder.Entity("Infrastructure.Entities.City.CityEntity", b =>
                {
                    b.Navigation("userEntities");
                });

            modelBuilder.Entity("Infrastructure.Entities.Country.CountryEntity", b =>
                {
                    b.Navigation("cityEntity");
                });

            modelBuilder.Entity("Infrastructure.Entities.Publisher.PublisherEntity", b =>
                {
                    b.Navigation("videoGameEntities");
                });

            modelBuilder.Entity("Infrastructure.Entities.Transactions.TransactionsEntity", b =>
                {
                    b.Navigation("videogameTransactionEntity");
                });

            modelBuilder.Entity("Infrastructure.Entities.User.UserEntity", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("ownedGamesEntities");

                    b.Navigation("paymentCreditentials");

                    b.Navigation("transactionsEntities");
                });

            modelBuilder.Entity("Infrastructure.Entities.Videogame.VideogameEntity", b =>
                {
                    b.Navigation("ownedGamesEntities");

                    b.Navigation("transactionsEntities");

                    b.Navigation("videogameCategoryEntities");

                    b.Navigation("videogameImagesEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
