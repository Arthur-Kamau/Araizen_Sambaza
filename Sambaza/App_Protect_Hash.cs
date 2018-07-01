using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sambaza
{
    class App_Protect_Hash
    {
        public string Md5hash(string pass)
        {
            var buffer = Encoding.UTF8.GetBytes(pass);
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(buffer);
            var hashedPassword = Encoding.UTF8.GetString(md5data, 0, buffer.Length);
            return hashedPassword;
        }
        public string Sha1Hash(string pass)
        {
            var buffer = Encoding.UTF8.GetBytes(pass);
            var sha1 = new SHA1CryptoServiceProvider();
            var sha1data = sha1.ComputeHash(buffer);
            var hashedPassword = Encoding.UTF8.GetString(sha1data, 0, buffer.Length);
            return hashedPassword;
        }
    }
}
