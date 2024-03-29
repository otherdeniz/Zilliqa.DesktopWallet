﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Device.Net;
using Hardwarewallets.Net.AddressManagement;
using Hid.Net.Windows;
using Ledger.Net.Requests;
using Ledger.Net.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usb.Net.Windows;

namespace Ledger.Net.Tests
{
    [TestClass]
    public class ZilliqaTests
    {
        protected static LedgerManagerBroker _LedgerManagerBroker;

        protected static ZilLedgerManager LedgerManager
        {
            get
            {
                var i = 0;

                while (_LedgerManagerBroker.LedgerManagers.Count == 0)
                {
                    Thread.Sleep(100);
                    i++;
                    if (i > 200) throw new Exception("Waited too long");
                }

                return (ZilLedgerManager)_LedgerManagerBroker.LedgerManagers.First();
            }
        }

        /// <summary>
        /// This func is not necessary, but it is an example of how to make a call so that the user can be prompted with UI prompts based on the current state of the Ledger device
        /// </summary>
        private readonly Func<CallAndPromptArgs<GetAddressArgs>, Task<GetPublicKeyResponseBase>> _GetPublicKeyFunc = new Func<CallAndPromptArgs<GetAddressArgs>, Task<GetPublicKeyResponseBase>>(async (s) =>
        {
            var lm = s.LedgerManager;

            var data = Helpers.GetDerivationPathData(s.Args.AddressPath);

            GetPublicKeyResponseBase response;

            switch (lm.CurrentCoin.App)
            {
                case App.Ethereum:
                    //TODO: don't use the RequestHandler directly.
                    response = await lm.RequestHandler.SendRequestAsync<EthereumAppGetPublicKeyResponse, EthereumAppGetPublicKeyRequest>(new EthereumAppGetPublicKeyRequest(s.Args.ShowDisplay, false, data));
                    break;
                case App.Bitcoin:
                    //TODO: Should we use the Coin's IsSegwit here?
                    //TODO: don't use the RequestHandler directly.
                    response = await lm.RequestHandler.SendRequestAsync<BitcoinAppGetPublicKeyResponse, BitcoinAppGetPublicKeyRequest>(new BitcoinAppGetPublicKeyRequest(s.Args.ShowDisplay, BitcoinAddressType.Segwit, data));
                    break;
                default:
                    throw new NotImplementedException();
            }

            return response;
        });

        [TestInitialize]
        public void Initialize()
        {
            WindowsHidDeviceFactory.Register(new DebugLogger(), new DebugTracer());
            WindowsUsbDeviceFactory.Register(new DebugLogger(), new DebugTracer());
            _LedgerManagerBroker = new LedgerManagerBroker(3000, null, Prompt, new ZilliqaLedgerManagerFactory());
            _LedgerManagerBroker.Start();
        }

        protected static async Task Prompt(int? returnCode, Exception exception, string member)
        {
            if (returnCode.HasValue)
            {
                switch (returnCode.Value)
                {
                    case Constants.IncorrectLengthStatusCode:
                        Debug.WriteLine($"Please ensure the app  is open on the Ledger, and press OK");
                        break;
                    case Constants.SecurityNotValidStatusCode:
                        Debug.WriteLine($"It appears that your Ledger pin has not been entered, or no app is open. Please ensure the app   is open on the Ledger, and press OK");
                        break;
                    case Constants.InstructionNotSupportedStatusCode:
                        Debug.WriteLine($"The current app is incorrect. Please ensure the app for  is open on the Ledger, and press OK");
                        break;
                    default:
                        Debug.WriteLine($"Something went wrong. Please ensure the app   is open on the Ledger, and press OK"); //user pressed cancel button = 27013
                        break;
                }
            }
            else
            {
                if (exception is IOException)
                {
                    await Task.Delay(3000);
                    //TODO: don't use the RequestHandler directly.
                    var ledgerManagerTransport = LedgerManager.RequestHandler as LedgerManagerTransport;
                    await ledgerManagerTransport.LedgerHidDevice.InitializeAsync();
                }
            }

            await Task.Delay(5000);
        }

        [TestMethod]
        public async Task GetZilliqaWalletInfo()
        {
            var path = $"m/44'/313'/1'/0/0";
            var addressPath = AddressPathBase.Parse<BIP44AddressPath>(path);
            var address = await LedgerManager.GetAddressAsync(addressPath, false, true);

            //var address = await LedgerManager.GetAddressAsync(10000, false, 10000, true);
            Assert.IsTrue(!string.IsNullOrEmpty(address));

        }


        private async Task<string> SignZilTransaction(string transactionRaw, string path, int? expectedDataLength = null)
        {
            //LedgerManager.SetCoinNumber(195);

            var transactionData = new List<byte>();

            for (var i = 0; i < transactionRaw.Length; i += 2)
            {
                var byteInHex = transactionRaw.Substring(i, 2);
                transactionData.Add(Convert.ToByte(byteInHex, 16));
            }

            var zilAddressPath = new BIP44AddressPath(false, 313U, 0U, false, 0U);
            var derivationData = Helpers.GetDerivationPathData(zilAddressPath);

            var firstRequest = new ZilliqaAppSignatureRequest(derivationData.Concat(transactionData).ToArray());

            //TODO: don't use the RequestHandler directly.
            var response = await LedgerManager.RequestHandler.SendRequestAsync<ZilliqaAppSignatureResponse, ZilliqaAppSignatureRequest>(firstRequest);

            var data = response.Data;

            var hexAsString = HexDataToString(data);

            Console.WriteLine(hexAsString);

            Console.WriteLine($"Length: {hexAsString.Length}");

            Assert.IsTrue(response.IsSuccess, $"The response failed with a status of: {response.StatusMessage} ({response.ReturnCode})");

            return hexAsString;

            //Assert.IsTrue(!expectedDataLength.HasValue || hexAsString.Length == expectedDataLength, $"Expected legnth {expectedDataLength}. Actual: {hexAsString.Length}");
        }

        private static string HexDataToString(byte[] data)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("X2"));
            }
            var hexAsString = sb.ToString();
            return hexAsString;
        }

    }
}
