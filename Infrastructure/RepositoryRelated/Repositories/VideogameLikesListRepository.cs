using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Entities.VideogameLikesList;
using Infrastructure.Entities.VideogameLikesList.Dtos;
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
    public class VideogameLikesListRepository : RepositoryBase<VideogameLikesListEntity>, IVideogameLikesListRepository
    {
        
        private readonly IMapper _mapper;
        public VideogameLikesListRepository(IMapper mapper,EntityDbContext entityDbContext) : base(entityDbContext)
        {
            _mapper = mapper;
        }
        
        public async Task<PageReturnDto<UserGameIsLikedDto>> GetUserLikedGamesAsync(QueryParams model, int userId)
        {
            var returnChunk =   await GetAllQuery()
                        .Where(x => x.UserId == userId)
                        .Skip((model.Page - 1) * model.ItemsPerPage)
                        .Take(model.ItemsPerPage)
                        .ToListAsync();
            var count = await GetAllQuery()
                        .Where(x => x.UserId == userId)
                        .CountAsync();
            return new PageReturnDto<UserGameIsLikedDto>(_mapper.Map<IEnumerable<UserGameIsLikedDto>>(returnChunk), count, model.Page, model.ItemsPerPage);
        }
    }
}
