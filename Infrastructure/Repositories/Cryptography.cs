using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class Cryptography : ICryptography
    {
        public Task<string> EncryptPassword(string plainText)
        {
            var key = SHA1.Create().ComputeHash(Encoding.ASCII.GetBytes(plainText));

            return Task.FromResult(Encoding.Default.GetString(key));
        }
    }
}
