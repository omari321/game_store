using Application.Services.Mail;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundProcesses.SendMail
{
    public class MailVerifyProcessor : IMailVerifyProcessor, IDisposable

    {
        public readonly ILogger<MailVerifyProcessor> _logger;
        public readonly IServiceProvider ServiceProvider;
        public MailVerifyProcessor(
            ILogger<MailVerifyProcessor> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            ServiceProvider = serviceProvider;
        }

        public async Task SendMail(CancellationToken cancellationToken)
        {
            //while (!cancellationToken.IsCancellationRequested)
            //{
                _logger.LogInformation("send mails");
                using var scope = ServiceProvider.CreateScope();
                var mailService = scope.ServiceProvider.GetService<IMailService>();
                await mailService.SendMailConfirmationCodes();
                await Task.Delay(1000 * 15);
            //}
        }
        public void Dispose()
        {
            
        }

    }
}
