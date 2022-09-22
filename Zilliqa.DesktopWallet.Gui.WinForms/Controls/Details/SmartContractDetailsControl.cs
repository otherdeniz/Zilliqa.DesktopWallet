using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details
{
    public partial class SmartContractDetailsControl : DrillDownBaseControl
    {
        public SmartContractDetailsControl()
        {
            InitializeComponent();
            textConstructorArguments.Dock = DockStyle.Fill;
            textScillaCode.Dock = DockStyle.Fill;
        }

        public void LoadSmartContract(SmartContractRowViewModel viewModel)
        {
            textScillaCode.Text = viewModel.SmartContractModel.DeploymentTransaction.Value?.Code;
        }

        private void TabButtonClick(ToolStripButton button, Control tabPageControl)
        {
            foreach (var item in toolStripPages.Items)
            {
                if (item is ToolStripButton itemButton)
                {
                    itemButton.Checked = false;
                    itemButton.Font = new Font(itemButton.Font, FontStyle.Regular);
                }
            }
            button.Checked = true;
            button.Font = new Font(button.Font, FontStyle.Bold);

            foreach (Control pageControl in panelTabPagesTransactions.Controls)
            {
                pageControl.Visible = false;
            }
            tabPageControl.Visible = true;
        }

        private void SmartContractDetailsControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                TabButtonClick(tabButtonArguments, textConstructorArguments);
            }
        }

        private void tabButtonArguments_Click(object sender, EventArgs e)
        {
            TabButtonClick(tabButtonArguments, textConstructorArguments);
        }

        private void tabButtonCode_Click(object sender, EventArgs e)
        {
            TabButtonClick(tabButtonCode, textScillaCode);
        }

        private void tabButtonTransaction_Click(object sender, EventArgs e)
        {

        }
    }
}
