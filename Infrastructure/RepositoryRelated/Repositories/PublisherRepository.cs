using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Entities.Publisher;
using Infrastructure.Entities.Publisher.Dto;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Paging;
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
        private readonly IMapper _mapper;
        public PublisherRepository(EntityDbContext entityDbContext,IMapper mapper) : base(entityDbContext)
        {
            _mapper = mapper;
        }

        public async Task<PageReturnDto<ReturnGameDto>> GetGamesByPublisherAsync(QueryParams model, Expression<Func<PublisherEntity, bool>> expression)
        {
            var count=await GetAllQuery().Where(expression).CountAsync();
            var item= await GetAllQuery().Where(expression)
                .Skip((model.Page - 1) * model.ItemsPerPage)
                .Take(model.ItemsPerPage)
                .Include(x => x.videoGameEntities).FirstAsync();
            var Dto = _mapper.Map<IEnumerable<ReturnGameDto>>(item.videoGameEntities);
            return new PageReturnDto<ReturnGameDto>(Dto,count, model.Page,model.ItemsPerPage);
        }
    }
}
