using Application.Exceptions;
using Infrastructure.Entities.Enums;
using Infrastructure.Entities.PaymentCreditentials;
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


        //gayavi
        public async Task<PaymentCredentialsInfoDto> AddPaymentCreditentials(int userId, AddPaymentDto model)
        {
            var cardInfo = new PaymentCredentialsInfoDto
                        {
                            OwnerName = model.OwnerName,
                            PaymentTypes = model.PaymentType,
                            CardNumber = model.CardNumber,
                            ExpireDate = model.ExpireDate,
                        };
            var paymentEntity = new PaymentCredentialsEntity
            {
                 OwnerName = model.OwnerName,
                 CardNumber = model.CardNumber,
                 UserId=userId,
                 CSV = model.CSV,
                 PaymentTypeId = model.PaymentType,
                 ExpireDate = model.ExpireDate,
                 DateCreated = DateTime.Now
            };
            var condition = await _paymentCreditentialsRepository.CheckIfAnyByConditionAsync(x => x.UserId == userId && x.CardNumber == model.CardNumber);
            if(condition)
            {
                return cardInfo;
            }
            await _paymentCreditentialsRepository.CreateAsync(paymentEntity);
            await _unitOfWork.CompleteAsync();
            return cardInfo;
        }

        public async Task<IEnumerable<PaymentCredentialsInfoDto>> GetUserPaymentCreditentials(int userId)
        {
            var Creditentials= await _paymentCreditentialsRepository.GetUserPaymentCreditentials(userId);
            return Creditentials.Select(x =>
            {
            return new PaymentCredentialsInfoDto
            {
                OwnerName = x.OwnerName,
                PaymentTypes =x.PaymentTypeId,
                CardNumber = x.CardNumber,
                ExpireDate = x.ExpireDate,
            };
            });
        }
    }
}
