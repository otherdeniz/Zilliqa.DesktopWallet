using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;

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
            // nothing to do yet
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

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
                labelSearchItemTitle.Text = ControlFactory.GetValueTitle(_searchValue);
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
                    var resultControl = ControlFactory.CreateDisplayControl(_searchValue);
                    if (resultControl != null)
                    {
                        resultControl.Dock = DockStyle.Fill;
                        resultControl.Height = panelResult.Height;
                        panelResult.Controls.Add(resultControl);
                    }
                    if (resultControl is DetailsBaseControl drillDownBaseControl)
                    {
                        drillDownBaseControl.MasterPanel = this;
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
