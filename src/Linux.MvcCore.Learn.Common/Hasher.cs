using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MvcCore.Learn.Common
{
    public class Hasher
    {
        public static string GetMd5Hash(string input)
        {
            if (input == null)
                input = string.Empty;
            byte[] data = Encoding.UTF8.GetBytes(input.Trim().ToLowerInvariant());
            using (var md5 = MD5.Create())
            {
                data = md5.ComputeHash(data);
            }

            var ret = new StringBuilder();
            foreach (byte b in data)
            {
                ret.Append(b.ToString("x2").ToLowerInvariant());
            }
            return ret.ToString();
        }
    }
}
