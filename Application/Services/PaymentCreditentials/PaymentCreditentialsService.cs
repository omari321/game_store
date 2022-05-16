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

        public async Task<bool> CheckIfUserHasPaymentCreditentials(int userId)
        {
            return await _paymentCreditentialsRepository.CheckIfAnyByConditionAsync(x => x.UserId == userId);
        }
        //gayavi
        public async Task<PaymentCredentialsInfoDto> UpdateAddPayment(int userId, UpdateAddPaymentDto model)
        {
            var cardInfo = new PaymentCredentialsInfoDto
                        {
                            OwnerName = model.OwnerName,
                            PaymentTypes = model.PaymentType,
                            CardNumber = model.CardNumber,
                            ExpireDate = model.ExpireDate,
                        };
            var item = await _paymentCreditentialsRepository.FindByConditionAsync(x=>x.UserId==userId);

            if (item!=null)
            {
                item.OwnerName = model.OwnerName;
                item.CardNumber = model.CardNumber;
                item.CSV = model.CSV;
                item.PaymentTypeId = model.PaymentType;
                item.ExpireDate = model.ExpireDate;
                item.DateUpdated = DateTime.Now;
                await _unitOfWork.CompleteAsync();
                return cardInfo;
            }
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
            await _paymentCreditentialsRepository.CreateAsync(paymentEntity);
            await _unitOfWork.CompleteAsync();
            return cardInfo;
        }

        public async Task<PaymentCredentialsInfoDto> GetUserPaymentCreditentials(int userId)
        {
            var info= await _paymentCreditentialsRepository.FindByConditionAsync(x => x.UserId == userId);
            if (info==null)
            {
                throw new CustomException("User does not have payment creditentials filled in ", 404);
            }
            return new PaymentCredentialsInfoDto
            {
                OwnerName = info.OwnerName,
                PaymentTypes =info.PaymentTypeId,
                CardNumber = info.CardNumber,
                ExpireDate = info.ExpireDate,
            };
        }
    }
}
