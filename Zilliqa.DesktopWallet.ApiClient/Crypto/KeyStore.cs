﻿using System;
using System.Text;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Zilliqa.DesktopWallet.ApiClient.Utils;

namespace Zilliqa.DesktopWallet.ApiClient.Crypto
{
    public class KeyStore
    {

        public string Address { get; set; }
        public MusCipher Crypto { get; set; }
        public string Id { get; set; }
        public int Version { get; set; }

        public KeyStore()
        {
            
        }

        

        public byte[] GenerateCipherKey(byte[] derivedKey)
        {
            var cypherKey = new byte[16];
            Array.Copy(derivedKey, cypherKey, 16);
            return cypherKey;
        }

        public byte[] GenerateDerivedScryptKey(string pwd)
        {
            //Using Scrypt.Net from nuget
            var encoder = new Scrypt.ScryptEncoder();
            //ScyptDec
            var key = encoder.Encode(pwd);

            return Encoding.UTF8.GetBytes(key);
        }

        public byte[] GeneratePbkdf2Sha256DerivedKey(string password, byte[] salt, int count, int dklen)
        {
            var pdb = new Pkcs5S2ParametersGenerator(new Sha256Digest());

            pdb.Init(PbeParametersGenerator.Pkcs5PasswordToUtf8Bytes(password.ToCharArray()), salt,
                count);
            var key = (KeyParameter)pdb.GenerateDerivedMacParameters(8 * dklen);
            return key.GetKey();
        }

        public byte[] GenerateAesCtrCipher(byte[] iv, byte[] encryptKey, byte[] input)
        {
            var key = ParameterUtilities.CreateKeyParameter("AES", encryptKey);

            var parametersWithIv = new ParametersWithIV(key, iv);

            var cipher = CipherUtilities.GetCipher("AES/CTR/NoPadding");
            cipher.Init(true, parametersWithIv);
            return cipher.DoFinal(input);
        }

        public byte[] GenerateAesCtrDeCipher(byte[] iv, byte[] encryptKey, byte[] input)
        {
            var key = ParameterUtilities.CreateKeyParameter("AES", encryptKey);
            var parametersWithIv = new ParametersWithIV(key, iv);

            var cipher = CipherUtilities.GetCipher("AES/CTR/NoPadding");

            cipher.Init(false, parametersWithIv);
            return cipher.DoFinal(input);
        }


        public byte[] DecryptScrypt(string password, byte[] mac, byte[] iv, byte[] cipherText, int n, int p, int r,
            byte[] salt, int dklen)
        {
            var derivedKey = GenerateDerivedScryptKey(password);
            return Decrypt(mac, iv, cipherText, derivedKey);
        }

        public byte[] DecryptPbkdf2Sha256(string password, byte[] mac, byte[] iv, byte[] cipherText, int c, byte[] salt,
            int dklen)
        {
            var derivedKey = GeneratePbkdf2Sha256DerivedKey(password, salt, c, dklen);
            return Decrypt(mac, iv, cipherText, derivedKey);
        }

        public byte[] Decrypt(byte[] mac, byte[] iv, byte[] cipherText, byte[] derivedKey)
        {
            ValidateMac(mac, cipherText, derivedKey);
            var encryptKey = new byte[16];
            Array.Copy(derivedKey, encryptKey, 16);
            var privateKey = GenerateAesCtrCipher(iv, encryptKey, cipherText);
            return privateKey;
        }

       
        
        public byte[] GetPasswordAsBytes(string password)
        {
            return Encoding.UTF8.GetBytes(password);
        }

        public byte[] GetDerivedKey(string password, KDFParams parameters)
        {
            if (parameters is PBKDF2Params pbkdf2Params)
            {
                return pbkdf2Params.GetDerivedKey(password);
            }
            //else if(parameters is KDFParams)
            //{
                
            //    return GenerateDerivedScryptKey(password);
            //}
            else
            {
                throw new Exception("unsupport kdf params");
            }
        }

