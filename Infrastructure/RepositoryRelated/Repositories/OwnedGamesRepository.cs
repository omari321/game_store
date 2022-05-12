using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Entities.OwnedGames;
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
    public class OwnedGamesRepository : RepositoryBase<OwnedGamesEntity>, IOwnedGamesRepository
    {
        private readonly IMapper _mapper;
        public OwnedGamesRepository(EntityDbContext entityDbContext,IMapper mapper) : base(entityDbContext)
        {
                _mapper = mapper;
        }
        public async Task<PageReturnDto<GameNamesDto>> GetOwnedGames(QueryParams model, int userId)
        {
            var count = await GetAllQuery().Where(x => x.UserId == userId).CountAsync();
            var items = await GetAllQuery()
                .Where(x => x.UserId == userId)
                .Include(x => x.Videogame)
                .Skip((model.Page - 1) * model.ItemsPerPage)
                .Take(model.ItemsPerPage)
                .ToListAsync();
            return new PageReturnDto<GameNamesDto>(_mapper.Map<IEnumerable<GameNamesDto>>(items), count, model.Page, model.ItemsPerPage);
        }
    }
}
