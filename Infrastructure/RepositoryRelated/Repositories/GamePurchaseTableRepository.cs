using Infrastructure.Entities;
using Infrastructure.Entities.VideogameTransaction;
using Infrastructure.Repositories;
using Infrastructure.RepositoryRelated.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.Repositories
{
    public class GameTransactionHistoryRepository : RepositoryBase<GameTransactionHistoryEntity>, IGameTransactionHistoryRepository 
    {
        public GameTransactionHistoryRepository(EntityDbContext entityDbContext) : base(entityDbContext)
        {
        }
    }
}
