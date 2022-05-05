using Infrastructure.Entities.VideogameCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.IRepositories
{
    public interface IVideogameCategoryRepository : IRepositoryBase<VideogameCategoryEntity>
    {
        Task<List<VideogameCategoryEntity>> GetGamesByCategory(Expression<Func<VideogameCategoryEntity, bool>> expression);
        Task<List<VideogameCategoryEntity>> GetCategoriesByGame(Expression<Func<VideogameCategoryEntity, bool>> expression);
    }
}
