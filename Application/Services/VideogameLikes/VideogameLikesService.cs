using Application.Exceptions;
using Infrastructure.Entities.VideogameLikes.Dtos;
using Infrastructure.Entities.VideogameLikesList;
using Infrastructure.Entities.VideogameLikesList.Dtos;
using Infrastructure.Paging;
using Infrastructure.RepositoryRelated.IRepositories;
using Infrastructure.UnitOfWorkRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.VideogameLikes
{
    public class VideogameLikesService : IVideogameLikesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVideogameRepository _videogameRepository;
        private readonly IVideogameLikesRepository _videogameLikesRepository;
        private readonly IOwnedGamesRepository _ownedGamesRepository;
        private readonly IVideogameLikesListRepository _videogameLikesListRepository;

        public VideogameLikesService(IUnitOfWork unitOfWork, 
            IVideogameRepository videogameRepository,
            IVideogameLikesRepository videogameLikesRepository,
            IVideogameLikesListRepository videogameLikesListRepository,
            IOwnedGamesRepository ownedGamesRepository)
        {
            _unitOfWork = unitOfWork;
            _videogameRepository = videogameRepository;
            _videogameLikesRepository = videogameLikesRepository;
            _videogameLikesListRepository = videogameLikesListRepository;
            _ownedGamesRepository = ownedGamesRepository;
        }

        public async Task<CheckIFuserLikedDto> CheckIfLikes(int userId, int videogameId)
        {
            var isLiked = await _videogameLikesListRepository.FindByConditionAsync(x => x.UserId == userId && x.VideogameId == videogameId);
            if (isLiked == null)
            {
                return null;
            }
            return  new CheckIFuserLikedDto
            {
                IsLike=isLiked.IsLike,
                VideogameId=videogameId,
                UserId=userId
            };
        }

        public async Task<PageReturnDto<UserGameIsLikedDto>> GetUserLikedGamesAsync(QueryParams model, int userId)
        {
            return await _videogameLikesListRepository.GetUserLikedGamesAsync(model,userId);
        }

        public async Task<VideogameLikesReturnDto> LikeDislikeRemoveBothVideogame(int userId, int videogameId, LikeDislikeDto model)
        {
            if (!await _videogameRepository.CheckIfMeetsAnyConditionAsync(x=>x.Id==videogameId))
            {
                throw new CustomException("game with this id does not exist ", 404);
            }
            
            var gameLikes = await _videogameLikesRepository.FindByConditionAsync(x => x.VideogameId==videogameId);
            var UserLike = await _videogameLikesListRepository.FindByConditionAsync(x => x.VideogameId == videogameId && x.UserId == userId);
            #region ifuserLikeNull
            if (UserLike == null)
            {
                if (!await _ownedGamesRepository.CheckIfMeetsAnyConditionAsync(x=>x.UserId==userId&&videogameId==videogameId))
                {
                    throw new CustomException("user does not own this game", 400);
                }
                if (!model.IsLike.HasValue)
                {
                    return new VideogameLikesReturnDto
                    {
                        VideogameId = videogameId,
                        Likes=gameLikes.LikesCount,
                        Dislikes=gameLikes.DislikesCount,
                    };
                }
                if ((bool)model.IsLike==true)
                {
                    gameLikes.LikesCount += 1;
                    gameLikes.DateUpdated = DateTime.Now;
                    await _videogameLikesListRepository.CreateAsync(
                        new VideogameLikesListEntity
                        {
                            IsLike = (bool)model.IsLike,
                            VideogameId=videogameId,
                            UserId=userId,
                            DateCreated=DateTime.Now,
                        }
                        );
                    await _unitOfWork.CompleteAsync();
                    return new VideogameLikesReturnDto
                    {
                        VideogameId = videogameId,
                        Likes = gameLikes.LikesCount,
                        Dislikes = gameLikes.DislikesCount,
                    };
                }
                gameLikes.DislikesCount += 1;
                gameLikes.DateUpdated = DateTime.Now;
                await _videogameLikesListRepository.CreateAsync(
                    new VideogameLikesListEntity
                    {
                        IsLike = (bool)model.IsLike,
                        VideogameId = videogameId,
                        UserId = userId,
                        DateCreated = DateTime.Now,
                    }
                    );
                await _unitOfWork.CompleteAsync();
                return new VideogameLikesReturnDto
                {
                    VideogameId = videogameId,
                    Likes = gameLikes.LikesCount,
                    Dislikes = gameLikes.DislikesCount,
                };
            }
            #endregion
            #region IFNotNull
            if (!model.IsLike.HasValue)
            {
                if (UserLike.IsLike)
                {
                    gameLikes.LikesCount -= 1;
                }
                else
                {
                    gameLikes.DislikesCount-=1;
                }
                await _videogameLikesListRepository.Delete(UserLike);
                await _unitOfWork.CompleteAsync();
                return new VideogameLikesReturnDto
                {
                    VideogameId = videogameId,
                    Likes = gameLikes.LikesCount,
                    Dislikes = gameLikes.DislikesCount,
                };
            }
            if ((bool)model.IsLike==UserLike.IsLike)
            {
                return new VideogameLikesReturnDto
                {
                    VideogameId = videogameId,
                    Likes = gameLikes.LikesCount,
                    Dislikes = gameLikes.DislikesCount,
                };
            }
            if ((bool)model.IsLike)
            {
                gameLikes.DislikesCount -= 1;
                gameLikes.LikesCount += 1;
                gameLikes.DateUpdated = DateTime.Now;
                
            }
            else
            {
                gameLikes.DislikesCount += 1;
                gameLikes.LikesCount -= 1;
                gameLikes.DateUpdated = DateTime.Now;
            }
            UserLike.IsLike = (bool)model.IsLike;
            UserLike.DateUpdated = DateTime.Now;
            await _unitOfWork.CompleteAsync();
            return  new VideogameLikesReturnDto
            {
                VideogameId = videogameId,
                Likes = gameLikes.LikesCount,
                Dislikes = gameLikes.DislikesCount,
            };
            #endregion
        }

    }
}
