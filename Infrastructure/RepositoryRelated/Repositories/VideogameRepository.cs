using Infrastructure.Entities;
using Infrastructure.Entities.Videogame;
using Infrastructure.Repositories;
using Infrastructure.RepositoryRelated.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.Repositories
{
    public class VideogameRepository : RepositoryBase<VideogameEntity>, IVideogameRepository
    {
        public VideogameRepository(EntityDbContext entityDbContext) : base(entityDbContext)
        {
        }
    }
}
