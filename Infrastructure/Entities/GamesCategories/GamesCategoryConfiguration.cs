using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.GamesCategories
{
    public class GamesCategoryConfiguration : IEntityTypeConfiguration<GamesCategoriesEntity>
    {
        public void Configure(EntityTypeBuilder<GamesCategoriesEntity> builder)
        {
            //anotaciit argamodis es
            builder.HasKey(u => new
            {
                u.GameId,
                u.CategoryId
            });
        }
    }
}
