using Infrastructure.Entities.Publisher;
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
        Task<PublisherEntity> GetGamesByPublisherAsync(Expression<Func<PublisherEntity, bool>> expression);
    }
}
