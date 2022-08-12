using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.ApiClient.Enums;
using Zilliqa.DesktopWallet.ApiClient.Utils;
using Zilliqa.DesktopWallet.Core.Repository;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class MainBlockchainBrowserControl : UserControl
    {
        private SynchronizationContext? _currentContext;
        private BlockchainBrowserRepository? _repository;

        public MainBlockchainBrowserControl()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            if (_repository != null)
            {
                return;
            }
            _currentContext = SynchronizationContext.Current;
            _repository = RepositoryManager.Instance.BlockchainBrowserRepository;
            _repository.AfterRefresh += RepositoryOnAfterRefresh;

        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            if (_repository != null)
            {
                _repository.AfterRefresh -= RepositoryOnAfterRefresh;
                _repository = null;
            }
            base.Dispose(disposing);
        }

        private void RepositoryOnAfterRefresh(object? sender, EventArgs e)
        {
            _currentContext?.Send(_ =>
            {
                propertyGridBlockchainInfo.SelectedObject = _repository?.BlockchainInfo;
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
                try
                {
                    var balance = await zilClient.GetBalance(textBoxQueryAddr.Text.FromBech32ToBase16Address(false));
                    resultText = $"Balance = {balance.GetBalance(Unit.ZIL)}\r\n";

                    var contractBalance = await zilClient.GetContractBalance(textBoxQueryAddr.Text.FromBech32ToBase16Address(false));
                    resultText += $"Contract Balance = {contractBalance.GetBalance(Unit.ZIL)}\r\n";
                }
                catch (Exception exception)
                {
                    resultText = exception.Message;
                }
            }).GetAwaiter().GetResult();

            textApiResult.Text = resultText;
        }
    }
}
