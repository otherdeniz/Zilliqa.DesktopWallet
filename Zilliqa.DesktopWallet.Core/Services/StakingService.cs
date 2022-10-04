﻿using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient;

namespace Zilliqa.DesktopWallet.Core.Services
{
    public class StakingService
    {
        public static readonly ReadOnlyCollection<StakingProxyContract> StakingProxies
            = new (new List<StakingProxyContract>
            {
                new ("62a9d5d611cdcae8d78005f31635898330e06b93", 1.1m, true), // zil1v25at4s3eh9w34uqqhe3vdvfsvcwq6un3fupc2
                new ("351a37e2841a45c7f2de18ee45f968e106416273", 1.0m, false) // zil1x5dr0c5yrfzu0uk7rrhyt7tguyryzcnn8q75pc
            });

        public static StakingService Instance { get; } = new();

        private StakingProxyContract? _currentProxy;
        private string? _currentImplementationAddress;

        private StakingService()
        {
        }

        public StakingProxyContract CurrentProxy => _currentProxy ??= StakingProxies
            .OrderByDescending(p => p.Version)
            .First(p => p.IsMainnet != ZilliqaClient.UseTestnet);

        /// <summary>
        /// Hex Address without leading '0x'
        /// </summary>
        public string ImplementationAddress =>
            _currentImplementationAddress ??= GetImplementationAddress(CurrentProxy.Address);

        public string GetImplementationAddress(string proxyAddress)
        {
            var jsonResult = (JToken)Task.Run(async () =>
            {
                return await ZilliqaClient.DefaultInstance.GetSmartContractSubState(new object[]
                    { proxyAddress, "implementation", new object[] { } });
            }).GetAwaiter().GetResult();
            var stakingImplementationAddress = jsonResult.First?.First?.Value<string>();
            if (stakingImplementationAddress?.StartsWith("0x") == true)
            {
                return stakingImplementationAddress.Substring(2);
            }
            throw new RuntimeException("Failed to get Proxy Implementation of Staking Proxy");
        }

        public List<StakingSeedNode> GetSeedNodeList()
        {
            var jsonResult = (JToken)Task.Run(async () =>
            {
                return await ZilliqaClient.DefaultInstance.GetSmartContractSubState(new object[]
                    { ImplementationAddress, "ssnlist", new object[] { } });
            }).GetAwaiter().GetResult();
            return jsonResult.First?.First?.Children().Select(t => new StakingSeedNode(t)).ToList()
                ?? throw new RuntimeException("Failed to get SeedNodeList of Staking Implementation Contract");
        }
    }

    public class StakingProxyContract
    {
        internal StakingProxyContract(string address, decimal version, bool isMainnet)
        {
            Address = address;
            Version = version;
            IsMainnet = isMainnet;
        }

        public string Address { get; }

        public decimal Version { get; }

        public bool IsMainnet { get; }
    }

    public class StakingSeedNode
    {
        //"arguments": [
        //    {
        //        "argtypes": [],
        //        "arguments": [],
        //        "constructor": "<ActiveStatus>"
        //    },
        //    "<StakeAmount>",
        //    "<StakeRewards>",
        //    "<name of ssn>",
        //    "<staking api url>",
        //    "<api url>",
        //    "<buffered deposit>",
        //    "<comission rate>",
        //    "<commssion rewards>",
        //    "<ssn commission receiving address>"
        //]
        public StakingSeedNode(JToken ssnJToken)
        {
            SsnAddress = ((JProperty)ssnJToken).Name;
            var argumentList = ssnJToken.First.SelectToken("arguments").Children().ToList();
            StakeAmount = argumentList[1].Value<decimal>();
            StakeRewards = argumentList[2].Value<decimal>();
            Name = argumentList[3].Value<string>() ?? "";
            StakingApiUrl = argumentList[4].Value<string>() ?? "";
            ApiUrl = argumentList[5].Value<string>() ?? "";
            BufferedDeposit = argumentList[6].Value<decimal>();
            CommissionRate = argumentList[7].Value<decimal>();
            CommissionRewards = argumentList[8].Value<decimal>();
            CommissioningAddress = argumentList[9].Value<string>() ?? "";
        }
        public string SsnAddress { get; }
        public decimal StakeAmount { get; }
        public decimal StakeRewards { get; }
        public string Name { get; }
        public string StakingApiUrl { get; }
        public string ApiUrl { get; }
        public decimal BufferedDeposit { get; }
        public decimal CommissionRate { get; }
        public decimal CommissionRewards { get; }
        public string CommissioningAddress { get; }
    }
}