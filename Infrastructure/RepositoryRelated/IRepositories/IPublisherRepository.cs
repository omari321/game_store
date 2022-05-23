using Infrastructure.Entities.Publisher;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.IRepositories
{
    public interface IPublisherRepository:IRepositoryBase<PublisherEntity>
    {
        Task<PageReturnDto<PagingGameDto>> GetGamesByPublisherAsync(QueryParams model, Expression<Func<PublisherEntity, bool>> expression);
    }
}
