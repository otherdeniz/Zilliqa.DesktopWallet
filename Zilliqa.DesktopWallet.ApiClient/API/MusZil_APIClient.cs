using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient.Interfaces;

namespace Zilliqa.DesktopWallet.ApiClient.API
{
	public class MusZil_APIClient : IZilliqaAPIClient<MusResult>
	{
		public string Url { get; }

		public MusZil_APIClient(string url)
		{
			Url = url;
		}

		#region Accounts

		public async Task<MusResult> GetBalance(string address)
		{
			var req = new MusRequest("GetBalance", address);
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}
		
		#endregion

		#region BlockChain

		public async Task<MusResult> GetNetworkId()
		{
			var req = RequestFactory.New("GetNetworkId", "");
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}

		public async Task<MusResult> GetBlockchainInfo()
		{
			var req = RequestFactory.New("GetBlockchainInfo", "");
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}

		public async Task<MusResult> GetDsBlock(string blockNumber)
		{
			var req = RequestFactory.New("GetDsBlock", blockNumber);
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}
		public async Task<MusResult> GetLatestDsBlock()
		{
			var req = RequestFactory.New("GetLatestDsBlock", "");
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}
		public async Task<MusResult> GetNumDSBlocks()
		{
			var req = RequestFactory.New("GetNumDSBlocks", "");
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}
		public async Task<MusResult> GetDSBlockRate()
		{
			var req = RequestFactory.New("GetDSBlockRate", "");
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}
		public async Task<MusResult> GetDSBlockListing(int blockNum)
		{
			var req = RequestFactory.New("DSBlockListing", new object[] { blockNum });
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}
		public async Task<MusResult> GetTxBlock(string blockNumber)
		{
			var req = RequestFactory.New("GetTxBlock", blockNumber);
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}
		public async Task<MusResult> GetLatestTxBlock()
		{
			var req = RequestFactory.New("GetLatestTxBlock", "");
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}
		public async Task<MusResult> GetNumTxBlocks()
		{
			var req = RequestFactory.New("GetNumTxBlocks", "");
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}
		public async Task<MusResult> GetTxBlockRate()
		{
			var req = RequestFactory.New("GetTxBlockRate", "");
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}
		public async Task<MusResult> GetTxBlockListing(int pageNumber)
		{
			var req = RequestFactory.New("TxBlockListing", new object[] { pageNumber });
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}

		public async Task<MusResult> GetNumTransactions()
		{
			var req = RequestFactory.New("GetNumTransactions", "");
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}

		public async Task<MusResult> GetTransactionRate()
		{
			var req = RequestFactory.New("GetTransactionRate", "");
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}

		public async Task<MusResult> GetCurrentMiniEpoch()
		{
			var req = RequestFactory.New("GetCurrentMiniEpoch", "");
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}

		public async Task<MusResult> GetCurrentDSEpoch()
		{
			var req = RequestFactory.New("GetCurrentDSEpoch", "");
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}

		public async Task<MusResult> GetPrevDifficulty()
		{
			var req = RequestFactory.New("GetPrevDifficulty", "");
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}

		public async Task<MusResult> GetPrevDSDifficulty()
		{
			var req = RequestFactory.New("GetPrevDSDifficulty");
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}

		public async Task<MusResult> GetTotalCoinSupply()
		{
			var req = RequestFactory.New("GetTotalCoinSupply");
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}

		#endregion

		#region Contracts

		/// <summary>
		/// Gets contractCode, overloaded with Address,Contract
		/// </summary>
		public async Task<MusResult> GetContractCode(string address)
		{
			var req = new MusRequest("GetSmartContractCode", address.TrimStart('0').TrimStart('x'));
			var result = await CallMethod(req);
			return ResponseHandler.GetContractCode(ref result);
		}

		public async Task<MusResult> GetContractBalance(string address)
		{
			var req = new MusRequest("GetSmartContractState", address.TrimStart('0').TrimStart('x'));
			var result = await CallMethod(req);
			return ResponseHandler.GetContractBalance(ref result);
		}

