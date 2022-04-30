using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWorkRepo
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
        void CompleteSync();
    }
}
