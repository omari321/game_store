using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Entities.VideogameCategories;
using Infrastructure.Paging;
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
        Task<PageReturnDto<PagingGameDto>> GetGamesByCategory(QueryParams model, Expression<Func<VideogameCategoryEntity, bool>> expression);
        Task<List<VideogameCategoryEntity>> GetCategoriesByGame(Expression<Func<VideogameCategoryEntity, bool>> expression);
        Task<PageReturnDto<PagingGameDto>> SearchGamesByCategory(VideoGameParameters model, Expression<Func<VideogameCategoryEntity, bool>> expression);
    }
}
