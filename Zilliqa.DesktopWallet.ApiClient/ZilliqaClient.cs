﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Zilliqa.DesktopWallet.ApiClient.Accounts;
using Zilliqa.DesktopWallet.ApiClient.API;
using Zilliqa.DesktopWallet.ApiClient.Contracts;
using Zilliqa.DesktopWallet.ApiClient.Interfaces;
using Zilliqa.DesktopWallet.ApiClient.Model;

namespace Zilliqa.DesktopWallet.ApiClient
{
    public class ZilliqaClient
    {
		public static readonly string TestnetBaseUrl = "https://dev-api.zilliqa.com/";
		public static readonly string MainnetBaseUrl = "https://api.zilliqa.com/";

        private static ZilliqaClient _defaultClient;
        public static ZilliqaClient DefaultInstance => _defaultClient ??= new ZilliqaClient();

		public static bool UseTestnet { get; set; }

        private IZilliqaAPIClient<MusResult> _client;

        public ZilliqaClient() : this(UseTestnet)
        {
        }
		public ZilliqaClient(bool test) {
			_client = test 
                ? new MusZil_APIClient(TestnetBaseUrl)
                : new MusZil_APIClient(MainnetBaseUrl);
		}
        
		#region Accounts

		/// <summary>
		/// Gets balance from account
		/// </summary>
		/// <param name="address"></param>
		/// <returns></returns>
		public async Task<Balance> GetBalance(string address)
		{
			var res = await _client.GetBalance(address);
            if (res.Error && res.Message == "Account is not created")
            {
                return new Balance(0);
            }
            ThrowOnError(res);
			return ((JObject)res.Result).ToObject<Balance>();
		}
		public async Task<Balance> GetBalance(Address address)
		{
			return await GetBalance(address.GetBase16(false));
		}
		public async Task<Balance> GetBalance(Account acc)
		{
			return await GetBalance(acc.Address.GetBase16(false));
		}
		#endregion

		#region BlockChain
		public async Task<int> GetNetworkId()
		{
			var res = await _client.GetNetworkId();
            ThrowOnError(res);
			return int.Parse((string)res.Result);
		}

		public async Task<BlockchainInfo> GetBlockchainInfo()
		{
			var resp = await _client.GetBlockchainInfo();
            ThrowOnError(resp);
			return ((JToken)resp.Result).ToObject<BlockchainInfo>();
		}

		public async Task<DSBlock> GetDsBlock(int blockNumber)
		{
			var resp = await _client.GetDsBlock(blockNumber.ToString());
            ThrowOnError(resp);
			return ((JToken)resp.Result).ToObject<DSBlock>();
		}
		public async Task<DSBlock> GetLatestDsBlock()
		{
			var resp = await _client.GetLatestDsBlock();
            ThrowOnError(resp);
			return ((JToken)resp.Result).ToObject<DSBlock>();
		}
		public async Task<int> GetNumDSBlocks()
		{
			var res = await _client.GetNumDSBlocks();
            ThrowOnError(res);
			return int.Parse((string)res.Result);
		}
		public async Task<double> GetDSBlockRate()
		{
			var resp = await _client.GetDSBlockRate();
            ThrowOnError(resp);
			return (double)resp.Result;
		}
		public async Task<BlockListing> GetDSBlockListing(int pageNumber = 1)
		{
			var resp = await _client.GetDSBlockListing(pageNumber);
            ThrowOnError(resp);
			return ((JToken)resp.Result).ToObject<BlockListing>();
		}
		public async Task<TxBlock> GetTxBlock(int blockNumber)
		{
			var resp = await _client.GetTxBlock(blockNumber.ToString());
            ThrowOnError(resp);
			return ((JToken)resp.Result).ToObject<TxBlock>();
		}
		public async Task<TxBlock> GetLatestTxBlock()
		{
			var resp = await _client.GetLatestDsBlock();
            ThrowOnError(resp);
			return ((JToken)resp.Result).ToObject<TxBlock>();
		}
		public async Task<int> GetNumTxBlocks()
		{
			var res = await _client.GetNumTxBlocks();
            ThrowOnError(res);
			return int.Parse((string)res.Result);
		}
		public async Task<double> GetTxBlockRate()
		{
			var resp = await _client.GetTxBlockRate();
            ThrowOnError(resp);
			return (double)resp.Result;
		}
		public async Task<BlockListing> GetTxBlockListing(int pageNumber)
		{
			var resp = await _client.GetTxBlockListing(pageNumber);
            ThrowOnError(resp);
			return ((JToken)resp.Result).ToObject<BlockListing>();
		}

