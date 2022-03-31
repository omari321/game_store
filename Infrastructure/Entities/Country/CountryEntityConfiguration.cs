using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Entities.Country
{
    public class CountryEntityConfiguration : IEntityTypeConfiguration<CountryEntity>
    {
        public void Configure(EntityTypeBuilder<CountryEntity> builder)
        {
            builder.HasData(
             new CountryEntity
             {
                 Id = 1,
                 Name = "USA",
                 DateCreated = DateTime.Now
             },
             new CountryEntity
             {
                 Id = 2,
                 Name = "Japan(OwO)",
                 DateCreated = DateTime.Now
             }
            );
        }
    }
}
