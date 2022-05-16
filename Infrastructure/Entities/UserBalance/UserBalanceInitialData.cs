using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.UserBalance
{
    public class UserBalanceInitialData : IEntityTypeConfiguration<UserBalanceEntity>
    {
        public void Configure(EntityTypeBuilder<UserBalanceEntity> builder)
        {
            builder.HasData
            (
                new UserBalanceEntity
                {
                    Id=1,
                    UserId=1,
                    balance=0,
                    DateCreated=DateTime.Now,
                }
           );
        }
    }
}