		public async Task<int> GetNumTransactions()
		{
			var res = await _client.GetNumTransactions();
            ThrowOnError(res);
			return int.Parse((string)res.Result);
		}

		public async Task<double> GetTransactionRate()
		{
			var resp = await _client.GetTxBlockRate();
            ThrowOnError(resp);
			return (double)resp.Result;
		}

		public async Task<int> GetCurrentMiniEpoch()
		{
			var resp = await _client.GetCurrentMiniEpoch();
            ThrowOnError(resp);
			return int.Parse((string)resp.Result);
		}

		public async Task<int> GetCurrentDSEpoch()
		{
			var resp = await _client.GetCurrentDSEpoch();
            ThrowOnError(resp);
			return int.Parse((string)resp.Result);
		}

		public async Task<Int64> GetPrevDifficulty()
		{
			var resp = await _client.GetPrevDifficulty();
            ThrowOnError(resp);
			return (Int64)resp.Result;
		}

		public async Task<int> GetPrevDSDifficulty()
		{
			var resp = await _client.GetCurrentMiniEpoch();
            ThrowOnError(resp);
			return int.Parse((string)resp.Result);
		}

		public async Task<decimal> GetTotalCoinSupply()
		{
			var res = await _client.GetTotalCoinSupply();
            ThrowOnError(res);
			return decimal.Parse((string)res.Result);
		}
		#endregion

		#region Contracts

		/// <summary>
		/// Gets contractCode, overloaded with Address,Contract
		/// </summary>
		public async Task<string> GetSmartContractCode(string address)
		{
			var res = await _client.GetSmartContractCode(address);
            ThrowOnError(res);
			return res.Result.ToString();
		}
		public async Task<string> GetSmartContractCode(Address address)
		{
			return await GetSmartContractCode(address.RawAddress);
		}
		public async Task<string> GetSmartContractCode(SmartContract c)
		{
			return await GetSmartContractCode(c.Address.RawAddress);
		}
		/// <summary>
		/// Gets Contract Balance, overloaded with: Address,Contract
		/// </summary>
		public async Task<Balance> GetContractBalance(string address)
		{
			var res = await _client.GetContractBalance(address);
            ThrowOnError(res);
			var bal = (decimal)res.Result;
			return new Balance(bal);
		}
		public async Task<Balance> GetContractBalance(Address address)
		{
			return await GetContractBalance(address.RawAddress);
		}
		public async Task<Balance> GetContractBalance(SmartContract con)
		{
			return await GetContractBalance(con.Address.RawAddress);
		}

		/// <summary>
		/// Gets all contracts for one address
		/// </summary>
		public async Task<List<SmartContract>> GetSmartContracts(string address)
		{
			var res = await _client.GetSmartContracts(address);
            ThrowOnError(res);
			var l = new List<SmartContract>();
			if (res.Result != null)
			{
				foreach (var r in (JArray)res.Result)
				{
					l.Add(r.ToObject<SmartContract>());
				}
			}
			
			return l;
		}
		public async Task<List<SmartContract>> GetSmartContracts(Address address)
		{
			return await GetSmartContracts(address.GetBase16(true));
		}
		public async Task<List<SmartContract>> GetSmartContracts(Account account)
		{
			return await GetSmartContracts(account.Address.GetBase16(true));
		}

		/// <summary>
		/// Gets the contract address from tnx Id
		/// </summary>
		public async Task<Address> GetContractAddressFromTransactionID(string id)
		{
			var res = await _client.GetContractAddressFromTransactionID(id);
            ThrowOnError(res);
			var address = new Address(res.Result.ToString());
			return address;
		}

