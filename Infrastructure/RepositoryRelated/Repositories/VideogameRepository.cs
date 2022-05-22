using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Entities.Videogame;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Entities.VideogameCategories;
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
        public async Task<PageReturnDto<PagingGameDto>> GetAllGamesAsync(QueryParams model)
        {
            var count=await GetAllQuery().CountAsync();
            var chunk = await GetAllQuery()
                .Skip((model.Page - 1) * model.ItemsPerPage)
                .Take(model.ItemsPerPage)
                .Include(x => x.VideogameLikesEntities)
                .ToListAsync();
            var returnChunk= _mapper.Map<List<PagingGameDto>>(chunk);
            return new PageReturnDto<PagingGameDto>(returnChunk, count, model.Page, model.ItemsPerPage);
        }

        public async Task<VideogameEntity> GetEntityByIdForAddingImagesOnly(int gameId)
        {
            return await GetAllQuery().Where(x=>x.Id==gameId).Include(x=>x.videogameImagesEntities).FirstOrDefaultAsync();
        }

        public async Task<PageReturnDto<GameInformationForAdminDto>> InformationForAdminDto(QueryParams model)
        {
            var count = await GetAllQuery().CountAsync();
            var chunk=await GetAllQuery()
                .Skip((model.Page - 1) * model.ItemsPerPage)
                .Take(model.ItemsPerPage)
                //.Select(x => new {x.Id,x.VideogameName,x.videogameCategoryEntities})
                .Include(x=>x.videogameCategoryEntities)
                .ThenInclude(z=>z.Category)
                .ToListAsync();
            var returnChunk = new List<GameInformationForAdminDto>();
            chunk.ToList().ForEach(x =>
            {
                var item = new GameInformationForAdminDto();
                item.VideogameId = x.Id;
                item.VideogameName = x.VideogameName;
                x.videogameCategoryEntities.ForEach(z =>
                {
                    if (z.Category is not null)
                    { 
                        item.VideogamesCategories.Add(new() { Id = z.Category.Id, CategoryName = z.Category.CategoryName });
                    }
                   
                });
                returnChunk.Add(item);
            });
            return new PageReturnDto<GameInformationForAdminDto>(returnChunk, count, model.Page, model.ItemsPerPage);
        }

        public async Task<LoadGameDto> LoadGame(int id)
        {
            var item=await GetAllQuery().Where(x => x.Id == id).Include(x=>x.Publicsher).Include(x=>x.VideogameLikesEntities).FirstOrDefaultAsync();
          
            var returnDto=_mapper.Map<LoadGameDto>(item);
            return returnDto;
        }

        public  async Task<PageReturnDto<GameInformationForAdminDto>> SearchInformationForAdmin(QueryParams model, string NameSearchTerm)
        {
            var count = await GetAllQuery().Where(x=>x.VideogameName.Contains(NameSearchTerm)).CountAsync();
            var chunk = await GetAllQuery()
                .Where(x => x.VideogameName.Contains(NameSearchTerm))
                .Skip((model.Page - 1) * model.ItemsPerPage)
                .Take(model.ItemsPerPage)
                .Include(x => x.videogameCategoryEntities)
                .ThenInclude(z => z.Category)
                .ToListAsync();
            var returnChunk = new List<GameInformationForAdminDto>();
            chunk.ToList().ForEach(x =>
            {
                var item = new GameInformationForAdminDto();
                item.VideogameId = x.Id;
                item.VideogameName = x.VideogameName;
                x.videogameCategoryEntities.ForEach(z =>
                {
                    if (z.Category is not null)
                    {
                        item.VideogamesCategories.Add(new() { Id = z.Category.Id, CategoryName = z.Category.CategoryName });
                    }

                });
                returnChunk.Add(item);
            });
            return new PageReturnDto<GameInformationForAdminDto>(returnChunk, count, model.Page, model.ItemsPerPage);
        }

        public async Task<PageReturnDto<PagingGameDto>> SearchVideoGameAsync(VideoGameParameters videoGameParameters)
        {
            var query = GetAllQuery().Where(x => x.VideogameName.Contains(videoGameParameters.SearchTerm)
                            &&
                            x.Price >= videoGameParameters.MinPrice
                            &&
                            x.Price <= videoGameParameters.MaxPrice);
            var count=await query.CountAsync();
            var chunk=await query
                .Skip((videoGameParameters.Page - 1) * videoGameParameters.ItemsPerPage)
                .Take(videoGameParameters.ItemsPerPage)
                .Include(x => x.VideogameLikesEntities)
                .ToListAsync();
            var returnChunk = _mapper.Map<List<PagingGameDto>>(chunk);
            return new PageReturnDto<PagingGameDto>(returnChunk, count, videoGameParameters.Page, videoGameParameters.ItemsPerPage);
        }
    }
}
