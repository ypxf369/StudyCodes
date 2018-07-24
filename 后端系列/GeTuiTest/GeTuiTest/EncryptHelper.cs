using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GeTuiTest
{
    public class EncryptHelper
    {
        public static string Sha256(string str)
        {
            using (var sha256 = SHA256.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(str);
                var hashBytes = sha256.ComputeHash(inputBytes);
                var sb = new StringBuilder();
                foreach (var hashByte in hashBytes)
                {
                    sb.Append(hashByte.ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}
