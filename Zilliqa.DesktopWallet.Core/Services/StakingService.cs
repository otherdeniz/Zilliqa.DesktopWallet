using System.Collections.ObjectModel;
using System.Runtime.Caching;
using Newtonsoft.Json.Linq;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.ApiClient.Accounts;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

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

        public static readonly string ContractMethodStake = "DelegateStake";
        public static readonly string ContractMethodClaim = "WithdrawStakeRewards";

        public static StakingService Instance { get; } = new();

        private static readonly MemoryCache Cache = new MemoryCache("StakingService");
        private static readonly object CacheLock = new();
        private StakingProxyContract? _currentProxy;
        private string? _currentImplementationAddress;
        private List<StakingSeedNode>? _stakingSeedNodes;

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

        public SendTransactionResult SendTransactionStake(Account senderAccount, AddressValue ssnAddress, 
            decimal zilAmount)
        {
            var contractCall = new DataContractCall
            {
                Tag = "DelegateStake",
                Params = new List<DataParam>
                {
                    new DataParam
                    {
                        Vname = "ssnaddr",
                        Type = ParamTypes.ByStr20,
                        Value = ssnAddress.Address.GetBase16(true)
                    }
                }
            };
            return SendTransactionService.Instance.CallContract(senderAccount, new AddressValue(CurrentProxy.Address),
                contractCall, zilAmount);
        }

        public SendTransactionResult SendTransactionClaim(Account senderAccount, AddressValue ssnAddress)
        {
            var contractCall = new DataContractCall
            {
                Tag = "WithdrawStakeRewards",
                Params = new List<DataParam>
                {
                    new DataParam
                    {
                        Vname = "ssnaddr",
                        Type = ParamTypes.ByStr20,
                        Value = ssnAddress.Address.GetBase16(true)
                    }
                }
            };
            return SendTransactionService.Instance.CallContract(senderAccount, new AddressValue(CurrentProxy.Address), 
                contractCall);
        }

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
            if (_stakingSeedNodes == null)
            {
                var jsonResult = (JToken)Task.Run(async () =>
                {
                    return await ZilliqaClient.DefaultInstance.GetSmartContractSubState(new object[]
                        { ImplementationAddress, "ssnlist", new object[] { } });
                }).GetAwaiter().GetResult();
                _stakingSeedNodes = jsonResult.First?.First?.Children().Select(t => new StakingSeedNode(t)).ToList()
                       ?? throw new RuntimeException("Failed to get SeedNodeList of Staking Implementation Contract");
                Task.Run(() =>
                {
                    var lastCycle = Task.Run(async () =>
                            await ZilliqaClient.DefaultInstance.GetSmartContractSubStateValue(
                                ImplementationAddress, "lastrewardcycle"))
                        .GetAwaiter().GetResult()
                        .Value<int>();
                    foreach (var stakingSeedNode in _stakingSeedNodes)
                    {
                        stakingSeedNode.CalculateApyLast24H(lastCycle - 15);
                    }
                });
            }
            return _stakingSeedNodes;
        }

        /// <summary>
        /// Get all Delegators for SSN
        /// value is in ZIL
        /// </summary>
        public List<StakingNodeDelegator> GetDelegators(string stakeNodeAddress)
        {
            try
            {
                var keyValues = Task.Run(async () =>
                    await ZilliqaClient.DefaultInstance.GetSmartContractSubStateValues<decimal>(
                        ImplementationAddress, "ssn_deleg_amt", new Address(stakeNodeAddress).GetBase16(true))
                ).GetAwaiter().GetResult();
                return keyValues.Select(kv => new StakingNodeDelegator(kv.Key, kv.Value)).ToList();
            }
            catch (Exception e)
            {
                Logging.LogError($"StakingService.GetDelegators('{stakeNodeAddress}') failed", e);
                return new List<StakingNodeDelegator>();
            }
        }

        /// <summary>
        /// Get Staked Funds for a Delegator on each SSN
        /// value is in ZIL
        /// </summary>
        public List<StakingDelegatorAmount> GetStakedAmounts(Address delegatorAddress)
        {
            try
            {
                var keyValues = Task.Run(async () =>
                    await ZilliqaClient.DefaultInstance.GetSmartContractSubStateValues<decimal>(
                        ImplementationAddress, "deposit_amt_deleg", delegatorAddress.GetBase16(true))
                ).GetAwaiter().GetResult();
                return keyValues.Select(kv => new StakingDelegatorAmount(kv.Key, kv.Value)).ToList();
            }
            catch (Exception e)
            {
                Logging.LogError($"StakingService.GetStakedAmount('{delegatorAddress.GetBech32()}') failed", e);
                return new List<StakingDelegatorAmount>();
            }
        }

        /// <summary>
        /// Get unclaimed rewards for a Delegator on each SSN
        /// value is in ZIL
        /// </summary>
        public List<StakingDelegatorAmount> GetUnclaimedRewardAmounts(Address delegatorAddress)
        {
            return new List<StakingDelegatorAmount>();
        }

        public decimal GetPendingWithdrawAmount(Address delegatorAddress)
        { 
            try
            {
                var keyValues = Task.Run(async () =>
                    await ZilliqaClient.DefaultInstance.GetSmartContractSubStateValues<long>(
                        ImplementationAddress, "withdrawal_pending", delegatorAddress.GetBase16(true))
                ).GetAwaiter().GetResult().ToList();
                return
                    keyValues.Any()
                        ? keyValues.Sum(kv => kv.Value).ZilSatoshisToZil()
                        : 0;
            }
            catch (Exception e)
            {
                Logging.LogError($"StakingService.GetPendingWithdrawAmounts('{delegatorAddress.GetBech32()}') failed", e);
                return 0;
            }
        }

        public List<StakingSeedNodeRewards> GetStakingSeedNodeRewards()
        {
            return Cache.GetOrAdd("GetStakingSeedNodeRewards", TimeSpan.FromMinutes(30), () =>
            {
                var jsonResult = (JToken)Task.Run(async () =>
                {
                    return await ZilliqaClient.DefaultInstance.GetSmartContractSubState(new object[]
                        { ImplementationAddress, "stake_ssn_per_cycle", new object[] { } });
                }).GetAwaiter().GetResult();
                return jsonResult.First?.First?.Children().Select(t => new StakingSeedNodeRewards(t)).ToList();
            }, CacheLock) ?? new List<StakingSeedNodeRewards>();
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

    public class StakingDelegatorAmount
    {
        public StakingDelegatorAmount(string stakingNode, decimal stakeAmountZilSatoshis)
        {
            StakingNodeAddress = stakingNode;
            StakeAmount = stakeAmountZilSatoshis.ZilSatoshisToZil();
        }
        public string StakingNodeAddress { get; }
        public decimal StakeAmount { get; }
    }

    public class StakingNodeDelegator
    {
        public StakingNodeDelegator(string delegatorAddress, decimal stakeAmountZilSatoshis)
        {
            DelegatorAddress = delegatorAddress;
            StakeAmount = stakeAmountZilSatoshis.ZilSatoshisToZil();
        }
        public string DelegatorAddress { get; }
        public decimal StakeAmount { get; }
    }

    public class StakingSeedNode
    {
        private decimal? _apyLast24h;

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
        public StakingSeedNode(string address)
        {
            SsnAddress = address;
            Name = address;
            CommissioningAddress = address;
        }
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
        public string? StakingApiUrl { get; }
        public string? ApiUrl { get; }
        public decimal BufferedDeposit { get; }
        public decimal CommissionRate { get; }
        public decimal CommissionRatePercent => CommissionRate / 10000000;
        public decimal CommissionRewards { get; }
        public string CommissioningAddress { get; }

        public decimal ApyLast24H => _apyLast24h ?? 0;

        public void CalculateApyLast24H(int aboveCycle)
        {
            if (_apyLast24h == null)
            {
                var ssnRewards = StakingService.Instance.GetStakingSeedNodeRewards()
                    .FirstOrDefault(ssn => ssn.SsnAddress == SsnAddress);
                if (ssnRewards != null)
                {
                    _apyLast24h = ssnRewards.RewardsPerCycle
                        .Where(r => r.Cycle > aboveCycle)
                        .TakeLast(10).Sum(r => r.RewardPercent) * 36.5m;
                }
                else
                {
                    _apyLast24h = 0;
                }
            }
        }
    }

    public class StakingSeedNodeRewards
    {
        public StakingSeedNodeRewards(JToken ssnJToken)
        {
            SsnAddress = ((JProperty)ssnJToken).Name;
            RewardsPerCycle = ssnJToken.First!.Children()
                .Select(j => new StakingSeedNodeRewardPerCycle(j))
                .OrderByDescending(c => c.Cycle)
                .ToList();
        }

        public string SsnAddress { get; }

        public List<StakingSeedNodeRewardPerCycle> RewardsPerCycle { get; }
    }

    public class StakingSeedNodeRewardPerCycle
    {
        public StakingSeedNodeRewardPerCycle(JToken cycleJToken)
        {
            var cycleJProperty = (JProperty)cycleJToken;
            Cycle = int.TryParse(cycleJProperty.Name, out var intValue) ? intValue : -1;
            var argumentList = cycleJProperty.First!.SelectToken("arguments")!.Children().ToList();
            StakedAmount = argumentList[0].Value<decimal>();
            RewardAmount = argumentList[1].Value<decimal>();
        }

        public int Cycle { get; }

        public decimal StakedAmount { get; }

        public decimal RewardAmount { get; }

        public decimal RewardPercent => StakedAmount > 0 && RewardAmount > 0
            ? 100m / StakedAmount * RewardAmount
            : 0m;
    }
}
