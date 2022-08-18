using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Zilliqa.DesktopWallet.ApiClient.Test.IntegrationTests
{
    public class BlockchainTests:MusTest
    {
        [Test]
        public async Task NetworkIdCorrectNumber()
        {
            var res = await _zil.GetNetworkId();
            Console.WriteLine($"Network Id: {res}");
            Assert.AreEqual(1, res);
        }

        [Test]
        public async Task GetBlockchainInfoHasTransactions()
        {
            var res = await _zil.GetBlockchainInfo();
            Assert.AreNotEqual(0, long.Parse(res.NumTransactions));
        }
        
        [Test]
        public async Task GetDsBlockNotNull()
        {
            var res = await _zil.GetDsBlock(1);
            Assert.AreNotEqual(null, res);
        }
        [Test]
        public async Task GetLatestDsBlockNotNull()
        {
            var res = await _zil.GetLatestDsBlock();
            Assert.AreNotEqual(null, res);
        }
        [Test]
        public async Task GetNumDSBlocksNotZero()
        {
            var res = await _zil.GetNumDSBlocks();
            Console.WriteLine($"Number of blocks: {res}");
            Assert.AreNotEqual(0, res);
        }
        [Test]
        public async Task GetDSBlockRateNotZero()
        {
            var res = await _zil.GetDSBlockRate();
            Assert.AreNotEqual(0, res);
        }
        [Test]
        public async Task DSBlockListingNotEmpty()
        {
            var res = await _zil.GetDSBlockListing(1);
            Assert.IsTrue(res.Data.Any());
        }

        [Test]
        public async Task GetTxBlockCorrectBlockNumber()
        {
            var blockNumber = 40;
            var res = await _zil.GetTxBlock(blockNumber);
            Assert.AreEqual(blockNumber.ToString(), res.BlockNum);
        }

        [Test]
        public async Task GetLatestTxBlockNotNull()
        {
            var res = await _zil.GetLatestTxBlock(); 
            Assert.AreNotEqual(null, res);
        }
        [Test]
        public async Task GetNumTxBlocksNotZero()
        {
            var res = await _zil.GetNumTxBlocks();
            Assert.AreNotEqual(0, res);
        }
        [Test]
        public async Task GetTxBlockRate()
        {
            var res = await _zil.GetTxBlockRate();
            Assert.AreNotEqual(0, res);
        }
        [Test]
        public async Task TxBlockListingNotEmpty()
        {
            var res = await _zil.GetTxBlockListing(1);
            Assert.IsTrue(res.Data.Any());
        }
        [Test]
        public async Task GetNumTransactionsNotZero()
        {
            var res = await _zil.GetNumTransactions();
            Assert.AreNotEqual(0, res);
        }
        [Test]
        public async Task GetTransactionRateNotZero()
        {
            var res = await _zil.GetTransactionRate();
            Assert.AreNotEqual(0, res);
        }
        [Test]
        public async Task GetCurrentMiniEpochNotZero()
        {
            var res = await _zil.GetCurrentMiniEpoch();
            Assert.AreNotEqual(0, res);
        }
        [Test]
        public async Task GetCurrentDSEpochNotZero()
        {
            var res = await _zil.GetCurrentDSEpoch();
            Assert.AreNotEqual(0, res);
        }
        [Test]
        public async Task GetPrevDifficultyNotZero()
        {
            var res = await _zil.GetPrevDifficulty();
            Assert.AreNotEqual(0, res);
        }
        [Test]
        public async Task GetPrevDSDifficultyNotZero()
        {
            var res = await _zil.GetPrevDSDifficulty();
            Assert.AreNotEqual(0, res);
        }
        [Test]
        public async Task GetTotalCoinSupplyNotZero()
        {
            var res = await _zil.GetTotalCoinSupply();
            Assert.AreNotEqual(0, res);

        }
    }
}
