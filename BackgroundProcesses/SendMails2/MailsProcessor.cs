using Application.Services.Mail;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundProcesses.SendMails2
{
    public class MailsProcessor : IProcessor
    {
        public readonly IServiceProvider ServiceProvider;
        public MailsProcessor(
            IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
        public MailsProcessor()
        {

        }
        public TimeSpan Delay { get; } = TimeSpan.FromMinutes(1);

        public async Task Process(CancellationToken cancellationToken)
        {
            using var scope = ServiceProvider.CreateScope();

            var mailService = scope.ServiceProvider.GetService<IMailService>();
            await mailService.SendMailConfirmationCodes();
            Console.WriteLine("i was here");
            return;
        }
    }
}
