using Infrastructure.Entities;
using Infrastructure.Entities.Publisher;
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
    public class PublisherRepository : RepositoryBase<PublisherEntity>, IPublisherRepository
    {
        public PublisherRepository(EntityDbContext entityDbContext) : base(entityDbContext)
        {
        }

        public async Task<PublisherEntity> GetGamesByPublisherAsync(Expression<Func<PublisherEntity, bool>> expression)
        {
            return await GetAllQuery().Where(expression).Include(x => x.videoGameEntities).FirstAsync();
        }
    }
}
