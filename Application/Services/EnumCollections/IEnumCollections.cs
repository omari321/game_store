using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EnumCollections
{
    public interface IEnumCollections
    {
        Dictionary<int, string> GetPaymentTypes();
        Dictionary<int, string> GetRoles();

    }
}