		public async Task<StateItem> GetSmartContractState(string address)
		{
			var res = await _client.GetSmartContractState(address);
            ThrowOnError(res);
			var it = ((JToken)res.Result).ToObject<StateItem>();
			it.AllValues = res.Result;
			return it;
		}

		public async Task<object> GetSmartContractSubState(object[] parameters)
		{
			var res = await _client.GetSmartContractSubState(parameters);
            ThrowOnError(res);
			return res.Result;
		}

        public async Task<TValue> GetSmartContractSubStateValue<TValue>(
            string contract,
            string contractField)
		    where TValue : class
        {
            return (await GetSmartContractSubStateValue(contract, contractField))?.Value<TValue>();
        }

        public async Task<JToken> GetSmartContractSubStateValue(
            string contract,
            string contractField)
        {
            var jsonResult = await GetSmartContractSubState(new object[]
                { contract, contractField, new object [] { } }) as JToken;
            return jsonResult?.First?.First;
        }

        public async Task<IEnumerable<KeyValuePair<string, TValue>>> GetSmartContractSubStateValues<TValue>(
            string contract,
            string contractField,
            string fieldArgument)
        {
            var jsonResult = await GetSmartContractSubState(new object[]
                { contract, contractField, new [] { fieldArgument } }) as JToken;
            return jsonResult?.First?.First?.First?.First?.Where(j => j is JProperty).Select(j =>
                   {
                       var jProp = (JProperty)j;
                       return new KeyValuePair<string, TValue>(jProp.Name, jProp.Value.Value<TValue>());
                   })
                   ?? Enumerable.Empty<KeyValuePair<string, TValue>>();
        }

		public async Task<string> GetSmartContractInit(string address)
		{
			var res = await _client.GetSmartContractInit(address);
            ThrowOnError(res);
			return res.Result.ToString();
		}
		#endregion

		#region Transactions
		public async Task<Transaction.Info> CreateTransaction(TransactionPayload payload)
		{
			
			var res = await _client.CreateTransaction(payload);
            ThrowOnError(res);
			return ((JToken)res.Result).ToObject<Transaction.Info>();
		}
		public async Task<Transaction.Info> CreateTransaction(string payload)
		{
			var res = await _client.CreateTransaction(payload);
            ThrowOnError(res);
			return ((JToken)res.Result).ToObject<Transaction.Info>();
		}

		public async Task<int> GetMinimumGasPrice()
		{
			var res = await _client.GetMinimumGasPrice();
            ThrowOnError(res);
			return int.Parse((string)res.Result);
		}


		public async Task<Transaction> GetTransaction(string hash)
		{
			var res = await _client.GetTransaction(hash);
            ThrowOnError(res);
			return ((JToken)res.Result).ToObject<Transaction>();
		}

		public async Task<List<string>> GetRecentTransactions()
		{
			var res = await _client.GetRecentTransactions();
            ThrowOnError(res);
			return ((JToken)res.Result).ToObject<List<string>>();
		}

		public async Task<List<string[]>> GetTransactionsForTxBlock(int blockNum)
		{
			var res = await _client.GetTransactionsForTxBlock(blockNum.ToString());
			var list = new List<string[]>();
			if (!res.Error)
			{ 
				list = ((JToken)res.Result).ToObject<List<string[]>>();
			}
			else if (res.Message != "TxBlock has no transactions")
			{
                ThrowOnError(res);
			}

			return list;
		}

		public async Task<int> GetNumTxnsTxEpoch()
		{
			var res = await _client.GetNumTxnsTxEpoch();
            ThrowOnError(res);
			return int.Parse((string)res.Result);
		}

