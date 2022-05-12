using Infrastructure.Entities.PaymentCreditentials.Dtos;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.RepositoryRelated.IRepositories;
using Infrastructure.UnitOfWorkRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PaymentCreditentials
{
    public class PaymentCreditentialsService : IPaymentCreditentialsService
    {
        private readonly IPaymentCredentialRepository  _paymentCreditentialsRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PaymentCreditentialsService(IPaymentCredentialRepository  paymentCreditentialsRepository,IUnitOfWork unitOfWork)
        {
            _paymentCreditentialsRepository = paymentCreditentialsRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<ICollection<PagingGameDto>> GetBoughtGames(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PaymentCredentialsInfoDto> UpdateAddPayment(int userId, UpdateAddPaymentDto model)
        {
            var item = await _paymentCreditentialsRepository.FindByConditionAsync(x=>x.UserId==userId);
            item.OwnerName = model.OwnerName;
            item.CardNumber = model.CardNumber;
            item.CSV = model.CSV;
            item.PaymentTypeId = model.PaymentType;
            item.ExpireDate = model.ExpireDate;

            var cardInfo = new PaymentCredentialsInfoDto
            {
                OwnerName = model.OwnerName,
                PaymentTypes = model.PaymentType,
                CardNumber = model.CardNumber,
                ExpireDate = model.ExpireDate,
            };

            if (item != null)
            {
                item.DateUpdated = DateTime.Now;
                await _unitOfWork.CompleteAsync();
                return cardInfo;
            }
            item.DateCreated = DateTime.Now;
            await _unitOfWork.CompleteAsync();
            return cardInfo;
        }
    }
}
