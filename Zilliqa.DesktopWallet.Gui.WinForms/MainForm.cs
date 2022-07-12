namespace Zilliqa.DesktopWallet.Gui.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowMainControl(mainBlockchainBrowserControl, buttonBlockchain);
        }

        private void buttonWallet_Click(object sender, EventArgs e)
        {
            ShowMainControl(mainWalletControl, buttonWallet);

        }

        private void buttonBlockchain_Click(object sender, EventArgs e)
        {
            ShowMainControl(mainBlockchainBrowserControl, buttonBlockchain);
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowMainControl(Control showControl, ToolStripButton button)
        {
            buttonBlockchain.Checked = false;
            buttonWallet.Checked = false;
            button.Checked = true;

            foreach (Control panelMainControl in panelMain.Controls)
            {
                panelMainControl.Visible = false;
            }

            showControl.Dock = DockStyle.Fill;
            showControl.Visible = true;
        }
    }
}