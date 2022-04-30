using Infrastructure.Entities.User;
using Infrastructure.RepositoryRelated.IRepositories;
using Infrastructure.UnitOfWorkRepo;
using Microsoft.Extensions.Options;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Mail
{
    public class MailService : IMailService
    {
        private MailSettings _mailSettings { get; set; }
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public MailService(IOptions<MailSettings> appSettings,
            IUserRepository userRepository,
             IUnitOfWork unitOfWork)
        {
            _mailSettings = appSettings.Value;
            _userRepository=userRepository;
            _unitOfWork=unitOfWork;
        }
        public async Task SendMailConfirmationCodes()
        {
           var people=await _userRepository.GetMailsForConfirmationAsync();
           
            if (people.Any())
            {
                people.ForEach(async x =>
                {
                    string subject = $"veryfying your email address";
                    //archans magram lurjad entity aris gamoyenebuli 
                    string message = $"hello {x.FirstName} please click <a href=\"http://localhost:5208/api/Authenticate/verify-email/{x.VerificationToken}\">Visit W3Schools.com!</a> ";

                    try
                    {
                        await SendAsync(x.Email, subject, message);
                        x.VerificationToken = null;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                });
            }
            _unitOfWork.CompleteSync();
            return;
        }

        public Task<bool> SendNewPassword(UserEntity entity)
        {
            string subject = $"new password which you can use to reset";
            //archans magram lurjad entity aris gamoyenebuli 
            string message = $"hello {entity.FirstName}  , your new password is : {entity.Password}";
            SendAsync(entity.Email, subject, message);
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
                Body = body
            })
            {
                 smtp.Send(message);
            }
        }
    }
}
