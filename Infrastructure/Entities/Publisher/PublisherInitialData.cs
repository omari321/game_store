using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Publisher
{
    public class PublisherInitialData:IEntityTypeConfiguration<PublisherEntity>
    {
        public void Configure(EntityTypeBuilder<PublisherEntity> builder)
        {
            builder.HasData(
                
                new PublisherEntity
                {
                    Id = 1,
                    PublisherName="valve",
                    DateCreated = DateTime.Now,
                }
                );

            
        }
    }
}
