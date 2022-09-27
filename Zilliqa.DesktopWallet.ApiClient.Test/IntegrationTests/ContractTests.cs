using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Zilliqa.DesktopWallet.ApiClient.Contracts;
using Zilliqa.DesktopWallet.ApiClient.Utils;

namespace Zilliqa.DesktopWallet.ApiClient.Test.IntegrationTests
{
    public class ContractTests : MusTest
    {
        private SmartContract _contract;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _address = new Address("0x96b324cbdacbf7087f1fb1cdbbe6601a6e8c04c5");
            _contract = new SmartContract(_address);
        }
        
        [Test]
        public async Task GetBalance()
        {
            var res = await _zil.GetContractBalance(_address);
            Assert.AreNotEqual(-1, res.GetBalance());
        }

        [Test]
        public async Task GetCodeNotEmpty()
        {
            var res = await _zil.GetSmartContractCode(_address);
            Assert.AreNotEqual("", res);
        }

        [Test]
        public async Task GetInitNotEmpty()
        {
            var res = await _zil.GetSmartContractInit(_address.RawAddress);
            Assert.AreNotEqual(null, res);
        }

        [Test]
        public async Task GetStateNotEmpty()
        {
            var res = await _zil.GetSmartContractState("zil1504065pp76uuxm7s9m2c4gwszhez8pu3mp6r8c");
            Assert.AreNotEqual(null, res);
        }

        [Test]
        public async Task GetStateGivesAllValues()
        {
            var res = await _zil.GetSmartContractState(_address.RawAddress);
            var valuesJson = ((JToken)res.AllValues).ToString();
            Assert.AreNotEqual("", valuesJson);
        }

        [Test]
        public async Task GetSubSateNotEmpty()
        {
            object[] parameters = new object[] { _address.RawAddress,"admins",new object[0] };
            var res = await _zil.GetSmartContractSubState(parameters);
            Assert.AreNotEqual("", res);
        }

        [Test]
        public async Task GetContractsNotEmpty()
        {
            var res = await _zil.GetSmartContracts(_account);
            Assert.IsTrue(res.Any());
        }

        [Test]
        public async Task GetContractAddressFromTransactionIDNotEmpty()
        {
            
            var res = await _client.GetContractAddressFromTransactionID(_address.RawAddress);
            Assert.AreNotEqual("", res.Result);
        }

        [Test]
        public async Task GetStateFromContract()
        {
            var res = await _zil.GetSmartContracts(_account);
            var res0 = res[0];

            Assert.AreNotEqual(null, res0.State);
        }

        [Test]
        public async Task GetAddressGetSmartContractState()
        {
            var zilClient = new ZilliqaClient(false); // mainnet
            var address = "zil1xxxx".FromBech32ToBase16Address(false);
            var res = await zilClient.GetSmartContractState(address);
            var zilBalance = res.Balance.GetBalance();
            Assert.IsTrue(zilBalance > 0);
        }

    }
}
