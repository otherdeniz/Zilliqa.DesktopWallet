using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Services;
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
            if (!StartupDialogForm.Execute(this))
            {
                Close();
            }
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
            InitDisplayedCurrencies();
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

        private void InitDisplayedCurrencies()
        {
            var currentDisplay = DisplayCurrenciesService.Instance.CurrentDisplayed;
            menuDisplayCurrencyEur.Checked = currentDisplay.DisplayEur;
            menuDisplayCurrencyChf.Checked = currentDisplay.DisplayChf;
            menuDisplayCurrencyGbp.Checked = currentDisplay.DisplayGbp;
            menuDisplayCurrencyBtc.Checked = currentDisplay.DisplayBtc;
            menuDisplayCurrencyEth.Checked = currentDisplay.DisplayEth;
            menuDisplayCurrencyLtc.Checked = currentDisplay.DisplayLtc;
        }

        private void menuDisplayCurrencyEur_Click(object sender, EventArgs e)
        {
            var display = !menuDisplayCurrencyEur.Checked;
            menuDisplayCurrencyEur.Checked = display;
            menuDisplayCurrencyChf.Checked = false;
            menuDisplayCurrencyGbp.Checked = false;
            DisplayCurrenciesService.Instance.ChangeDisplayedCurrencies(d =>
            {
                d.DisplayEur = display;
                d.DisplayChf = false;
                d.DisplayGbp = false;
            });
        }

        private void menuDisplayCurrencyChf_Click(object sender, EventArgs e)
        {
            var display = !menuDisplayCurrencyChf.Checked;
            menuDisplayCurrencyChf.Checked = display;
            menuDisplayCurrencyEur.Checked = false;
            menuDisplayCurrencyGbp.Checked = false;
            DisplayCurrenciesService.Instance.ChangeDisplayedCurrencies(d =>
            {
                d.DisplayChf = display;
                d.DisplayEur = false;
                d.DisplayGbp = false;
            });
        }

        private void menuDisplayCurrencyGbp_Click(object sender, EventArgs e)
        {
            var display = !menuDisplayCurrencyGbp.Checked;
            menuDisplayCurrencyGbp.Checked = display;
            menuDisplayCurrencyChf.Checked = false;
            menuDisplayCurrencyEur.Checked = false;
            DisplayCurrenciesService.Instance.ChangeDisplayedCurrencies(d =>
            {
                d.DisplayGbp = display;
                d.DisplayChf = false;
                d.DisplayEur = false;
            });
        }

        private void menuDisplayCurrencyBtc_Click(object sender, EventArgs e)
        {
            var display = !menuDisplayCurrencyBtc.Checked;
            menuDisplayCurrencyBtc.Checked = display;
            menuDisplayCurrencyEth.Checked = false;
            menuDisplayCurrencyLtc.Checked = false;
            DisplayCurrenciesService.Instance.ChangeDisplayedCurrencies(d =>
            {
                d.DisplayBtc = display;
                d.DisplayEth = false;
                d.DisplayLtc = false;
            });
        }

        private void menuDisplayCurrencyEth_Click(object sender, EventArgs e)
        {
            var display = !menuDisplayCurrencyEth.Checked;
            menuDisplayCurrencyEth.Checked = display;
            menuDisplayCurrencyBtc.Checked = false;
            menuDisplayCurrencyLtc.Checked = false;
            DisplayCurrenciesService.Instance.ChangeDisplayedCurrencies(d =>
            {
                d.DisplayEth = display;
                d.DisplayBtc = false;
                d.DisplayLtc = false;
            });
        }

        private void menuDisplayCurrencyLtc_Click(object sender, EventArgs e)
        {
            var display = !menuDisplayCurrencyLtc.Checked;
            menuDisplayCurrencyLtc.Checked = display;
            menuDisplayCurrencyBtc.Checked = false;
            menuDisplayCurrencyEth.Checked = false;
            DisplayCurrenciesService.Instance.ChangeDisplayedCurrencies(d =>
            {
                d.DisplayLtc = display;
                d.DisplayBtc = false;
                d.DisplayEth = false;
            });
        }
    }
}