        public string EncryptPrivateKey(string privateKey, string passphrase, KDFType type)
        {
            string address = CryptoUtil.GetAddressFromPrivateKey(privateKey);
            byte[] iv = CryptoUtil.GenerateRandomBytes(16);
            byte[] salt = CryptoUtil.GenerateRandomBytes(32);
            var saltHex = ByteUtil.ByteArrayToHexString(salt);
            var derivedKey = GetDerivedKeyByteArray(passphrase, type, saltHex);

            byte[] encryptKey = new byte[16];
            Array.Copy(derivedKey, encryptKey, 16);

            KeyStore cry = new KeyStore();
            byte[] ciphertext = cry.GenerateAesCtrCipher(iv, encryptKey, ByteUtil.HexStringToByteArray(privateKey));
            //build struct
            CipherParams cipherParams = new CipherParams();
            cipherParams.Iv = ByteUtil.ByteArrayToHexString(iv);

            var crypto = new MusCipher();
            crypto.Cipher = "aes-128-ctr";
            crypto.Cipherparams = cipherParams;
            crypto.Ciphertext = ByteUtil.ByteArrayToHexString(ciphertext);
            crypto.Kdf = (type == KDFType.PBKDF2 ? "pbkdf2" : "scrypt");
            crypto.KdfParams = new KDFParams() { Salt = saltHex };
            crypto.Mac = ByteUtil.ByteArrayToHexString(HashUtil.GenerateMac(derivedKey,ciphertext));

            KeyStore key = new KeyStore();
            key.Address = "0x" + address;
            key.Crypto = crypto;
            key.Id = Guid.NewGuid().ToString();
            key.Version = 3;

            return JsonConvert.SerializeObject(key);
        }

        private byte[] GetDerivedKeyByteArray(string passphrase, KDFType type, string saltHex)
        {
            byte[] derivedKey;
            if (type == KDFType.PBKDF2)
            {
                PBKDF2Params pbkdf2Params = new PBKDF2Params();

                pbkdf2Params.Salt = saltHex;
                pbkdf2Params.DkLen = 32;
                pbkdf2Params.Count = 262144;
                derivedKey = GetDerivedKey(passphrase, pbkdf2Params);
            }
            else
            {
                var scryptParams = new KDFParams();

                scryptParams.Salt = saltHex;

                scryptParams.dklen = 32;
                scryptParams.p = 1;
                scryptParams.r = 8;
                scryptParams.n = 8192;
                derivedKey = GetDerivedKey(passphrase, scryptParams);
            }

            return derivedKey;
        }

        public string DecryptPrivateKey(string keyStoreJson, string passphrase)
        {
            KeyStore keystore = JsonConvert.DeserializeObject<KeyStore>(keyStoreJson);

            byte[] ciphertext = ByteUtil.HexStringToByteArray(keystore.Crypto.Ciphertext);
            byte[] iv = ByteUtil.HexStringToByteArray(keystore.Crypto.Cipherparams.Iv);
            KDFParams kp = keystore.Crypto.KdfParams;
            string kdf = keystore.Crypto.Kdf;
            byte[] derivedKey = GetDerivedKeyByteArray(passphrase, kdf == "pbkdf2" ? KDFType.PBKDF2 : KDFType.Scrypt, kp.Salt); 
            //if (kdf == "pbkdf2")
            //{
            //    PBKDF2Params pbkdf2Params = new PBKDF2Params();
            //    pbkdf2Params.Salt = kp.Salt;
            //    pbkdf2Params.DkLen = 32;
            //    pbkdf2Params.Count = 262144;
            //    derivedKey = GetDerivedKey(Encoding.Default.GetBytes(passphrase), pbkdf2Params);
            //}
            //else
            //{
            //    KDFParams scryptParams = new KDFParams();
            //    scryptParams.Salt = kp.Salt;
            //    scryptParams.dklen = 32;
            //    scryptParams.p = 1;
            //    scryptParams.r = 8;
            //    scryptParams.n = 8192;

            //    derivedKey = GetDerivedKey(Encoding.Default.GetBytes(passphrase), scryptParams);
            //}
            string mac = ByteUtil.ByteArrayToHexString(HashUtil.GenerateMac(derivedKey, ciphertext));
            if (mac.ToUpper() != keystore.Crypto.Mac)
            {
                throw new Exception("Failed to decrypt.");
            }

            byte[] encryptKey = new byte[16];
            Array.Copy(derivedKey, encryptKey, 16);

            byte[] ciphertextByte = GenerateAesCtrCipher(iv, encryptKey, ciphertext);

            return ByteUtil.ByteArrayToHexString(ciphertextByte);

        }
        private void ValidateMac(byte[] mac, byte[] cipherText, byte[] derivedKey)
        {
            var generatedMac = HashUtil.GenerateMac(derivedKey, cipherText);
            if (ByteUtil.ByteArrayToHexString(generatedMac) != ByteUtil.ByteArrayToHexString(mac))
                throw new Exception(
                    "Cannot derive the same mac as the one provided from the cipher and derived key");
        }
    }
}
