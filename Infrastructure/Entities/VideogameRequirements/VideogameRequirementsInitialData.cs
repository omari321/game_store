using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameRequirements
{
    public class VideogameRequirementsInitialData : IEntityTypeConfiguration<VideogameRequirementsEntity>
    {
        public void Configure(EntityTypeBuilder<VideogameRequirementsEntity> builder)
        {
            builder.HasData(
                new VideogameRequirementsEntity
                {
                    Id=1,
                    VideogameId=1,
                    MinRequirements="core i3-5400, 8gb ram , gtx 660",
                    RecomendedRequirements="core i9-12900ks, 32gb lp DDR5 4600mhz, RTX 3090TI",
                    DateCreated=DateTime.Now,
                }
                );
        }
    }
}
