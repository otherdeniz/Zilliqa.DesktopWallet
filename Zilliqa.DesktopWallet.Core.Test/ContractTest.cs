using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Services;

namespace Zilliqa.DesktopWallet.Core.Test;

[TestClass]
public class ContractTest
{
    [TestMethod]
    public void Staking_GetSsnList()
    {
        ZilliqaClient.UseTestnet = false;
        var ssnList = StakingService.Instance.GetSeedNodeList();
    }

}