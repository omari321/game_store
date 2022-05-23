using Infrastructure.Entities;
using Infrastructure.Entities.UserBalance;
using Infrastructure.Repositories;
using Infrastructure.RepositoryRelated.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.Repositories
{
    public class UserBalanceRepository : RepositoryBase<UserBalanceEntity>, IUserBalanceRepository
    {
        public UserBalanceRepository(EntityDbContext entityDbContext) : base(entityDbContext)
        {
        }
    }
}
