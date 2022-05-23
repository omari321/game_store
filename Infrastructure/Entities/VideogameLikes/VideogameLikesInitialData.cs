using Infrastructure.Entities.Videogame;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameLikes
{
    public class VideogameLikesInitialData : IEntityTypeConfiguration<VideogameLikesEntity>
    {
        public void Configure(EntityTypeBuilder<VideogameLikesEntity> builder)
        {
            builder.HasData(
                new VideogameLikesEntity
                {
                    Id =1,
                    VideogameId =1,
                    LikesCount=0,
                    DislikesCount=0,
                    DateCreated=DateTime.Now,
                });
        }
    }
}
