using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.OwnedGames
{
    public class OwnedGamesConfiguration : IEntityTypeConfiguration<OwnedGamesEntity>
    {
        
        public void Configure(EntityTypeBuilder<OwnedGamesEntity> builder)
        { 
            //anotaciit argamodis es
            builder.HasKey(x => new {
                x.VideoGameId,
                x.UserId
            });

        } 
    }
}
