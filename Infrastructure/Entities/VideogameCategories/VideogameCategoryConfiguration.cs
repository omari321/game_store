using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameCategories
{
    internal class VideogameCategoryConfiguration : IEntityTypeConfiguration<VideogameCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<VideogameCategoryEntity> builder)
        {
            builder.HasKey(x =>
            new { x.VideogameId,
                  x.CategoryId
            });
        }
    }
}
