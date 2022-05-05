using Application.Exceptions;
using AutoMapper;
using Infrastructure.Entities.Videogame;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Paging;
using Infrastructure.RepositoryRelated.IRepositories;
using Infrastructure.UnitOfWorkRepo;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Videogame
{
    public class VideogameService : IVideogameService
    {
        private readonly BasePath _basePath;
        private readonly IVideogameRepository _videogameRepository;
        private const string BaseFilePath = @"Images\Games";
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public VideogameService(BasePath basePath, IUnitOfWork unitOfWork,IVideogameRepository videogameRepository,IMapper mapper)
        {
                _basePath= basePath;
                _unitOfWork=unitOfWork;
                _videogameRepository=videogameRepository;
                _mapper=mapper;
        }
        private async Task<VideogameEntity> GetGameByName(string name)
        {
            return await _videogameRepository.FindByConditionAsync(x => x.VideogameName == name);
        }
        private async Task<bool> CheckIfExists(string name)
        {
            return await _videogameRepository.CheckIfAnyByConditionAsync(x => x.VideogameName == name); 
        }
        public async Task AddGame(AddGameDto model)
        {
            var exists = await CheckIfExists(model.VideogameName);
            if (exists)
            {
                throw new CustomException("game with this name already exists", 400);
            }
            if (model.File.Length>8_200_000)
            {
                throw new CustomException("Image too big", 400);
            }
            var FileName= Path.GetRandomFileName().Split(".").ToArray()[0];
            var fullPath = Path.Combine(_basePath.ContentRootPath, BaseFilePath, FileName+Path.GetExtension(model.File.FileName));
            await using (var fileStreams = new FileStream(fullPath,FileMode.Create))
            {
                await model.File.CopyToAsync(fileStreams);
            }
            var newGame = _mapper.Map<VideogameEntity>(model);
            newGame.ImageUrl = fullPath;
            await _videogameRepository.CreateAsync(newGame);
            await _unitOfWork.CompleteAsync();
        }
        public async Task UpdateGame(UpdateGameDto model)
        {
            var game = await GetGameByName(model.VideoGameName);
            if (game==null)
            {
                throw new CustomException("this game does not exist", 400);
            }
            if (model.File.Length > 8_200_000)
            {
                throw new CustomException("Image too big", 400);
            }
            var FileName = Path.GetRandomFileName().Split(".").ToArray()[0];
            var fullPath = Path.Combine(_basePath.ContentRootPath, BaseFilePath, FileName + Path.GetExtension(model.File.FileName));
            await using (var fileStreams = new FileStream(fullPath, FileMode.Create))
            {
                await model.File.CopyToAsync(fileStreams);
            }
            if (game.ImageUrl!=null)
            {
                File.Delete(game.ImageUrl);
            }
            var oldPrice = game.Price;

            game.Price=model.Price??game.Price;
            game.OldPrice = game.OldPrice != null ? game.OldPrice : oldPrice;
            game.Description = model.Description??game.Description;
            game.VideogameName = model.VideoGameName ?? game.VideogameName;
            game.ImageUrl = fullPath;
            await _unitOfWork.CompleteAsync();
        } 
        public async Task<List<GameNamesDto>> GetNames()
        {
            var items = await _videogameRepository.GetAllAsync();
            return _mapper.Map<List<GameNamesDto>>(items);
        }
        public async Task<VideogameEntity> VisitGame(int id)
        {
            throw new NotImplementedException();
            // return await _videogameRepository.FindByConditionAsync(x => x.Id == id);
        }

        public async Task<PageReturnDto<ReturnGameDto>> GetAllAsync(QueryParams model)
        {
            return await _videogameRepository.GetAllGamesAsync(model);
        }

        public async Task<PageReturnDto<ReturnGameDto>> SearchGames(VideoGameParameters videoGameParameters)
        {
            return await _videogameRepository.SearchVideoGameAsync(videoGameParameters);
        }


    }
}
