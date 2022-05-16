using Application.BackgroundQueue;
using Application.BackgroundQueue.ImageProcessors.Dtos;
using Application.Exceptions;
using AutoMapper;
using Infrastructure.Entities.Videogame;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Paging;
using Infrastructure.RepositoryRelated.IRepositories;
using Infrastructure.UnitOfWorkRepo;
using Microsoft.AspNetCore.Http;
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
        private readonly IVideogameRepository _videogameRepository;
        private readonly BasePath _basePath;
        private const string BaseImagePath = @"Images\Games";
        private const string BaseFilePath = @"Files";
        private  readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPEG", ".JPE", ".BMP", ".GIF", ".PNG" };
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBackgroundQueue<ThumbnailUpdateDto> _queue;
        private readonly IMapper _mapper;
        public VideogameService(BasePath basePath, IUnitOfWork unitOfWork,IVideogameRepository videogameRepository,IMapper mapper
            ,IBackgroundQueue<ThumbnailUpdateDto> queue)
        {
                _basePath= basePath;
                _unitOfWork=unitOfWork;
                _videogameRepository=videogameRepository;
                _mapper=mapper;
                _queue=queue;
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
            if (model.Price<0)
            {
                throw new CustomException("Game price must be no less than zero", 400);
            }
            var exists = await CheckIfExists(model.VideogameName);
            if (exists)
            {
                throw new CustomException("game with this name already exists", 400);
            }
            else if (model.File.Length>8_200_000)
            {
                throw new CustomException("Image too big", 400);
            }
            else if (!ImageExtensions.Contains(Path.GetExtension(model.File.FileName).ToUpper()))
            {
                throw new CustomException("unsaported image type", 400);
            }
            var temporaryFileName= Path.GetRandomFileName().Split(".").ToArray()[0];
            var temporaryFullPath = Path.Combine(_basePath.ContentRootPath, BaseImagePath, temporaryFileName+Path.GetExtension(model.File.FileName));
            await using (var fileStreams = new FileStream(temporaryFullPath,FileMode.Create))
            {
                await model.File.CopyToAsync(fileStreams);
            }
            var newGame = _mapper.Map<VideogameEntity>(model);
            newGame.ThumbnailUrl = temporaryFullPath;
            await _videogameRepository.CreateAsync(newGame);
            await _unitOfWork.CompleteAsync();
            var newFilename= Path.GetRandomFileName().Split(".").ToArray()[0];
            var newFullPath = Path.Combine(_basePath.ContentRootPath, BaseImagePath, newFilename + Path.GetExtension(model.File.FileName));
            _queue.Enqueue(new ThumbnailUpdateDto {VideogameId=newGame.Id,ThumbnailFilePath=temporaryFullPath,NewPath= newFullPath });
        }
        public async Task UpdateGame(UpdateGameDto model)
        {
            if (model.Price < 0)
            {
                throw new CustomException("New Game price must be no less than zero", 400);
            }
            var game = await GetGameByName(model.VideoGameName);
            if (game==null)
            {
                throw new CustomException("this game does not exist", 404);
            }
            else if (model.File.Length > 8_200_000)
            {
                throw new CustomException("Image too big", 400);
            }
            else if (!ImageExtensions.Contains(Path.GetExtension(model.File.FileName).ToUpper()))
            {
                throw new CustomException("unsaported image type", 400);
            }

            if (model.File!=null)
            {
                var FileName = Path.GetRandomFileName().Split(".").ToArray()[0];
                var fullPath = Path.Combine(_basePath.ContentRootPath, BaseImagePath, FileName + Path.GetExtension(model.File.FileName));
                await using (var fileStreams = new FileStream(fullPath, FileMode.Create))
                {
                    await model.File.CopyToAsync(fileStreams);
                }
                if (game.ThumbnailUrl!=null)
                {
                    File.Delete(game.ThumbnailUrl);
                } 
                game.ThumbnailUrl = fullPath;
            }
          
            
            var oldPrice = game.Price;
            game.Price=model.Price??game.Price;
            game.OldPrice = game.OldPrice != null ? game.OldPrice : oldPrice;
            game.Description = model.Description??game.Description;
            game.VideogameName = model.VideoGameName ?? game.VideogameName;
           
            await _unitOfWork.CompleteAsync();
        } 
        public async Task<List<GameNamesDto>> GetNames()
        {
            var items = await _videogameRepository.GetAllAsync();
            return _mapper.Map<List<GameNamesDto>>(items);
        }

        public async Task<PageReturnDto<PagingGameDto>> GetAllAsync(QueryParams model)
        {
            return await _videogameRepository.GetAllGamesAsync(model);
        }

        public async Task<PageReturnDto<PagingGameDto>> SearchGames(VideoGameParameters videoGameParameters)
        {
            return await _videogameRepository.SearchVideoGameAsync(videoGameParameters);
        }

        

         public async Task<PageReturnDto<GameInformationForAdminDto>> InformationForAdminDto(QueryParams model)
        {
            return await _videogameRepository.InformationForAdminDto(model);
        }

        public async Task<PageReturnDto<GameInformationForAdminDto>> SearchInformationForAdmin(QueryParams model, string NameSearchTerm)
        {
            return await _videogameRepository.SearchInformationForAdmin(model, NameSearchTerm);
        }

        public async Task<bool> UploadGame(IFormFile file)
        {
            var FileName = Path.GetRandomFileName().Split(".").ToArray()[0];
            var fullPath = Path.Combine(_basePath.ContentRootPath, BaseFilePath, FileName+ Path.GetExtension(file.FileName));
            await using (var fileStreams = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStreams);
            }
            return true;
        }     
        public async Task<LoadGameDto> LoadGame(int id)
        {
            var checkIfExists = await _videogameRepository.CheckIfAnyByConditionAsync(x => x.Id == id);
            if (!checkIfExists)
            {
                throw new CustomException("this game does not exist", 404);
            }
            var loadedGame = await _videogameRepository.LoadGame(id);
            return loadedGame;
        }


        public Task<bool> DownloadGame(IFormFile File)
        {
            throw new NotImplementedException();
        }

    }
}