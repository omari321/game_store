using Infrastructure.Entities.User;
using Infrastructure.Entities.User.Dto;
using Infrastructure.RepositoryRelated.IRepositories;
using Infrastructure.UnitOfWorkRepo;
using Microsoft.Extensions.Options;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Mail
{
    public class MailService : IMailService
    {
        private MailSettings _mailSettings { get; set; }
        private readonly IUserRepository _userRepository;
        private readonly IConfirmationMailToSendRepository _confirmationMailToSendRepository;
        private readonly IUnitOfWork _unitOfWork;
        public MailService(IOptions<MailSettings> appSettings,
            IUserRepository userRepository,
            IConfirmationMailToSendRepository confirmationMailToSendRepository,
             IUnitOfWork unitOfWork)
        {
            _mailSettings = appSettings.Value;
            _userRepository=userRepository;
            _confirmationMailToSendRepository = confirmationMailToSendRepository;
            _unitOfWork =unitOfWork;
        }
        public async Task SendMailConfirmationCodes()
        {
           var people=await _confirmationMailToSendRepository.GetAllAsync();

            if (people.Any())
            {

                foreach (var x in people.ToList())
                {
                    string subject = $"veryfying your email address";
                    string message = $"hello {x.UserName} please click <a href={x.ConfirmationLink}>Here</a> to verify your mail ";

                    try
                    {
                        await SendAsync(x.Email, subject, message);
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        _confirmationMailToSendRepository.Delete(x);
                    }
                }
            }
            await _unitOfWork.CompleteAsync();
            return;
        }

        public Task<bool> SendNewPassword(UserSendNewPasswordDto model)
        {
            string subject = $"new password which you can use to reset";
            string message = $"hello {model.UserName}  , your new password is : {model.Password}";
            SendAsync(model.Email, subject, message);
            return Task.FromResult(true);
        }
        private async Task SendAsync(string mail, string subject, string body)
        {
            var fromAddress = new MailAddress(_mailSettings.From, "GameStore");
            var toAddress = new MailAddress(mail, "customer");
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(_mailSettings.From, _mailSettings.Password),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                 await smtp.SendMailAsync(message);
            }
        }
    }
}
