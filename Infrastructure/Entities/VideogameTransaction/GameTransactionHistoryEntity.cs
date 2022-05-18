using Infrastructure.Entities.Transactions;
using Infrastructure.Entities.Videogame;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameTransaction
{
    [Table("GameTransactionHistory", Schema = "dbo")]
    public class GameTransactionHistoryEntity:BaseEntity
    {
        public int Id { get; set; }
        public int transactionId { get; set; }
        public TransactionsEntity transaction { get; set; }
        public int VideogameId { get; set; }
        public VideogameEntity videogame { get; set; }
    }
}
