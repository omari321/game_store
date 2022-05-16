using Infrastructure.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.ConfirmationMailToSend
{
    public class ConfirmationMailToSendEntity:BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public string Email { get; set; }
    }
}
