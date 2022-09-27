using System;
using NUnit.Framework;
using Zilliqa.DesktopWallet.ApiClient.Accounts;
using Zilliqa.DesktopWallet.ApiClient.Crypto;
using Zilliqa.DesktopWallet.ApiClient.Utils;

namespace Zilliqa.DesktopWallet.ApiClient.Test.UtilityTests
{
    public class UtilTests
    {
        [Test]
        public void CreateAccountSaveAndLoadJson()
        {
            var password = "password1234567890";
            var account = new Account(Schnorr.GenerateKeyPair());
            var json = account.ToJson(password, KDFType.PBKDF2);
            var loadedAccount = new Account(json, password);
            Assert.AreEqual(account.GetPublicKey(), loadedAccount.GetPublicKey());
            Assert.AreEqual(account.GetPrivateKey(), loadedAccount.GetPrivateKey());
        }

        [Test]
        public void ByteUtilHexToByteArrayAndBack()
        {
            var hex = "888DB13C7B1513BD824558C0AD2D566FE114155B54D6E125E402BEF8C4187A5266";
            var byteArray = ByteUtil.HexStringToByteArray(hex);
            var hex2 = ByteUtil.ByteArrayToHexString(byteArray);
            Assert.AreEqual(hex, hex2);
        }

        #region Encode/Decode

        [Test]
        public void AddressEncode()
        {
            var address = "0x551AA8653Aa7b75D9fDD75f5D4D41d0647F734E8"; 
            var address2 = "0xFd154D1340e4d0c5F443eEB37891aC0e4EC25605";
            var bech = MusBech32.FromBase16ToBech32Address(address);
            var bech2 = MusBech32.FromBase16ToBech32Address(address2);

            Assert.IsTrue(bech.StartsWith("zil") && bech2.StartsWith("zil"));
            Console.WriteLine("Starts with zil");
            Assert.AreEqual("zil125d2sef657m4m87awh6af4qaqerlwd8gv6fglj", bech);
            Console.WriteLine($"Address1 : zil125d2sef657m4m87awh6af4qaqerlwd8gv6fglj <-> {bech}");
            Assert.AreEqual("zil1l5256y6qungvtazra6eh3ydvpe8vy4s9rl87ec", bech2);
            Console.WriteLine($"Address1 : zil125d2sef657m4m87awh6af4qaqerlwd8gv6fglj <->{bech}");
        }

        [Test]
        public void GetBech32FromBase16()
        {
            var base16 = "0xbea37a0fe8f759d5cfe2ba66913a676260175ba1";
            var bech32 = base16.FromBase16ToBech32Address();
            Assert.IsNotNull(bech32);
        }

        [Test]
        public void AddressDecode()
        {
            var encStr = "zil1fs6jhg4axvj9ekscq6v7ddwxxd9tthpxl7820q";

            var dec = MusBech32.FromBech32ToBase16Address(encStr);

            Assert.AreEqual("0x" + "4C352ba2Bd33245CDA180699e6B5c6334AB5dC26".ToUpper(), dec);
        }
        [Test]
        public void AddressDecodeEncode()
        {
            var encStr = "zil1fs6jhg4axvj9ekscq6v7ddwxxd9tthpxl7820q";
            var length = encStr.Length;
            var dec = MusBech32.Decode(encStr);
            var enc = MusBech32.Encode(dec);
            Assert.AreEqual(encStr,enc);
        }

        #endregion

        #region ByteUtil

        [Test]
        public void ConvertStringToHex()
        {
            var t = ByteUtil.LongToBaseN(15, 16);
            Assert.AreEqual("F", t);

        }
        [Test]
        public void ConvertStringToB32()
        {
            var t = ByteUtil.LongToBaseN(64, 32);
            Assert.AreEqual("20", t);
        }

        [Test]
        public void ConverToBinary()
        {
            var t = ByteUtil.LongToBaseN(8, 2);
            Assert.AreEqual("1000", t);
        }

        [Test]
        public void GetHexString()
        {
            var s = ByteUtil.HexStringToByteArray("FF");
            var t = ByteUtil.ConvertByteArrToString(s);
            Assert.AreEqual(t, "11111111");
        }

        #endregion

        

    }
}
