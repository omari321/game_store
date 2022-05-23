using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Videogame
{
    public class VideogameInitialData: IEntityTypeConfiguration<VideogameEntity>
    {
        public void Configure(EntityTypeBuilder<VideogameEntity> builder)
        {
            builder.HasData(
                new VideogameEntity
                {
                    Id =1,
                    VideogameName ="dota2",
                    Price=0,
                    PublicsherId=1,
                    Description="Mobile battle arena where 10 players play vs each other in teams of 5",
                    DateCreated=DateTime.Now,
                });
        }
    }
}
