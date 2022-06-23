using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Common.Infrastructure
{
    public class PasswordEncryptor
    {
        private static byte[] computedHash;

        public static string Encrypt(string password)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                byte[] passwordSalt = hmac.Key;
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
            return Convert.ToHexString(computedHash);
        }
    }
}
