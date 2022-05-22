using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Entities.VideogameCategories;
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
    public class VideogameCategoryRepository : RepositoryBase<VideogameCategoryEntity>, IVideogameCategoryRepository
    {
        private readonly IMapper _mapper;
        public VideogameCategoryRepository(EntityDbContext entityDbContext,IMapper mapper) : base(entityDbContext)
        {
            _mapper = mapper;
        }

        public async Task<List<VideogameCategoryEntity>> GetCategoriesByGame(Expression<Func<VideogameCategoryEntity, bool>> expression)
        {
            return await GetAllQuery().Where(expression).Include(x=>x.Category).ToListAsync();
        }

        public async Task<PageReturnDto<PagingGameDto>> GetGamesByCategory(QueryParams model, Expression<Func<VideogameCategoryEntity, bool>> expression)
        {
            var count= await GetAllQuery().Where(expression).CountAsync();
            var item=await GetAllQuery().Where(expression)
                .Include(x => x.Videogame)
                .ThenInclude(x=>x.VideogameLikesEntities)
                .Skip((model.Page - 1) * model.ItemsPerPage)
                .Take(model.ItemsPerPage)
                .ToListAsync();
            var Dto = item.Select(x =>
            {
                return _mapper.Map<PagingGameDto>(x.Videogame);
            }); 
            return new PageReturnDto<PagingGameDto>(Dto, count, model.Page, model.ItemsPerPage);
        }

        public async Task<PageReturnDto<PagingGameDto>> SearchGamesByCategory(VideoGameParameters model, Expression<Func<VideogameCategoryEntity, bool>> expression)
        {
            var count = await GetAllQuery().Where(expression).CountAsync();
            var item = await GetAllQuery().Where(expression)
                .Include(x => x.Videogame)
                .ThenInclude(x => x.VideogameLikesEntities)
                .Where(x => x.Videogame.VideogameName.Contains(model.SearchTerm)
                            &&
                            x.Videogame.Price >= model.MinPrice
                            &&
                            x.Videogame.Price <= model.MaxPrice)
                .Skip((model.Page - 1) * model.ItemsPerPage)
                .Take(model.ItemsPerPage)
                .ToListAsync();
            var Dto = item.Select(x =>
            {
                return _mapper.Map<PagingGameDto>(x.Videogame);
            });
            return new PageReturnDto<PagingGameDto>(Dto, count, model.Page, model.ItemsPerPage);
        }
    }
}
