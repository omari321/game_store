using Infrastructure.Entities.User;
using Infrastructure.Entities.User.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Mail
{
    public interface IMailService
    {
        Task SendMailConfirmationCodes();
        Task<bool> SendNewPassword(UserSendNewPasswordDto model);
    }
}
