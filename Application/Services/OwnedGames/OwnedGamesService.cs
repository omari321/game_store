using Application.Exceptions;
using Infrastructure.Entities.OwnedGames;
using Infrastructure.Entities.Transactions;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Entities.VideogameTransaction;
using Infrastructure.EntityEnums;
using Infrastructure.Paging;
using Infrastructure.RepositoryRelated.IRepositories;
using Infrastructure.UnitOfWorkRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.OwnedGames
{
    public class OwnedGamesService : IOwnedGamesService
    {
        private readonly IOwnedGamesRepository _ownedGamesRepository;
        private readonly IVideogameRepository _videogameRepository;
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IGameTransactionHistoryRepository _gameTransactionHistoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public OwnedGamesService(IOwnedGamesRepository ownedGamesRepository,
            IVideogameRepository videogameRepository,
            ITransactionsRepository transactionsRepository,
            IGameTransactionHistoryRepository gameTransactionHistoryRepository,
            IUnitOfWork unitOfWork)
        {
            _ownedGamesRepository = ownedGamesRepository;
            _videogameRepository = videogameRepository;
            _unitOfWork = unitOfWork;
            _transactionsRepository = transactionsRepository;
            _gameTransactionHistoryRepository = gameTransactionHistoryRepository;
        }

        public async Task<bool> AdminAddGameForUser(int userId, int gameId)
        {
            var exists = await _videogameRepository.CheckIfAnyByConditionAsync(x => x.Id == gameId);
            if (!exists)
            {
                throw new CustomException("game with this id does not exist", 404);
            }
            var checkIfOwned = await _ownedGamesRepository.FindByConditionAsync(x => x.VideogameId == gameId && x.UserId == userId);
            if (checkIfOwned is not null)
            {
                throw new CustomException("user already owns this game", 400);
            }
            var ownedGame = new OwnedGamesEntity
            {
                VideogameId=gameId,
                UserId=userId,
                DateCreated=DateTime.Now
            };
            await _ownedGamesRepository.CreateAsync(ownedGame);
            var transaction = new TransactionsEntity
            {
                transactionType=TransactionType.GamePurchase,
                TransactionDescription=$"admin added game for user",
                UserId = userId,
                TransactionAmount = 0,
                DateCreated = DateTime.Now
            };
            await _transactionsRepository.CreateAsync(transaction);
            await _unitOfWork.CompleteAsync();
            var newGameTransaction = new GameTransactionHistoryEntity
            {
                transactionId = transaction.Id,
                VideogameId = gameId,
                DateCreated = DateTime.Now,
            };
            await _gameTransactionHistoryRepository.CreateAsync(newGameTransaction);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> CheckIfOwnsGame(int userId, int gameId)
        {
            return await _ownedGamesRepository.CheckIfAnyByConditionAsync(x => x.UserId == userId && x.VideogameId == gameId);
        }

        public async Task<PageReturnDto<GameNamesDto>> GetUserOwnedGames(QueryParams model, int userId)
        {
            return await _ownedGamesRepository.GetOwnedGames(model, userId);
        }

    }
}