		/// <summary>
		/// Gets all contracts for one account
		/// </summary>
		public async Task<MusResult> GetSmartContractCode(string address)
		{
			var req = RequestFactory.New("GetSmartContractCode", address);
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}

		public async Task<MusResult> GetSmartContracts(string address)
		{
			var req = RequestFactory.New("GetSmartContracts", address);
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}

		public async Task<MusResult> GetContractAddressFromTransactionID(string id)
		{
			var req = RequestFactory.New("GetContractAddressFromTransactionID", id);
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}


		public async Task<MusResult> GetSmartContractState(string address)
		{
			var req = RequestFactory.New("GetSmartContractState", address);
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);

		}
		public async Task<MusResult> GetSmartContractSubState(object[] parameters)
		{
			var req = RequestFactory.New("GetSmartContractSubState", parameters);
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);

		}

		public async Task<MusResult> GetSmartContractInit(string address)
		{
			var req = RequestFactory.New("GetSmartContractInit", address);
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}

		#endregion

		#region Transactions

		public async Task<MusResult> CreateTransaction(string payload)
		{
			var req = RequestFactory.New("CreateTransaction", payload);
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}
		public async Task<MusResult> CreateTransaction(object payload)
		{
			var arr = new object[1];
			arr[0] = payload;
			var req = RequestFactory.New("CreateTransaction", arr);
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}

		public async Task<MusResult> GetTransaction(string hash)
		{
			var req = RequestFactory.New("GetTransaction", hash);
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}
		public async Task<MusResult> GetPendingTxn(string hash)
		{
			var req = RequestFactory.New("GetPendingTxn");
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}
		public async Task<MusResult> GetPendingTxns()
		{
			var req = RequestFactory.New("GetPendingTxns");
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}
		public async Task<MusResult> GetRecentTransactions()
		{
			var req = RequestFactory.New("GetRecentTransactions", "");
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}
		public async Task<MusResult> GetTransactionsForTxBlock(string blockNum)
		{
			var req = RequestFactory.New("GetTransactionsForTxBlock", blockNum);
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}

		public async Task<MusResult> GetTxnBodiesForTxBlock(string blockNum)
		{
			var req = RequestFactory.New("GetTxnBodiesForTxBlock", blockNum);
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}

        public async Task<MusResult> GetTxnBodiesForTxBlockEx(string blockNum, string pageNum)
        {
            var req = RequestFactory.New("GetTxnBodiesForTxBlockEx", new object[] { blockNum, pageNum});
            var result = await CallMethod(req);
            return ResponseHandler.GetResult(ref result);
        }

		public async Task<MusResult> GetNumTxnsDSEpoch()
		{
			var req = RequestFactory.New("GetNumTxnsDSEpoch");
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}

		public async Task<MusResult> GetNumTxnsTxEpoch()
		{
			var req = RequestFactory.New("GetNumTxnsTxEpoch");
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}

		public async Task<MusResult> GetMinimumGasPrice()
		{
			var req = RequestFactory.New("GetMinimumGasPrice", "");
			var result = await CallMethod(req);
			return ResponseHandler.GetResult(ref result);
		}

		#endregion

        /// <summary>
		/// Calls a API method of the Zilliqa API
		/// </summary>
		private async Task<APIResponse> CallMethod(MusRequest req)
		{
            using (var client = new RestClient())
            {
                var request = new RestRequest(Url, Method.Post);

                request.AddBody(req.ToJson(), "application/json");
                request.RequestFormat = DataFormat.Json;

                var response = await client.ExecuteAsync(request);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApiCallException("Response was not OK");
                }

                if (response.Content == null)
                {
                    throw new ApiCallException("Response Content was null");
                }

                return JsonConvert.DeserializeObject<APIResponse>(response.Content);
			}
		}

	}
}
