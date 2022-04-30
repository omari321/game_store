using BackgroundProcesses.SendMail;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundProcesses
{
    public class Processing : BackgroundService
    {
        private readonly IMailVerifyProcessor _mailVerifyProcessor;

        public Processing(IMailVerifyProcessor mailVerifyProcessor)
        {
            _mailVerifyProcessor = mailVerifyProcessor;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _mailVerifyProcessor.SendMail(stoppingToken);
        }
    }

}
