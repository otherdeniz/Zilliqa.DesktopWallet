using System.Linq;
using NUnit.Framework;
using Org.BouncyCastle.Asn1.X509;
using System.Threading.Tasks;
using Octokit;
using Zilliqa.DesktopWallet.ApiClient.ViewblockApi;

namespace Zilliqa.DesktopWallet.ApiClient.Test.IntegrationTests
{
    public class ViewblockTest
    {
        [Test]
        public void GetAsset_Success()
        {
            var tokenBech32 = "zil10dmr7sesrv2vxarqckq56ls0xktkjdkwrhz7wd";
            var assetResult = new ViewblockCryptometaClient().GetAsset(tokenBech32);
            Assert.IsTrue(assetResult.Found);
            Assert.IsNotNull(assetResult.Asset);
            Assert.IsNotNull(assetResult.Image);
        }

        [Test]
        public async Task GetsDirectoryContent()
        {
            var github = new GitHubClient(new ProductHeaderValue("Zillifriends.ZilliqaDesktopWallet"));

            var contents = await github
                .Repository
                .Content
                .GetAllContents("ViewBlock", "cryptometa", "data/zilliqa/ecosystem");

            Assert.IsTrue(contents.Count > 2);
            //Assert.AreEqual(ContentType.Dir, contents.First().Type);
        }
    }
}
