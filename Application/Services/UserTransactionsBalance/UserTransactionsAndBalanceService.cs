using Application.Exceptions;
using Infrastructure.Entities.OwnedGames;
using Infrastructure.Entities.Transactions;
using Infrastructure.Entities.Transactions.Dtos;
using Infrastructure.Entities.UserBalance.Dtos;
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

namespace Application.Services.UserTransactionsBalance
{
    public class UserTransactionsAndBalanceService : IUserTransactionsAndBalanceService
    {

        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IVideogameRepository _videogameRepository;
        private readonly IUserBalanceRepository _userBalanceRepository;
        private readonly IPaymentCredentialRepository _paymentCredentialRepository;
        private readonly IOwnedGamesRepository _ownedGamesRepository;
        private readonly IGameTransactionHistoryRepository  _gameTransactionHistoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserTransactionsAndBalanceService(ITransactionsRepository transactionsRepository, 
            IVideogameRepository videogameRepository, 
            IUserBalanceRepository userBalanceRepository, 
            IPaymentCredentialRepository paymentCredentialRepository,
            IOwnedGamesRepository ownedGamesRepository,
            IGameTransactionHistoryRepository gameTransactionHistoryRepository,
            IUnitOfWork unitOfWork)
        {
            _transactionsRepository = transactionsRepository;
            _videogameRepository = videogameRepository;
            _userBalanceRepository = userBalanceRepository;
            _paymentCredentialRepository = paymentCredentialRepository;
            _unitOfWork = unitOfWork;
            _ownedGamesRepository = ownedGamesRepository;
            _gameTransactionHistoryRepository = gameTransactionHistoryRepository;
        }

        public async Task<bool> AddMoneyOnBalance(int userId,AddMoneyTransactionDto model)
        {

            //aq rame procesingi da baratis validurobis shemocmeba iqneboda albat
            var NewTransaction = new TransactionsEntity
            {
                            UserId=userId,
                            transactionType= TransactionType.AddingMoney,
                            TransactionDescription=$"user added {model.TransactionAmount} $ amount on account",
                            TransactionAmount =model.TransactionAmount,
                            paymentType =model.PaymentType,
                            CardNumber =model.CardNumber,
                            DateCreated=DateTime.Now,
            };
            await _transactionsRepository.CreateAsync(NewTransaction);
            var UserBalance = await _userBalanceRepository.FindByConditionAsync(x => x.UserId == userId);
            UserBalance.balance += model.TransactionAmount;
            UserBalance.DateUpdated=DateTime.Now;
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> BuyGame(int gameId, int userId)
        {
            var game = await _videogameRepository.FindByConditionAsync(x => x.Id == gameId);
            if (game == null)
            {
                throw new CustomException("game with this id does not exist", 404);
            }
            var userBalance = await _userBalanceRepository.FindByConditionAsync(x => x.UserId == userId);
            if (userBalance.balance<game.Price)
            {
                throw new CustomException("user does not have enough funds", 400);
            }
            var creditentials = await _paymentCredentialRepository.FindByConditionAsync(x => x.UserId == userId);
            var UserBalance = await _userBalanceRepository.FindByConditionAsync(x => x.UserId == userId);
            var newTransaction = new TransactionsEntity
            {
                UserId = userId,
                transactionType = TransactionType.AddingMoney,
                TransactionDescription = $"user bought {game.VideogameName} for  {game.Price} $ ",
                TransactionAmount = -1*(game.Price),
                DateCreated = DateTime.Now,
            };
            var ownedGameWithPayment = new OwnedGamesEntity
            {
                UserId = userId,
                VideogameId = gameId,
                DateCreated = DateTime.Now,
            };
            UserBalance.balance -= game.Price;
            await _transactionsRepository.CreateAsync(newTransaction);
            await _ownedGamesRepository.CreateAsync(ownedGameWithPayment);
            await _unitOfWork.CompleteAsync();
            var newGameTransaction =new GameTransactionHistoryEntity
             {
                transactionId=newTransaction.Id,
                VideogameId=gameId,
                DateCreated=DateTime.Now,
            };
            await _gameTransactionHistoryRepository.CreateAsync(newGameTransaction);
            await _unitOfWork.CompleteAsync();
            return true;

        }

        public async Task<GetUserBalanceDto> GetUserBalance(int userId)
        {
            var userBalance = await _userBalanceRepository.FindByConditionAsync(x => x.UserId == userId);
            return new GetUserBalanceDto { Balance=userBalance.balance};
        }

        public async Task<PageReturnDto<UserTransactionsInfoDto>> GetUserTransactionsInfo(QueryParams model,int userId)
        {
            return  await _transactionsRepository.GetUserTransactions(model,userId); 
        }
    }
}
