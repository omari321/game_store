using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundProcesses.SendMail
{
    public interface IMailVerifyProcessor
    {
        Task SendMail(CancellationToken cancellationToken);
    }
}
