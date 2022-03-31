using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class PasswordEncryptor
    {
        public static async Task<string> EncryptPassword(string password, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                                password: password,
                                                salt: salt,
                                                prf: KeyDerivationPrf.HMACSHA256,
                                                iterationCount: 100000,
                                                numBytesRequested: 256 / 8));
        }
    }
}
