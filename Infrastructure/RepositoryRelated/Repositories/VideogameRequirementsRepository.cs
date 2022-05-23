using Infrastructure.Entities;
using Infrastructure.Entities.VideogameRequirements;
using Infrastructure.Repositories;
using Infrastructure.RepositoryRelated.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.Repositories
{
    public class VideogameRequirementsRepository : RepositoryBase<VideogameRequirementsEntity>, IVideogameRequirementsRepository
    {
        public VideogameRequirementsRepository(EntityDbContext entityDbContext) : base(entityDbContext)
        {
        }
    }
}
