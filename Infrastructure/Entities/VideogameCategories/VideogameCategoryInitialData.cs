using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameCategories
{
    public class VideogameCategoryInitialData : IEntityTypeConfiguration<VideogameCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<VideogameCategoryEntity> builder)
        {
            builder.HasData(

                new VideogameCategoryEntity
                {
                    CategoryId=1,
                    VideogameId=1,
                    DateCreated=DateTime.Now,
                }
                ) ;
        }
    }
}
