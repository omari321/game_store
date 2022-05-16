using Infrastructure.Entities.Categories;
using Infrastructure.Entities.City;
using Infrastructure.Entities.Country;
using Infrastructure.Entities.OwnedGames;
using Infrastructure.Entities.PaymentCreditentials;
using Infrastructure.Entities.Publisher;
using Infrastructure.Entities.Transactions;
using Infrastructure.Entities.User;
using Infrastructure.Entities.UserBalance;
using Infrastructure.Entities.Videogame;
using Infrastructure.Entities.VideogameCategories;
using Infrastructure.Entities.VideogameImages;
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
        public DbSet<TransactionsEntity> transactionsEntities { get; set; }
        public DbSet<OwnedGamesEntity> ownedGamesEntities { get; set; }
        public DbSet<CityEntity> cityEntities {get;set;}
        public DbSet<CountryEntity> countryEntities {get;set;}
        public DbSet<UserEntity> userEntities {get;set;}
        public DbSet<PublisherEntity> publisherEntities { get; set; }
        public DbSet<VideogameEntity> videogameEntities { get; set; }
        public DbSet<VideogameCategoryEntity> videogameCategoryEntities { get; set; }
        public DbSet<CategoryEntity> categoryEntities { get; set; }
        public DbSet<PaymentCredentialsEntity > paymentCreditentialsEntities { get; set; }
        public DbSet<VideogameImagesEntity> videogameImagesEntities { get;set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserInitialData());
            modelBuilder.ApplyConfiguration(new VideogameCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserBalanceInitialData());
            base.OnModelCreating(modelBuilder);
        }
    }
}
