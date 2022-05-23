using Infrastructure.Entities.Enums;
using Infrastructure.Entities.User;
using Infrastructure.Entities.VideogameTransaction;
using Infrastructure.EntityEnums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities.Transactions
{
    [Table("Transactions", Schema = "dbo")]
    public class TransactionsEntity:BaseEntity
    {
        public int Id { get; set; }
        public TransactionType transactionType { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public string TransactionDescription { get; set; }
        public double TransactionAmount { get; set; }
        public PaymentTypes paymentType { get; set; }
        public string? CardNumber { get; set; }
        public List<GameTransactionHistoryEntity> videogameTransactionEntity { get; set; }
    }
}
