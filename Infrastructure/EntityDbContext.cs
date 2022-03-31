using Infrastructure.Entities.BoughtGames;
using Infrastructure.Entities.City;
using Infrastructure.Entities.CommentLikes;
using Infrastructure.Entities.Comments;
using Infrastructure.Entities.Country;
using Infrastructure.Entities.Developer;
using Infrastructure.Entities.DiscountInfo;
using Infrastructure.Entities.GameReviews;
using Infrastructure.Entities.GamesCategories;
using Infrastructure.Entities.GameVisits;
using Infrastructure.Entities.OwnedGames;
using Infrastructure.Entities.PaymentInfo;
using Infrastructure.Entities.PhysicalGamesKey;
using Infrastructure.Entities.User;
using Infrastructure.Entities.UserShoppingCart;
using Infrastructure.Entities.VideoGame;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities
{
    public  class EntityDbContext:DbContext
    {
        public EntityDbContext()
        { }

        public EntityDbContext(DbContextOptions<EntityDbContext> options)
            : base(options)
        {
        }
        public DbSet<VideoGameEntity> VideoGame {get;set;}
        public DbSet<GamesCategoriesEntity> GamesCategories {get;set;}
        public DbSet<GameCategoryEntity> Category { get;set;}
        public DbSet<CityEntity> cityEntities {get;set;}
        public DbSet<CountryEntity> countryEntities {get;set;}
        public DbSet<PaymentInfoEntity> paymentInfoEntities {get;set;}
        public DbSet<UserEntity> userEntities {get;set;}
        public DbSet<DeveloperEntity> developerEntities {get;set;}
        public DbSet<DiscountInfoEntity> discountInfoEntities {get;set;}
        public DbSet<GameReviewsEntity> GameReviewsEntities {get;set;}
        public DbSet<GameVisitsEntity> GameVisitsEntities {get;set;}
        public DbSet<PhysicalGamesKeysEntitys> physicalGamesKeysEntitys {get;set;}
        public DbSet<UserShoppingCartEntity> userShoppingCartEntities {get;set;}
        public DbSet<BoughtGamesEntity> boughtGamesEntities { get;set;}
        public DbSet<OwnedGamesEntity> OwnedGamesEntity {get;set;}
        public DbSet<CommentsEntity> commentsEntities {get;set;}
        public DbSet<CommentLikesEntity> CommentLikesEntities {get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //anotaciit argamodis es
            modelBuilder.ApplyConfiguration(new GamesCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OwnedGamesConfiguration());
            ///
            modelBuilder.ApplyConfiguration(new CityEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
