using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWorkRepo
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly EntityDbContext _entityDbContext;
        public UnitOfWork(EntityDbContext entityDbContext)
        {
            _entityDbContext = entityDbContext;
        }
        public async Task CompleteAsync()
        {
            await _entityDbContext.SaveChangesAsync();
        }
        public  void CompleteSync()
        {
            _entityDbContext.SaveChanges();
        }
    }
}
