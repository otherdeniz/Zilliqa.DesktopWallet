using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details
{
    public partial class TokenDetailsControl : DetailsBaseControl
    {
        public TokenDetailsControl()
        {
            InitializeComponent();
        }

        public void LoadToken(string symbol)
        {
            var tokenModel = TokenDataService.Instance.GetToken(symbol);
            if (tokenModel != null)
            {
                groupBoxTokenDetails.Visible = true;
                pictureBoxIcon.Image = tokenModel.GetTokenIcon().Icon48;
                labelName.Text = tokenModel.Name;
                labelSymbol.Text = tokenModel.Symbol;
                labelContractAddress.Text = tokenModel.AddressBech32;
                labelInitSupply.Text = tokenModel.MarketData.InitSupply.ToString("#,##0");
                labelMaxSupply.Text = tokenModel.MarketData.MaxSupply.ToString("#,##0");
                linkLabelWebsite.Text = tokenModel.WebsiteUrl;
                linkLabelTelegram.Text = tokenModel.TelegramUrl;
                linkLabelWhitepaper.Text = tokenModel.WhitepaperUrl;
            }

        }
    }
}
