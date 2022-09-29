using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class MainBlockExplorerControl : DrillDownMasterPanelControl
    {
        private object? _searchValue;

        public MainBlockExplorerControl()
        {
            InitializeComponent();
        }

        private void Initialize()
        {

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

            base.Dispose(disposing);
        }

        //private void buttonQueryAddr_Click(object sender, EventArgs e)
        //{
        //    var zilClient = new ZilliqaClient();

        //    textApiResult.Text = "(quering balance...)";
        //    this.Refresh();
        //    Application.DoEvents();

        //    string resultText = "";

        //    Task.Run(async () =>
        //    {
        //        try
        //        {
        //            var balance = await zilClient.GetBalance(textBoxQueryAddr.Text.FromBech32ToBase16Address(false));
        //            resultText = $"Balance = {balance.GetBalance(Unit.ZIL)}\r\n";

        //            var contractBalance = await zilClient.GetContractBalance(textBoxQueryAddr.Text.FromBech32ToBase16Address(false));
        //            resultText += $"Contract Balance = {contractBalance.GetBalance(Unit.ZIL)}\r\n";
        //        }
        //        catch (Exception exception)
        //        {
        //            resultText = exception.Message;
        //        }
        //    }).GetAwaiter().GetResult();

        //    textApiResult.Text = resultText;
        //}

        private void MainBlockchainBrowserControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Initialize();
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            _searchValue = null;
            if (AddressValue.TryParse(textSearch.Text, out var addressValue))
            {
                _searchValue = addressValue;
            }
            else if (int.TryParse(textSearch.Text, out var blockNumber) 
                     && blockNumber > 0 
                     && blockNumber < RepositoryManager.Instance.BlockchainBrowserRepository.BlockchainInfo.NumberOfBlocks)
            {
                _searchValue = new BlockNumberValue(blockNumber);
            }
            else if (TransactionIdValue.TryParse(textSearch.Text, out var transactionId))
            {
                _searchValue = transactionId;
            }
            buttonSearch.Enabled = _searchValue != null;
            labelSearchItemTitle.Visible = _searchValue != null;
            if (_searchValue != null)
            {
                labelSearchItemTitle.Text = ValueSelectionHelper.GetValueTitle(_searchValue);
            }
        }

        private void textSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter
                && buttonSearch.Enabled)
            {
                buttonSearch_Click(sender, e);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var control in panelResult.Controls.OfType<Control>().ToArray())
                {
                    panelResult.Controls.Remove(control);
                    control.Dispose();
                }

                if (_searchValue != null)
                {
                    var resultControl = ValueSelectionHelper.CreateDisplayControl(_searchValue);
                    if (resultControl != null)
                    {
                        resultControl.Dock = DockStyle.Fill;
                        panelResult.Controls.Add(resultControl);
                    }
                    if (resultControl is DetailsBaseControl drillDownBaseControl)
                    {
                        drillDownBaseControl.DrillDownPanel = this;
                    }
                    Application.DoEvents();
                    panelResult.Focus();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
