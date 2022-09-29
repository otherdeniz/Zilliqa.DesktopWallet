using System.Diagnostics;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class MainTokensControl : UserControl
    {
        public MainTokensControl()
        {
            InitializeComponent();
        }

        private void MainTokensControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                timerStartLoading.Enabled = true;
            }
        }

        private void timerStartLoading_Tick(object sender, EventArgs e)
        {
            timerStartLoading.Enabled = false;
            var dataSource = TokenDataService.Instance.GetTokensDataSource();
            gridViewTokens.LoadData(dataSource);
            groupBoxTokensList.Text = $"ZRC-2 Tokens ({dataSource.RecordCount:#,##0})";
            panelLoading.Visible = false;
            panelLoaded.Visible = true;
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sender is LinkLabel linkLabel
                && linkLabel.Text.StartsWith("http"))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = linkLabel.Text,
                    UseShellExecute = true
                });
            }
        }

        private void gridViewTokens_SelectionChanged(object sender, GridView.GridViewControl.SelectedItemEventArgs e)
        {
            if (e.SelectedItem?.Value is TokenRowViewModel token)
            {
                groupBoxTokenDetails.Visible = true;
                groupBoxMarketData.Visible = true;
                pictureBoxIcon.Image = token.Model.Icon.Icon48;
                labelName.Text = token.Model.Name;
                labelSymbol.Text = token.Model.Symbol;
                //labelContractAddress.Text = token.Model.ContractAddressesBech32;
                //labelInitSupply.Text = token.Model.MarketData.InitSupply.ToString("#,##0");
                //labelMaxSupply.Text = token.Model.MarketData.MaxSupply.ToString("#,##0");
                //linkLabelWebsite.Text = token.Model.WebsiteUrl;
                //linkLabelTelegram.Text = token.Model.TelegramUrl;
                //linkLabelWhitepaper.Text = token.Model.WhitepaperUrl;
                //propertyGridMarketData.SelectedObject = token.Model.MarketData;
            }
        }
    }
}
