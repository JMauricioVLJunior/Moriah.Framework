using System.Security.Cryptography;
using System.Text;

namespace Moriah.Framework.Common
{
    public static class Security
    {
        private static MD5 md5 = MD5.Create();

        public static string Encripity(string input)
        {
            // Calcular o Hash
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // Converter byte array para string hexadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }


    }
}
