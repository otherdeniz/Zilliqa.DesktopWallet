using NUnit.Framework;
using Zilliqa.DesktopWallet.ApiClient.Contracts;

namespace Zilliqa.DesktopWallet.ApiClient.Test.Contracts
{
    public class ContractTests
    {
        public SmartContract TestContract { get; set; }
        [SetUp]
        public void Setup()
        {
            //make an account ?? use a factory maybe
            TestContract = new SmartContract();
        }

        [Test]
        public void TestContractNoAddress()
        {

            Assert.AreEqual("", TestContract.Address.Raw);
        }
        [Test]
        public void NewContractCodeEmpty()
        {
            Assert.AreEqual("", TestContract.Code);
        }
    }
}