		public async Task<int> GetNumTxnsDSEpoch()
		{
			var res = await _client.GetNumTxnsDSEpoch();
            ThrowOnError(res);
			return int.Parse((string)res.Result);
		}
		public async Task<PendingTransaction> GetPendingTxn(string hash)
		{
			var res = await _client.GetPendingTxn(hash);
            ThrowOnError(res);
			return ((JToken)res.Result).ToObject<PendingTransactionInfo>();
		}
		public async Task<List<PendingTransaction>> GetPendingTxns()
		{
			var res = await _client.GetPendingTxns();
            ThrowOnError(res);
			return ((JToken)res.Result).ToObject<List<PendingTransaction>>();
		}

		public async Task<List<Transaction>> GetTxnBodiesForTxBlock(int blockNum)
		{
			var list = new List<Transaction>();
            var res = await _client.GetTxnBodiesForTxBlock(blockNum.ToString());
			if (!res.Error)
			{
				list = ((JToken)res.Result).ToObject<List<Transaction>>();
			}
			else if (res.Message == "Failed to get Microblock" && blockNum == 1664279)
            {
                // On Dec-15 2021, Zilliqa had a major AWS outage, that caused the loss of microblocks for the TX block 1664279
                // Because of the network outage, some of the sender nodes lost the message. That caused public nodes to not receive it and hence the API for that particular block is not queryable.
                list.Add(await GetTransaction("bc004fe44e0e76b23c4a7da48049453f7f99ea1508658715fa9d4773fbb92920"));
                list.Add(await GetTransaction("a563d171f9b4357808e4349440e040e650e0fac35c23c7b4f1c33509dd85448f"));
                list.Add(await GetTransaction("02d8e7e1db997fc7f13440ba02535a2c1f8a6cc94315797c6844f25ea1257c48"));
                list.Add(await GetTransaction("3f5c87ae8b215f5383e107c044b8faedfea247cd33c0835003bfd67ffa96bab8"));
				list.Add(new Transaction{Id = "fffde5f030d6f8e2aa4638a7117a7a063fbffe6e75b02f35393127c3caf6a168", Receipt = new Receipt() }); //list.Add(await GetTransaction("fffde5f030d6f8e2aa4638a7117a7a063fbffe6e75b02f35393127c3caf6a168")); (not found)
				list.Add(new Transaction{Id = "afac1600bfda9d73c9625f3146f7c47bbaf6c4cae621aee4387772d5fd669932", Receipt = new Receipt() }); //list.Add(await GetTransaction("afac1600bfda9d73c9625f3146f7c47bbaf6c4cae621aee4387772d5fd669932")); (not found)
			}
            else if (res.Message == "Failed to get Microblock" && UseTestnet)
            {
                throw new ZilliqaClientTestnetNoData();
            }
			else if ((res.Message == "Txn Hash not Present" && blockNum <= 175701)
                     || (res.Message == "Txn Hash not Present" && UseTestnet))
            {
                // the block should have more transactions but we only see a few, we fake the rest
				var transactionIdLists = await GetTransactionsForTxBlock(blockNum);
                foreach (var transactionIdList in transactionIdLists.Where(t => t?.Any() == true))
                {
                    foreach (var transactionId in transactionIdList)
                    {
                        try
                        {
                            list.Add(await GetTransaction(transactionId));
						}
                        catch (Exception)
                        {
                            //transaction not in block
                            list.Add(new Transaction { Id = transactionId, Receipt = new Receipt() });
                        }
					}
				}
            }
			else if (res.Message != "TxBlock has no transactions")
            {
                ThrowOnError(res);
			}
			return list;
		}

		/// <summary>
		/// This API behaves similar to GetTxBodiesForTxBlock except it returns the transactions in batches (or pages) of 2,500.
		/// This API is available from Zilliqa V7.2.0 onwards.
		/// </summary>
		public async Task<TransactionPage> GetTxnBodiesForTxBlockEx(int blockNum, int pageNum)
        {
            var res = await _client.GetTxnBodiesForTxBlockEx(blockNum.ToString(), pageNum.ToString());
            ThrowOnError(res);
            return ((JToken)res.Result).ToObject<TransactionPage>();
        }

		#endregion

		private void ThrowOnError(MusResult result)
        {
            if (result.Error)
            {
                throw new ZilliqaClientException(result.Message);
            }
        }
    }
}
