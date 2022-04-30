using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audiance { get; set; }
        public string Key { get; set; }
        public int RefreshTokenTTL { get; set; }
    }
}
