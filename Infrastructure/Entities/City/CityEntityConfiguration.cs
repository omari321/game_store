using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Entities.City
{
    internal class CityEntityConfiguration : IEntityTypeConfiguration<CityEntity>
    {
        public void Configure(EntityTypeBuilder<CityEntity> builder)
        {
            builder
              .HasData(
                  new CityEntity
                  {
                      Id = 1,
                      CountryId = 1,
                      Name = "Seattle",
                      DateCreated = DateTime.Now
                  },
                  new CityEntity
                  {
                      Id = 2,
                      CountryId = 2,
                      Name = "Tokyo",
                      DateCreated = DateTime.Now
                  }
              );
        }
    }
}

