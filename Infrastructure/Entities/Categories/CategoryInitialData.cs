using Infrastructure.Entities.Publisher;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Categories
{
    public  class CategoryInitialData : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasData(
                new CategoryEntity
                {
                    Id=1,
                    CategoryName ="moba",
                    DateCreated = DateTime.Now,
                }
                );
        }
    }
}
