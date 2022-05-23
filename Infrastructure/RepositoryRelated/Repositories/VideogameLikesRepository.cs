using Infrastructure.Entities;
using Infrastructure.Entities.VideogameLikes;
using Infrastructure.Repositories;
using Infrastructure.RepositoryRelated.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.Repositories
{
    public class VideogameLikesRepository : RepositoryBase<VideogameLikesEntity>, IVideogameLikesRepository
    {
        public VideogameLikesRepository(EntityDbContext entityDbContext) : base(entityDbContext)
        {
        }
    }
}
