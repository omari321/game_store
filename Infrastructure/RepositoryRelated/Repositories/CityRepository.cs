using Infrastructure.Entities;
using Infrastructure.Entities.City;
using Infrastructure.Repositories;
using Infrastructure.RepositoryRelated.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.Repositories
{
    public class CityRepository : RepositoryBase<CityEntity>, ICityRepository
    {
        public CityRepository(EntityDbContext entityDbContext) : base(entityDbContext)
        {
        }
    }
}
