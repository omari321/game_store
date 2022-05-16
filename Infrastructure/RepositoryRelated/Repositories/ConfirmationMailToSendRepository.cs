using Infrastructure.Entities;
using Infrastructure.Entities.ConfirmationMailToSend;
using Infrastructure.Repositories;
using Infrastructure.RepositoryRelated.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.Repositories
{
    public class ConfirmationMailToSendRepository : RepositoryBase<ConfirmationMailToSendEntity>, IConfirmationMailToSendRepository
    {
        public ConfirmationMailToSendRepository(EntityDbContext entityDbContext) : base(entityDbContext)
        {
        }
    }
}
