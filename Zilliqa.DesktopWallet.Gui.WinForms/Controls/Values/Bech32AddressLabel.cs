using System.ComponentModel;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;
using Zilliqa.DesktopWallet.Gui.WinForms.Forms;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values
{
    public partial class Bech32AddressLabel : UserControl
    {
        private string? _bech32Address;
        private bool _showAddToWatchedAccounts = true;
        private SmartContract? _smartContract;

        public Bech32AddressLabel()
        {
            InitializeComponent();
        }

        [DefaultValue(true)]
        public bool ShowAddToWatchedAccounts
        {
            get => _showAddToWatchedAccounts;
            set
            {
                _showAddToWatchedAccounts = value;
                buttonMenuAdd.Visible = value;
            }
        }

        [DefaultValue(true)]
        public bool ShowCaption { get; set; } = true;

        [Browsable(false)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? Bech32Address
        {
            get => _bech32Address;
            set
            {
                _bech32Address = value;
                SetAddressLabel();
                ApplySize();
            }
        }

        private void SetAddressLabel()
        {
            if (_bech32Address?.Length == 42)
            {
                var knownAddress = KnownAddressService.Instance.GetName(_bech32Address);
                if (knownAddress != null && ShowCaption)
                {
                    label3.Text = "...";
                    labelCaption.Text = $"{knownAddress.Name.TokenNameShort()}:";
                    labelCaption.Visible = true;
                }
                else
                {
                    label3.Text = _bech32Address.Substring(7, 32);
                    labelCaption.Visible = false;
                }
                label2.Text = _bech32Address.Substring(4, 3);
                label4.Text = _bech32Address.Substring(39);
            }
            else
            {
                label2.Text = "---";
                label3.Text = "-----------------------------------";
                label4.Text = "---";
            }
        }

        private void ApplySize()
        {
            label2.Refresh();
            label3.Left = label2.Left + label2.Width - 2;
            label3.Refresh();
            label4.Left = label3.Left + label3.Width - 2;
            label4.Refresh();
            panelAddress.Width = label4.Left + label4.Width;
            Height = label1.Height;
        }

        private void RefreshButtons()
        {
            if (_bech32Address == null) return;
            if (Bech32Address == "zil1qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq9yf6pz")
            {
                buttonOpen.Visible = false;
                buttonCopy.Visible = false;
                buttonBrowse.Visible = false;
                buttonMenuAdd.Visible = false;
                buttonMenuContract.Visible = false;
                return;
            }
            if (_showAddToWatchedAccounts)
            {
                var walletRepository = RepositoryManager.Instance.WalletRepository;
                buttonMenuAdd.Visible =
                    walletRepository.MyAccounts.All(a => a.AddressBech32 != _bech32Address)
                    && walletRepository.WatchedAccounts.All(a => a.AddressBech32 != _bech32Address);
            }
            var masterPanel = DrillDownMasterPanelControl.FindParentDrillDownMasterPanel(this);
            if (masterPanel?.ContainsValueUniqueId(
                    ControlFactory.GetValueUniqueId(new AddressValue(_bech32Address))) == true)
            {
                buttonOpen.Visible = false;
            }

            Task.Run(() =>
            {
                _smartContract = RepositoryManager.Instance.DatabaseRepository.Database.GetTable<SmartContract>()
                    .FindRecord(nameof(SmartContract.ContractAddress), new Address(_bech32Address).GetBase16(false),
                        false);
                WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                {
                    buttonMenuContract.Visible = _smartContract != null;
                });
            });
        }

        private void Bech32AddressLabel_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                RefreshButtons();
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            var masterPanel = DrillDownMasterPanelControl.FindParentDrillDownMasterPanel(this);
            var controlIsInRightPanel = DrillDownMasterPanelControl.ControlIsInRightPanel(this);
            if (Bech32Address != null)
            {
                if (masterPanel != null)
                {
                    masterPanel.DisplayValue(new AddressValue(Bech32Address), !controlIsInRightPanel, _ => { }, this);
                }
                else
                {
                    SecondForm.ShowDetailsAsForm(ControlFactory.CreateDisplayControl(new AddressValue(Bech32Address)));
                }
            }
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            if (_bech32Address == null) return;
            buttonCopy.BackColor = Color.Green;
            buttonCopy.Refresh();
            timerButtonPressed.Enabled = true;
            Clipboard.SetText(_bech32Address);
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (_bech32Address == null) return;
            buttonBrowse.BackColor = Color.Green;
            buttonBrowse.Refresh();
            timerButtonPressed.Enabled = true;
            BlockExplorerBrowser.ShowAddress(_bech32Address);
        }

        private void timerButtonPressed_Tick(object sender, EventArgs e)
        {
            timerButtonPressed.Enabled = false;
            buttonCopy.BackColor = SystemColors.Control;
            buttonBrowse.BackColor = SystemColors.Control;
        }

        private void Bech32AddressLabel_Resize(object sender, EventArgs e)
        {
            ApplySize();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            contextMenuAdd.Show(buttonMenuAdd, 0, buttonMenuAdd.Height);
        }

        private void buttonMenuContract_Click(object sender, EventArgs e)
        {
            contextMenuContract.Show(buttonMenuContract, 0, buttonMenuContract.Height);
        }

        private void menuAddWatched_Click(object sender, EventArgs e)
        {
            var result = AddWatchedAccountForm.Execute(this.ParentForm!,
                _bech32Address,
                KnownAddressService.Instance.GetName(_bech32Address)?.Name);
            if (result != null)
            {
                RepositoryManager.Instance.WalletRepository.AddAccount(
                    WatchedAccount.Create(result.AccountName, result.Address, result.IsMyAccount)
                );
                menuAddWatched.Enabled = false;
            }
        }

        private void menuAddAddressbook_Click(object sender, EventArgs e)
        {
            AddressBookAddForm.Execute(this.ParentForm!,
                _bech32Address,
                KnownAddressService.Instance.GetName(_bech32Address)?.Name);
        }

        private void menuContractCall_Click(object sender, EventArgs e)
        {
            ContractCallTransactionForm.ExecuteShow(this.ParentForm!, 
                contractAddress: _bech32Address);
        }

        private void menuContractRedeploy_Click(object sender, EventArgs e)
        {
            if (_bech32Address != null)
            {
                ContractDeployTransactionForm.ExecuteShow(this.ParentForm!,
                    templateContract: new AddressValue(_bech32Address).SmartContract);
            }
        }

    }
}
