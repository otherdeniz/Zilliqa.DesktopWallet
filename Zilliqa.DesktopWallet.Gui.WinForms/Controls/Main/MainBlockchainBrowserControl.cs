using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.ApiClient.Enums;
using Zilliqa.DesktopWallet.ApiClient.Utils;
using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class MainBlockchainBrowserControl : UserControl
    {
        private SynchronizationContext? _currentContext;
        private BlockchainBrowserViewModel _viewModel;

        public MainBlockchainBrowserControl()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            if (_viewModel != null)
            {
                return;
            }
            _currentContext = SynchronizationContext.Current;
            _viewModel = new BlockchainBrowserViewModel();
            _viewModel.AfterRefresh += ViewModelOnAfterRefresh;

        }

        private void ViewModelOnAfterRefresh(object? sender, EventArgs e)
        {
            _currentContext?.Send(_ =>
            {
                propertyGridBlockchainInfo.SelectedObject = _viewModel.BlockchainInfo;
            }, null);
        }

        private void buttonQueryAddr_Click(object sender, EventArgs e)
        {
            var zilClient = new ZilliqaClient(false);

            textApiResult.Text = "(quering balance...)";
            this.Refresh();
            Application.DoEvents();

            string resultText = "";

            Task.Run(async () =>
            {
                var balance = await zilClient.GetBalance(textBoxQueryAddr.Text.FromBech32ToBase16Address(false));
                resultText = $"Balance = {balance.GetBalance(Unit.ZIL)}\r\n";

                var contractBalance = await zilClient.GetContractBalance(textBoxQueryAddr.Text.FromBech32ToBase16Address(false));
                resultText += $"Contract Balance = {contractBalance.GetBalance(Unit.ZIL)}\r\n";

            }).GetAwaiter().GetResult();

            textApiResult.Text = $"{resultText}";
        }
    }
}
