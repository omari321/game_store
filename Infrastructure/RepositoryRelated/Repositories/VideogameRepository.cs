using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Entities.Videogame;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Paging;
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
    public class VideogameRepository : RepositoryBase<VideogameEntity>, IVideogameRepository
    {
        private readonly IMapper _mapper;
        public VideogameRepository(EntityDbContext entityDbContext,IMapper mapper) : base(entityDbContext)
        {
            _mapper = mapper;
        }
        public async Task<PageReturnDto<ReturnGameDto>> GetAllGamesAsync(QueryParams model)
        {
            var count=await GetAllQuery().CountAsync();
            var chunk = await GetAllQuery()
                .Skip((model.Page - 1) * model.ItemsPerPage)
                .Take(model.ItemsPerPage)
                .ToListAsync();
            var returnChunk= _mapper.Map<List<ReturnGameDto>>(chunk);
            return new PageReturnDto<ReturnGameDto>(returnChunk, count, model.Page, model.ItemsPerPage);
        }
        public async Task<PageReturnDto<ReturnGameDto>> SearchVideoGameAsync(VideoGameParameters videoGameParameters)
        {
            var query = GetAllQuery().Where(x => x.VideogameName.Contains(videoGameParameters.SearchTerm)
                            &&
                            x.Price > videoGameParameters.MinPrice
                            &&
                            x.Price < videoGameParameters.MaxPrice);
            //if (videoGameParameters.CategoryId!=null)
            //{
            //   // query=query.Include(x => x.videogameCategoryEntities.Where(c => c.CategoryId == videoGameParameters.CategoryId));
            //}
            var count=await query.CountAsync();
            var chunk=await query
                .Skip((videoGameParameters.Page - 1) * videoGameParameters.ItemsPerPage)
                .Take(videoGameParameters.ItemsPerPage)
                .ToListAsync();
            var returnChunk = _mapper.Map<List<ReturnGameDto>>(chunk);
            return new PageReturnDto<ReturnGameDto>(returnChunk, count, videoGameParameters.Page, videoGameParameters.ItemsPerPage);
        }
    }
}
