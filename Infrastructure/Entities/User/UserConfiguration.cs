using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.User
{
    public class UserConfiguration: IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.City)
                .WithMany()
                .HasForeignKey(x => x.CityId);
            builder.HasOne(x => x.PaymentInfo);
            builder.HasMany(x => x.RefreshTokens);
        }
    }
}
