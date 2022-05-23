using Infrastructure.Entities.Enums;
using Infrastructure.Entities.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EnumCollections
{
    public class EnumCollections : IEnumCollections
    {
        public Dictionary<int, string> GetPaymentTypes()
        {
            var enums = Enum.GetValues(typeof(PaymentTypes))
             .Cast<PaymentTypes>()
             .Select(v => v.ToString())
             .ToList();
            return enums.Select((item, index) => new { item = item, index = index })
                .ToDictionary(x => x.index + 1, x => x.item);
        }

        public Dictionary<int, string> GetRoles()
        {
            var enums = Enum.GetValues(typeof(Roles))
             .Cast<Roles>()
             .Select(v => v.ToString())
             .ToList();
            return enums.Select((item, index) => new { item = item, index = index })
                .ToDictionary(x => x.index + 1, x => x.item);
        }
    }
}
