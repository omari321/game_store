using Application.BackgroundQueue;
using Application.BackgroundQueue.ImageProcessors.Dtos;
using Application.Exceptions;
using AutoMapper;
using Infrastructure.Entities.Videogame;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Entities.VideogameFile;
using Infrastructure.Entities.VideogameFile.Dtos;
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
        private readonly BasePath _basePath;
        private readonly BaseUrl _baseUrl;
        private const string BaseImagePath = @"wwwroot/Images/Games";
        private const string BaseImageUrl = @"/Images/Games/";
        private const string BaseFilePath = @"Files";
        private  readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPEG", ".JPE", ".BMP", ".GIF", ".PNG" };
        private readonly IVideogameRepository _videogameRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBackgroundQueue<ThumbnailUpdateDto> _queue;
        private readonly IVideogameFileRepository _videogameFileRepository;
        private readonly IOwnedGamesRepository _ownedGamesRepository;
        private readonly IMapper _mapper;
        public VideogameService(BasePath basePath,
                                BaseUrl baseUrl,
                                IUnitOfWork unitOfWork,
                                IVideogameRepository videogameRepository,
                                IMapper mapper,
                                IBackgroundQueue<ThumbnailUpdateDto> queue,
                                IOwnedGamesRepository ownedGamesRepository,
                                IVideogameFileRepository videogameFileRepository)
        {
                            _basePath= basePath;
                            _baseUrl= baseUrl;
                            _unitOfWork=unitOfWork;
                            _videogameRepository=videogameRepository;
                            _mapper=mapper;
                            _queue=queue;
                            _videogameFileRepository=videogameFileRepository;
                            _ownedGamesRepository = ownedGamesRepository;
        }
        private async Task<VideogameEntity> GetGameByName(string name)
        {
            return await _videogameRepository.FindByConditionAsync(x => x.VideogameName == name);
        }
        private async Task<bool> CheckIfExists(string name)
        {
            return await _videogameRepository.CheckIfMeetsAnyConditionAsync(x => x.VideogameName == name); 
        }
        public async Task<PagingGameDto> AddGame(AddGameDto model)
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
            var temporaryFileUrl= _baseUrl.applicationUrl+ BaseImageUrl + temporaryFileName+Path.GetExtension(model.File.FileName);
            await using (var fileStreams = new FileStream(temporaryFullPath,FileMode.Create))
            {
                await model.File.CopyToAsync(fileStreams);
            }


            var newGame = _mapper.Map<VideogameEntity>(model);


            newGame.ThumbnailPath = temporaryFullPath;
            newGame.ThumbnailUrl = temporaryFileUrl;


            await _videogameRepository.CreateAsync(newGame);
            await _unitOfWork.CompleteAsync();


            var newFilename= Path.GetRandomFileName().Split(".").ToArray()[0];
            var newFullPath = Path.Combine(_basePath.ContentRootPath, BaseImagePath, newFilename + Path.GetExtension(model.File.FileName));
            var newFileUrl = _baseUrl.applicationUrl + BaseImageUrl + newFilename + Path.GetExtension(model.File.FileName);


            _queue.Enqueue(new ThumbnailUpdateDto {VideogameId=newGame.Id,ThumbnailFilePath=temporaryFullPath,NewThumbnailUrl=newFileUrl,NewPath= newFullPath });
            return new PagingGameDto
            {
                Id=newGame.Id,
                VideogameName=newGame.VideogameName,
                Price=newGame.Price,
                OldPrice=newGame.OldPrice,
                PublicsherId=newGame.PublicsherId,
                Description =newGame.Description,
                ThumbnailUrl =newGame.ThumbnailUrl
            };

        }
        public async Task<PagingGameDto> UpdateGame(UpdateGameDto model)
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
                var newFileUrl = _baseUrl.applicationUrl + BaseImageUrl + FileName + Path.GetExtension(model.File.FileName);
                await using (var fileStreams = new FileStream(fullPath, FileMode.Create))
                {
                    await model.File.CopyToAsync(fileStreams);
                }
                if (game.ThumbnailPath!=null)
                {
                    File.Delete(game.ThumbnailPath);
                } 
                game.ThumbnailPath = fullPath;
                game.ThumbnailUrl= newFileUrl;
            }
          
            
            var oldPrice = game.Price;
            game.Price=model.Price??game.Price;
            game.OldPrice = game.OldPrice != null ? game.OldPrice : oldPrice;
            game.Description = model.Description??game.Description;
            game.VideogameName = model.VideoGameName ?? game.VideogameName;
           
            await _unitOfWork.CompleteAsync();
            return   new PagingGameDto
            {
                Id = game.Id,
                VideogameName = game.VideogameName,
                Price = game.Price,
                OldPrice = game.OldPrice,
                PublicsherId = game.PublicsherId,
                Description = game.Description,
            };
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


        public async Task<LoadGameDto> LoadGame(int id)
        {
            var checkIfExists = await _videogameRepository.CheckIfMeetsAnyConditionAsync(x => x.Id == id);
            if (!checkIfExists)
            {
                throw new CustomException("this game does not exist", 404);
            }
            var loadedGame = await _videogameRepository.LoadGame(id);
            return loadedGame;
        }

        public async Task<VideogameFileReturnDto> UploadGame(UploadVideogameFileDto model)
        {
            var exists = await _videogameRepository.CheckIfMeetsAnyConditionAsync(x => x.Id == model.VideogameId);
            if (!exists)
            {
                throw new CustomException("game with this id does not exist", 404);
            }
            var gameFile = await _videogameFileRepository.GetLatestVersion(model.VideogameId);
            int version=0;
            if (gameFile != null)
            {
                version = gameFile.Version;
            }
            version += 1;
            var FileName = Path.GetRandomFileName().Split(".").ToArray()[0];
            var fullPath = Path.Combine(_basePath.ContentRootPath, BaseFilePath, FileName+ Path.GetExtension(model.formFile.FileName));
            await using (var fileStreams = new FileStream(fullPath, FileMode.Create))
            {
                await model.formFile.CopyToAsync(fileStreams);
            }
            var file = new VideogameFilesEntity
            {
                VideogameId=model.VideogameId,
                VideogameFilePath=fullPath,
                FileName=FileName + Path.GetExtension(model.formFile.FileName),
                Version=version,
                DateCreated=DateTime.Now,
            };
            await _videogameFileRepository.CreateAsync(file);
            await _unitOfWork.CompleteAsync();
            return new VideogameFileReturnDto
            {
                VideogameId= model.VideogameId,
                FileName= FileName + Path.GetExtension(model.formFile.FileName),
                VideogameFilePath =fullPath,
                Version=version
            };
        }     
        public async Task<byte[]> DownloadGame(int userId,int videogameId)
        {
            var owns = await _ownedGamesRepository.CheckIfMeetsAnyConditionAsync(x => x.UserId == userId && x.VideogameId == videogameId);
            if (!owns)
            {
                throw new CustomException("this user does not own this game", 400);
            }
            var gameFile = await _videogameFileRepository.GetLatestVersion(videogameId);
            if (gameFile==null)
            {
                throw new CustomException("this game does not have download file yet sorry :(", 400);
            }
            using (var stream = new FileStream(gameFile.VideogameFilePath,FileMode.Open,FileAccess.Read))
            {
                byte[] buffer = new byte[16 * 1024];
                using (MemoryStream ms = new MemoryStream())
                {
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    return ms.ToArray();
                }
            }
            //return new VideogameFileReturnDto
            //{
            //    VideogameFilePath = game.VideogameFilePath,
            //    FileName = game.FileName,
            //};
        }

        public async Task<string> ValidateFileDownload(int userId, int videogameId)
        {
            var GameEntity = await _videogameRepository.FindByConditionAsync(x => x.Id == videogameId);
            if (GameEntity==null)
            {
                throw new CustomException("game with this id does not exist", 404);
            }
            var owns = await _ownedGamesRepository.CheckIfMeetsAnyConditionAsync(x => x.UserId == userId && x.VideogameId == videogameId);
            if (!owns)
            {
                throw new CustomException("this user does not own this game", 400);
            }
            var gameFile = await _videogameFileRepository.GetLatestVersion(videogameId);
            if (gameFile == null)
            {
                throw new CustomException("this game does not have download file yet sorry :(", 400);
            }
            return GameEntity.VideogameName + Path.GetExtension(gameFile.VideogameFilePath);
        }
    }
}