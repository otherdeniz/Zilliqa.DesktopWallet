using System.Diagnostics;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet;
using Zilliqa.DesktopWallet.Gui.WinForms.Forms;

namespace Zilliqa.DesktopWallet.Gui.WinForms
{
    public partial class MainForm : Form, ISingleInstanceForm
    {
        public static MainForm? Instance { get; private set; }

        private Control? _mainTransientControl;
        private ShutdownDialogForm? _shutdownDialogForm;

        public MainForm()
        {
            InitializeComponent();
            Instance = this;
        }

        /// <summary>
        /// SingleInstanceForm Message Event
        /// </summary>
        public event WndProcDelegate? WindowProcessMessage;

        /// <summary>
        /// SingleInstanceForm arguments Handling
        /// </summary>
        public void HandleCommand(string[] arguments)
        {
            // nothing to do yet
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
                var wallet = WalletDat.CreateNew(createWalletResult.Password);
                if (createWalletResult.AddWalletType == AddAccountControl.AddWalletType.AddNew)
                {
                    wallet.MyAccounts.Add(MyAccount.Create(createWalletResult.AccountName, createWalletResult.Password.Password));
                }
                else if (createWalletResult.AddWalletType == AddAccountControl.AddWalletType.ImportPrivateKey)
                {
                    wallet.MyAccounts.Add(MyAccount.Import(createWalletResult.AccountName, createWalletResult.PrivateKey!, createWalletResult.Password.Password));
                }

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
                return;
            }
            panelBottom.Visible = true;
            bottomStatus.StartRefresh();
            bottomZilPrice.StartRefresh();
            if (LoadWallet())
            {
                buttonWallet_Click(this, EventArgs.Empty);
                NotificationService.Instance.RegisterEventNotificators();
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
            if (ZilliqaClient.UseTestnet)
            {
                Icon = ImageResources.Zilliqa_icon_testnet;
                panelMain.BackgroundImage = ImageResources.Zilliqa_icon_512_testnet;
            }
            InitDisplayedCurrencies();
            LoadSettingIncomingSound();
            LoadSettingWhales();
            var screen = Screen.FromControl(this);
            var formWidth = Convert.ToInt32(Convert.ToDecimal(screen.Bounds.Width) * 0.85m);
            if (formWidth > 2000)
            {
                formWidth = 2000;
            }
            var formHeight = Convert.ToInt32(Convert.ToDecimal(screen.Bounds.Height) * 0.85m);
            if (formHeight > 1000)
            {
                formHeight = 1000;
            }
            Top = Convert.ToInt32(Convert.ToDecimal(screen.Bounds.Height - formHeight) / 2m);
            var left = Convert.ToInt32(Convert.ToDecimal(screen.Bounds.Width - formWidth) / 2m);
            Left = left < 250 ? left : 250;
            Height = formHeight;
            Width = formWidth;
        }

        private void buttonWallet_Click(object sender, EventArgs e)
        {
            mainWalletControl.Initialize();
            ShowMainControl(() => mainWalletControl, buttonWallet);
        }

        private void buttonBlockchain_Click(object sender, EventArgs e)
        {
            ShowMainControl(() => new MainBlockExplorerControl(), buttonBlockchain, true);
        }

        private void buttonSmartContracts_Click(object sender, EventArgs e)
        {
            ShowMainControl(() => new MainContractsControl(), buttonSmartContracts, true);
        }

        private void buttonTokens_Click(object sender, EventArgs e)
        {
            ShowMainControl(() => new MainTokensControl(), buttonTokens, true);
        }

        private void buttonEcosystem_Click(object sender, EventArgs e)
        {
            ShowMainControl(() => new MainEcosystemControl(), buttonEcosystem, true);
        }

        private void buttonStakingNodes_Click(object sender, EventArgs e)
        {
            ShowMainControl(() => new MainStakingNodesControl(), buttonStakingNodes, true);
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
            buttonSmartContracts.Checked = false;
            buttonEcosystem.Checked = false;
            buttonStakingNodes.Checked = false;
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
            }

            // focus-handle fix (windows removes the focus of the form if focus is on invisible handle)
            this.Focus();

            _mainTransientControl = null;
            Application.DoEvents();
            GC.Collect();

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
                bottomStatus.StopRefresh();

