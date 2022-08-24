using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main;
using Zilliqa.DesktopWallet.Gui.WinForms.Forms;

namespace Zilliqa.DesktopWallet.Gui.WinForms
{
    public partial class MainForm : Form
    {
        private Control? _mainTransientControl;
        private ShutdownDialogForm? _shutdownDialogForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private bool LoadWallet()
        {
            if (!WalletDat.Exists)
            {
                var createWalletResult = CreatePasswordForm.Execute(this);
                if (createWalletResult == null)
                {
                    return false;
                }
                var wallet = WalletDat.CreateNew(createWalletResult.Password, createWalletResult.AccountName);
                wallet.Save();
            }
            else
            {
                var wallet = WalletDat.Load();
                var walletPassword = EnterPasswordForm.Execute(this);
                if (walletPassword == null)
                {
                    return false;
                }

                wallet.InitialiseLoad(walletPassword);
            }

            return true;
        }

        private void StartupGui()
        {
            if (LoadWallet())
            {
                buttonWallet_Click(this, EventArgs.Empty);
            }
            else
            {
                Close();
            }
        }

        private void timerInit_Tick(object sender, EventArgs e)
        {
            timerInit.Enabled = false;
            StartupGui();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            WinFormsSynchronisationContext.WinFormsMainContext = SynchronizationContext.Current;
            this.Text = ApplicationInfo.MainFormTitle;
        }

        private void buttonWallet_Click(object sender, EventArgs e)
        {
            mainWalletControl.Initialize();
            ShowMainControl(() => mainWalletControl, buttonWallet);

        }

        private void buttonBlockchain_Click(object sender, EventArgs e)
        {
            ShowMainControl(() => mainBlockchainBrowserControl, buttonBlockchain);
        }

        private void buttonTokens_Click(object sender, EventArgs e)
        {
            ShowMainControl(() => new MainTokensControl(), buttonTokens, true);
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SettingsForm.Execute(this);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ShowMainControl(Func<Control> getMainControl, ToolStripButton button, bool isTransient = false)
        {
            if (button.Checked)
            {
                return;
            }
            // toggle selected button
            buttonBlockchain.Checked = false;
            buttonWallet.Checked = false;
            buttonTokens.Checked = false;
            button.Checked = true;

            // hide everything
            foreach (Control panelMainControl in panelMain.Controls)
            {
                panelMainControl.Visible = false;
            }

            // remove transient control
            if (_mainTransientControl != null)
            {
                panelMain.Controls.Remove(_mainTransientControl);
                _mainTransientControl.Dispose();
                _mainTransientControl = null;
            }

            // focus-handle fix (windows removes the focus of the form if focus is on invisible handle)
            this.Focus();

            // display new control
            var showControl = getMainControl();
            showControl.Dock = DockStyle.Fill;
            if (isTransient)
            {
                _mainTransientControl = showControl;
                panelMain.Controls.Add(showControl);
            }
            showControl.Visible = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_shutdownDialogForm == null)
            {
                this.Enabled = false;

                // stop all refresh Timers
                bottomStatusControl1.StopRefresh();

                // shutdown dialog does all the rest
                _shutdownDialogForm = new ShutdownDialogForm();
                _shutdownDialogForm.ShowDialog(this);
                _shutdownDialogForm.Dispose();
            }
        }
    }
}