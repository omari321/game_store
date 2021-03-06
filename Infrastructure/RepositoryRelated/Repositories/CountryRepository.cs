using Infrastructure.Entities;
using Infrastructure.Entities.Country;
using Infrastructure.Repositories;
using Infrastructure.RepositoryRelated.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.Repositories
{
    public class CountryRepository : RepositoryBase<CountryEntity>, ICountryRepository
    {
        public CountryRepository(EntityDbContext entityDbContext) : base(entityDbContext)
        {
        }
    }
}
