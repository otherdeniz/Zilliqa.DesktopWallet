using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Org.BouncyCastle.Crypto.EC;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC.Multiplier;
using Org.BouncyCastle.Security;
using Zilliqa.DesktopWallet.ApiClient.Crypto;
using ECPoint = Org.BouncyCastle.Math.EC.ECPoint;

namespace Zilliqa.DesktopWallet.ApiClient.Utils
{
    public class CryptoUtil
    {
        

        #region Keystore utils
        /**
         * The parameters of the secp256k1 curve that Bitcoin uses.
         */
        
        private static KeyStore keystore = new KeyStore();
        private static string pattern = "^(0x)?[0-9a-f]";


        public static string GeneratePrivateKey()
        {
            ECKeyPair keys = Schnorr.GenerateKeyPair();
            return keys.PrivateKey.ToString(8);
        }

        public static string GetAddressFromPrivateKey(string privateKey)
        {
            string publicKey = GetPublicKeyFromPrivateKey(privateKey, true);
            return GetAddressFromPublicKey(publicKey);
        }

        public static bool IsBytestring(string address)
        {
            var match = Regex.Match(address, pattern);
            
            return match.Success;
        }

        /**
         * @param privateKey hex string without 0x
         * @return
         */
        public static string GetPublicKeyFromPrivateKey(string privateKey, bool compressed)
        {
            BigInteger bigInteger = new BigInteger(privateKey, 16);
            ECPoint point = GetPublicPointFromPrivate(bigInteger);
            return ByteUtil.ByteArrayToHexString(point.GetEncoded(compressed));
        }

        public static string GetAddressFromPublicKey(string publicKey)
        {
            SHA256 s = new SHA256Managed();
            byte[] address = s.ComputeHash(ByteUtil.HexStringToByteArray(publicKey));
            return ByteUtil.ByteArrayToHexString(address).Substring(24);
        }

        public static byte[] GenerateRandomBytes(int size)
        {
            byte[] bytes = new byte[size];
            new SecureRandom().NextBytes(bytes);
            return bytes;
        }

        private static ECPoint GetPublicPointFromPrivate(BigInteger privateKeyPoint)
        {
            var CURVE_PARAMS = CustomNamedCurves.GetByName("secp256k1");
            var CURVE = new ECDomainParameters(CURVE_PARAMS.Curve, CURVE_PARAMS.G, CURVE_PARAMS.N, CURVE_PARAMS.H);
            if (privateKeyPoint.BitLength > CURVE.N.BitLength)
            {
                privateKeyPoint = privateKeyPoint.Mod(CURVE.N);
            }
            return new FixedPointCombMultiplier().Multiply(CURVE.G, privateKeyPoint);
        }

        public static string DecryptPrivateKey(string keyStoreJson, string passphrase)
        {
            return keystore.DecryptPrivateKey(keyStoreJson, passphrase);
        }

        public static string EncryptPrivateKey(string privateKey, string passphrase, KDFType type)
        {
            return keystore.EncryptPrivateKey(privateKey, passphrase, type);
        }
        
        #endregion
    }
}
