using Infrastructure.Entities;
using Infrastructure.Entities.VideogameImages;
using Infrastructure.Repositories;
using Infrastructure.RepositoryRelated.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.Repositories
{
    public class VideogameImagesRepository : RepositoryBase<VideogameImagesEntity>, IVideogameImagesRepository
    {
        public VideogameImagesRepository(EntityDbContext entityDbContext) : base(entityDbContext)
        {
        }

        public async Task<IEnumerable<VideogameImagesEntity>> GetVideogameImages(int videogameId)
        {
            return await GetAllQuery().Where(x => x.VideogameId == videogameId).ToListAsync();
        }
    }
}
