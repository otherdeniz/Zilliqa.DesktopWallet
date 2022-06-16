using NUnit.Framework;
using Zilliqa.DesktopWallet.ApiClient.Accounts;

namespace Zilliqa.DesktopWallet.ApiClient.Test.Accounts
{
    public class RepositoryTests
    {
        private Account _testAccount;
        private AccountsRepository _repo;
        [SetUp]
        public void Setup()
        {
            _repo = new AccountsRepository();
        }

    }
}
