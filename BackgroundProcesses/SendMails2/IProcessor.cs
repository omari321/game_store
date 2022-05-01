using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundProcesses.SendMails2
{
    public interface IProcessor
    {
        TimeSpan Delay { get; }
        Task Process(CancellationToken cancellationToken);
    }
}
