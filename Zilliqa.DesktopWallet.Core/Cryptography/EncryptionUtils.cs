using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Zilliqa.DesktopWallet.Core.Cryptography
{
    public static class EncryptionUtils
    {
        //DECLARATIONS
        private static readonly byte[] Salt = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x2a, 0x4d, 0x66, 0x64, 0x44, 0x65, 0x44, 0x65, 0x65 };
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        // The following constants may be changed without breaking existing hashes.
        private static readonly int SALT_BYTE_SIZE = 24;
        private static readonly int HASH_BYTE_SIZE = 24;
        private static readonly int PBKDF2_ITERATIONS = 1000;
        private static readonly int ITERATION_INDEX = 0;
        private static readonly int SALT_INDEX = 1;
        private static readonly int PBKDF2_INDEX = 2;

        //PUBLIC
        public static string EncryptString(string clearText, string password)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            var pdb = new Rfc2898DeriveBytes(password, Salt);
            byte[] encryptedData = EncryptString(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return Convert.ToBase64String(encryptedData);
        }

        public static string EncryptString(string clearText, X509Certificate2 cert)
        {
            byte[] clearBuf = Encoding.Unicode.GetBytes(clearText);
            var rsa = (RSACryptoServiceProvider)cert.PublicKey.Key;
            byte[] cipher = rsa.Encrypt(clearBuf, false);
            return Convert.ToBase64String(cipher, Base64FormattingOptions.None);
        }

        public static string EncryptStringForJava(string clearText, string password)
        {
            byte[] clearBytes = Encoding.UTF8.GetBytes(clearText);
            var pdb = new Rfc2898DeriveBytes(password, Salt);
            byte[] encryptedData = EncryptStringForJava(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return Convert.ToBase64String(encryptedData);
        }

        public static string DecryptString(string cipherText, string password)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            var pdb = new Rfc2898DeriveBytes(password, Salt);
            byte[] decryptedData = DecryptString(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            var i = decryptedData.Length - 2;
            while (i >= 1 && decryptedData[i] == 0)
            {
                i -= 2;
            }
            var decryptedDataUntrailed = new byte[i + 2];
            Array.Copy(decryptedData, decryptedDataUntrailed, i + 2);
            return Encoding.Unicode.GetString(decryptedDataUntrailed);
        }

        public static string DecryptString(string cipherText, X509Certificate2 cert)
        {
            if (!cert.HasPrivateKey)
            {
                throw new ApplicationException("Certificate has no private key, this cert cannot be used do decrypt data!");
            }
            byte[] cipher = Convert.FromBase64String(cipherText);
            var rsa = (RSACryptoServiceProvider)cert.PrivateKey;
            byte[] plainbytes = rsa.Decrypt(cipher, false);
            return Encoding.Unicode.GetString(plainbytes);
        }

        public static void EncryptStream(Stream source, Stream target, string password)
        {
            if (!source.CanRead) throw new ApplicationException("Source Stream is not readable");
            if (!target.CanWrite) throw new ApplicationException("Target stream is not writable");
            var pdb = new Rfc2898DeriveBytes(password, Salt);
            Aes alg = Aes.Create();
            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);
            alg.Padding = PaddingMode.PKCS7;
            using (var cryptoMemory = new MemoryStream())
            using (var cs = new CryptoStream(cryptoMemory, alg.CreateEncryptor(), CryptoStreamMode.Write))
            {
                source.CopyTo(cs, 2048);
                cs.FlushFinalBlock();
                cryptoMemory.Position = 0;
                cryptoMemory.CopyTo(target, 2048);
            }
        }

        public static void DecryptStream(Stream source, Stream target, string password)
        {
            if (!source.CanRead) throw new ApplicationException("Source Stream is not readable");
            if (!target.CanWrite) throw new ApplicationException("Target stream is not writable");
            var pdb = new Rfc2898DeriveBytes(password, Salt);
            Aes alg = Aes.Create();
            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);
            alg.Padding = PaddingMode.PKCS7;
            using (var cryptoMemory = new MemoryStream())
            using (var cs = new CryptoStream(cryptoMemory, alg.CreateDecryptor(), CryptoStreamMode.Write))
            {
                source.CopyTo(cs, 2048);
                cs.FlushFinalBlock();
                cryptoMemory.Position = 0;
                cryptoMemory.CopyTo(target, 2048);
                //while (target.Seek(target.Length - 1, SeekOrigin.Begin) > -1 && target.ReadByte() == 0)
                //{
                //    target.SetLength(target.Length - 1);
                //}
            }
        }

        public static string GetRandomNumbers(int length)
        {
            const string possible = "123456789";
            return GetRandomString(possible, length);
        }


        public static string GenerateRandomPassword(int length, bool includeSpecialChars = false)
        {
            var possible = "abcdefghjklmnpqrstuvwyzABCDEFGHJKMNOPQRSTUVWYZ123456789";
            if (includeSpecialChars)
            {
                possible += "@-.'$!?";
            }
            return GetRandomString(possible, length);
        }

        public static string GetMD5(this string textToHash)
        {
            // Use input string to calculate MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(textToHash);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes); // .NET 5 +

                // Convert the byte array to hexadecimal string prior to .NET 5
                // StringBuilder sb = new System.Text.StringBuilder();
                // for (int i = 0; i < hashBytes.Length; i++)
                // {
                //     sb.Append(hashBytes[i].ToString("X2"));
                // }
                // return sb.ToString();
            }
        }

        /// <summary>
        /// Creates a salted PBKDF2 hash of the password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>The hash of the password.</returns>
        public static string CreatePasswordHash(string password)
        {
            // Generate a random salt
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTE_SIZE];
            csprng.GetBytes(salt);

            // Hash the password and encode the parameters
            byte[] hash = GetPBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            return PBKDF2_ITERATIONS + ":" +
                Convert.ToBase64String(salt) + ":" +
                Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Validates a password given a hash of the correct one.
        /// </summary>
        /// <param name="password">The password to check.</param>
        /// <param name="correctHash">A hash of the correct password.</param>
        /// <returns>True if the password is correct. False otherwise.</returns>
        public static bool ValidatePasswordHash(string password, string correctHash)
        {
            // Extract the parameters from the hash
            char[] delimiter = { ':' };
            string[] split = correctHash.Split(delimiter);
            int iterations = int.Parse(split[ITERATION_INDEX]);
            byte[] salt = Convert.FromBase64String(split[SALT_INDEX]);
            byte[] hash = Convert.FromBase64String(split[PBKDF2_INDEX]);
            byte[] testHash = GetPBKDF2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        /// <summary>
        /// Validates a password given a hash of the correct one. The algorithm is Salted SHA-1 (as used in LDAP)
        /// </summary>
        /// <param name="password">The password to check.</param>
        /// <param name="correctHash">A hash of the correct password in Base64.</param>
        /// <returns>True if the password is correct. False otherwise.</returns>
        public static bool ValidateSshaPasswordHash(string password, string correctHash)
        {
            // Extract the parameters from the hash
            var sshaBytes = Convert.FromBase64String(correctHash);
            if (sshaBytes.Length != 25) return false;
            using (var alg = SHA1.Create())
            {
                byte[] saltBytes = new byte[5];
                Buffer.BlockCopy(sshaBytes, 20, saltBytes, 0, 5);
                var sourceBytes = Encoding.UTF8.GetBytes(password + Encoding.UTF8.GetString(saltBytes));
                var hashedBytes = alg.ComputeHash(sourceBytes);
                var combinedBytes = new byte[25];
                Buffer.BlockCopy(hashedBytes, 0, combinedBytes, 0, 20);
                Buffer.BlockCopy(saltBytes, 0, combinedBytes, 20, 5);
                var base64Hash = Convert.ToBase64String(combinedBytes, Base64FormattingOptions.None);
                return base64Hash == correctHash;
            }
        }

        /// <summary>
        /// This method simulates a roll of the dice. The input parameter is the number of sides of the dice.
        /// </summary>
        public static byte RollDice(byte numberSides, bool zeroBased = true)
        {
            if (numberSides <= 0)
                throw new ArgumentOutOfRangeException("numberSides");
            // Create a byte array to hold the random value. 
            var randomNumber = new byte[1];
            do
            {
                // Fill the array with a random value.
                rngCsp.GetBytes(randomNumber);
            }
            while (!IsFairRoll(randomNumber[0], numberSides));
            // Return the random number mod the number 
            // of sides.  The possible values are zero- 
            // based 
            return (byte)(randomNumber[0] % numberSides + (zeroBased ? 0 : 1));
        }

        //PRIVATE
        private static bool IsFairRoll(byte roll, byte numSides)
        {
            // There are MaxValue / numSides full sets of numbers that can come up 
            // in a single byte.  For instance, if we have a 6 sided die, there are 
            // 42 full sets of 1-6 that come up.  The 43rd set is incomplete. 
            int fullSetsOfValues = byte.MaxValue / numSides;

            // If the roll is within this range of fair values, then we let it continue. 
            // In the 6 sided die case, a roll between 0 and 251 is allowed.  (We use 
            // < rather than <= since the = portion allows through an extra 0 value). 
            // 252 through 255 would provide an extra 0, 1, 2, 3 so they are not fair 
            // to use. 
            return roll < numSides * fullSetsOfValues;
        }

        private static string GetRandomString(string possible, int length)
        {
            char[] possibleChars = possible.ToCharArray();
            var result = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                result.Append(possibleChars[RollDice((byte)possibleChars.Length)]);

            }
            return result.ToString();
        }

        private static byte[] EncryptString(byte[] clearText, byte[] Key, byte[] IV)
        {
            var ms = new MemoryStream();
            Aes alg = Aes.Create();
            alg.Key = Key;
            alg.IV = IV;
            alg.Padding = PaddingMode.Zeros;
            using (var cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(clearText, 0, clearText.Length);
                cs.Close();
                byte[] encryptedData = ms.ToArray();
                return encryptedData;
            }
        }

        private static byte[] EncryptStringForJava(byte[] clearText, byte[] key, byte[] iv)
        {
            var ms = new MemoryStream();
            Aes alg = Aes.Create();
            alg.Key = key;
            alg.IV = iv;
            alg.Padding = PaddingMode.PKCS7;
            using (var cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(clearText, 0, clearText.Length);
                cs.Close();
                byte[] encryptedData = ms.ToArray();
                return encryptedData;
            }
        }

        private static byte[] DecryptString(byte[] cipherData, byte[] Key, byte[] IV)
        {
            var ms = new MemoryStream();
            Aes alg = Aes.Create();
            alg.Key = Key;
            alg.IV = IV;
            alg.Padding = PaddingMode.Zeros;
            using (var cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(cipherData, 0, cipherData.Length);
                cs.Close();
                byte[] decryptedData = ms.ToArray();
                return decryptedData;
            }
        }

        /// <summary>
        /// Computes the PBKDF2-SHA1 hash of a password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="iterations">The PBKDF2 iteration count.</param>
        /// <param name="outputBytes">The length of the hash to generate, in bytes.</param>
        /// <returns>A hash of the password.</returns>
        private static byte[] GetPBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }

        /// <summary>
        /// Compares two byte arrays in length-constant time. This comparison
        /// method is used so that password hashes cannot be extracted from
        /// on-line systems using a timing attack and then attacked off-line.
        /// </summary>
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }
    }
}
