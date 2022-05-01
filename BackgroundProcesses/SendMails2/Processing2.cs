using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundProcesses.SendMails2
{
    public class Processing2 : IHostedService
    {
        private Timer _timer;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(Process, null, 0, 60000);

            States.Add(typeof(MailsProcessor), DateTimeOffset.UtcNow);
            
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            if (_timer != null)
                _timer.Dispose();

            return Task.CompletedTask;
        }
        public Dictionary<Type, DateTimeOffset> States { get; set; } = new Dictionary<Type, DateTimeOffset>();
        private void Process(object? state)
        {
            var type = typeof(IProcessor);
            var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(p => type.IsAssignableFrom(p));

            foreach (var item in types)
            {
                if (item.IsInterface)
                {
                    continue;
                }
                var p = (Activator.CreateInstance(item) as IProcessor);

                if (States[item].Add(p.Delay) >= DateTimeOffset.UtcNow)
                {
                    using var cts = new CancellationTokenSource();

                    var task = (Activator.CreateInstance(item) as IProcessor).Process(cts.Token);

                    States[item] = States[item].Add(p.Delay);
                }
            }
        }
    }
}