                // shutdown dialog does all the rest
                _shutdownDialogForm = new ShutdownDialogForm();
                _shutdownDialogForm.ShowDialog(this);
                _shutdownDialogForm.Dispose();
            }
        }

        private void InitDisplayedCurrencies()
        {
            var currentDisplay = SettingsService.Instance.CurrentDisplayedCurrencies;
            menuDisplayCurrencyEur.Checked = currentDisplay.DisplayEur;
            menuDisplayCurrencyChf.Checked = currentDisplay.DisplayChf;
            menuDisplayCurrencyGbp.Checked = currentDisplay.DisplayGbp;
            menuDisplayCurrencyBtc.Checked = currentDisplay.DisplayBtc;
            menuDisplayCurrencyEth.Checked = currentDisplay.DisplayEth;
            menuDisplayCurrencyLtc.Checked = currentDisplay.DisplayLtc;
        }

        private void LoadSettingIncomingSound()
        {
            var currentSound = SettingsFile.Instance.IncomingSound;
            menuIncomingSoundNone.Checked = currentSound == "";
            menuIncomingSoundMoneyCounter.Checked = currentSound == SettingsFile.IncomingSounds.MoneyCounter;
            menuIncomingSoundKaChing.Checked = currentSound == SettingsFile.IncomingSounds.KaChing;
            menuIncomingSoundCoinDrop.Checked = currentSound == SettingsFile.IncomingSounds.CoinDrop;
        }

        private void LoadSettingWhales()
        {
            var currentWhaleNotification = SettingsFile.Instance.WhaleNotificationUsd;
            settingMenuWhaleNone.Checked = currentWhaleNotification == 0;
            settingMenuWhale10K.Checked = currentWhaleNotification == 10000;
            settingMenuWhale50K.Checked = currentWhaleNotification == 50000;
            settingMenuWhale100K.Checked = currentWhaleNotification == 100000;
            settingMenuWhale500K.Checked = currentWhaleNotification == 500000;
        }

        private void menuDisplayCurrencyEur_Click(object sender, EventArgs e)
        {
            var display = !menuDisplayCurrencyEur.Checked;
            menuDisplayCurrencyEur.Checked = display;
            menuDisplayCurrencyChf.Checked = false;
            menuDisplayCurrencyGbp.Checked = false;
            SettingsService.Instance.ChangeDisplayedCurrencies(d =>
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
            SettingsService.Instance.ChangeDisplayedCurrencies(d =>
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
            SettingsService.Instance.ChangeDisplayedCurrencies(d =>
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
            SettingsService.Instance.ChangeDisplayedCurrencies(d =>
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
            SettingsService.Instance.ChangeDisplayedCurrencies(d =>
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
            SettingsService.Instance.ChangeDisplayedCurrencies(d =>
            {
                d.DisplayLtc = display;
                d.DisplayBtc = false;
                d.DisplayEth = false;
            });
        }

        private void buttonToolsOpenWalletFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", DataPathBuilder.UserDataRoot.FullPath);
        }

        private void buttonToolsOpenDbFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", DataPathBuilder.AppDataRoot.FullPath);
        }

        private void buttonToolsAddressConverter_Click(object sender, EventArgs e)
        {
            var form = new AddressConverterToolForm();
            form.Show(this);
        }

        private void menuIncomingSoundNone_Click(object sender, EventArgs e)
        {
            SettingsFile.Instance.IncomingSound = "";
            SettingsFile.Instance.Save();
            LoadSettingIncomingSound();
        }

        private void menuIncomingSoundMoneyCounter_Click(object sender, EventArgs e)
        {
            SettingsFile.Instance.IncomingSound = SettingsFile.IncomingSounds.MoneyCounter;
            SettingsFile.Instance.Save();
            SoundPlayer.PlaySound(SettingsFile.Instance.IncomingSound);
            LoadSettingIncomingSound();

        }

        private void menuIncomingSoundKaChing_Click(object sender, EventArgs e)
        {
            SettingsFile.Instance.IncomingSound = SettingsFile.IncomingSounds.KaChing;
            SettingsFile.Instance.Save();
            SoundPlayer.PlaySound(SettingsFile.Instance.IncomingSound);
            LoadSettingIncomingSound();
        }

        private void menuIncomingSoundCoinDrop_Click(object sender, EventArgs e)
        {
            SettingsFile.Instance.IncomingSound = SettingsFile.IncomingSounds.CoinDrop;
            SettingsFile.Instance.Save();
            SoundPlayer.PlaySound(SettingsFile.Instance.IncomingSound);
            LoadSettingIncomingSound();
        }

        private void buttonToolsSearchWindow_Click(object sender, EventArgs e)
        {
            var form = new SearchForm();
            form.Show(this);
        }

        private void settingMenuWhaleNone_Click(object sender, EventArgs e)
        {
            SettingsFile.Instance.WhaleNotificationUsd = 0;
            SettingsFile.Instance.Save();
            LoadSettingWhales();
        }

        private void settingMenuWhale10K_Click(object sender, EventArgs e)
        {
            SettingsFile.Instance.WhaleNotificationUsd = 10000;
            SettingsFile.Instance.Save();
            LoadSettingWhales();
        }

        private void settingMenuWhale50K_Click(object sender, EventArgs e)
        {
            SettingsFile.Instance.WhaleNotificationUsd = 50000;
            SettingsFile.Instance.Save();
            LoadSettingWhales();
        }

        private void settingMenuWhale100K_Click(object sender, EventArgs e)
        {
            SettingsFile.Instance.WhaleNotificationUsd = 100000;
            SettingsFile.Instance.Save();
            LoadSettingWhales();
        }

        private void settingMenuWhale500K_Click(object sender, EventArgs e)
        {
            SettingsFile.Instance.WhaleNotificationUsd = 500000;
            SettingsFile.Instance.Save();
            LoadSettingWhales();
        }
    }
}