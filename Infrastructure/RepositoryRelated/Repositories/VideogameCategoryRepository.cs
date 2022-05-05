using Infrastructure.Entities;
using Infrastructure.Entities.VideogameCategories;
using Infrastructure.Repositories;
using Infrastructure.RepositoryRelated.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.Repositories
{
    public class VideogameCategoryRepository : RepositoryBase<VideogameCategoryEntity>, IVideogameCategoryRepository
    {
        public VideogameCategoryRepository(EntityDbContext entityDbContext) : base(entityDbContext)
        {
        }

        public async Task<List<VideogameCategoryEntity>> GetCategoriesByGame(Expression<Func<VideogameCategoryEntity, bool>> expression)
        {
            return await GetAllQuery().Where(expression).Include(x=>x.Category).ToListAsync();
        }

        public async Task<List<VideogameCategoryEntity>> GetGamesByCategory(Expression<Func<VideogameCategoryEntity, bool>> expression)
        {
            return await GetAllQuery().Where(expression).Include(x => x.Game).ToListAsync();
        }
    }
}
