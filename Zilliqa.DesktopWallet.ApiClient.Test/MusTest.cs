﻿using NUnit.Framework;
using Zilliqa.DesktopWallet.ApiClient.Accounts;
using Zilliqa.DesktopWallet.ApiClient.API;

namespace Zilliqa.DesktopWallet.ApiClient.Test
{
    /// <summary>
    /// Uses a wallet generated at https://dev-wallet.zilliqa.com/generate 
    /// </summary>
    public class MusTest
    {
        protected MusZil_APIClient _client;
        protected Address _address;
        protected Account _account;
        protected ZilliqaClient _zil;
        private string _pk = "a8f8f4c1e76e09c61dfeac0e1f73cf48c58bff0de81243a20a1ff087dc5fa08a";

        
        
        const string DEV_URL = "https://dev-api.zilliqa.com/";
        
        [SetUp]
        public virtual void SetUp()
        {
            _client = new MusZil_APIClient(DEV_URL);
            _address = new Address("zil1fs6jhg4axvj9ekscq6v7ddwxxd9tthpxl7820q");
            _account = new Account(_pk);
            _zil = new ZilliqaClient();
        }
    }
}
