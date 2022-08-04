using System.Security.Cryptography;
using System.Text;

namespace Zillifriends.Shared.Common
{
    public static class HashUtils
    {
        public static byte[] GetMd5(this string textToHash)
        {
            // Use input string to calculate MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(textToHash);
                return md5.ComputeHash(inputBytes);
            }
        }

        public static string GetMd5Hex(this string textToHash)
        {
            return Convert.ToHexString(GetMd5(textToHash)); // .NET 5 +
        }

    }
}
