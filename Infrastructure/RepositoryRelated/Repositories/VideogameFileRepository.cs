using Infrastructure.Entities;
using Infrastructure.Entities.VideogameFile;
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
    public class VideogameFileRepository : RepositoryBase<VideogameFilesEntity>, IVideogameFileRepository
    {
        public VideogameFileRepository(EntityDbContext entityDbContext) : base(entityDbContext)
        {
        }

        public async Task<VideogameFilesEntity> GetLatestVersion(int videoGameId)
        {
            return await GetAllQuery().Where(x => x.VideogameId == videoGameId).OrderByDescending(x => x.DateCreated).FirstOrDefaultAsync();
        }
    }
}
