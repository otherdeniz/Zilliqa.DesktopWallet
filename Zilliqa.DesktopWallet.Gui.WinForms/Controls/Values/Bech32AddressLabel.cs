using System.ComponentModel;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;
using Zilliqa.DesktopWallet.Gui.WinForms.Forms;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values
{
    public partial class Bech32AddressLabel : UserControl
    {
        private string? _bech32Address;
        private bool _showAddToWatchedAccounts = true;

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
                buttonAddWatchedAccount.Visible = value;
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
                var caption = KnownAddressService.Instance.GetName(_bech32Address);
                if (caption != null && ShowCaption)
                {
                    label3.Text = "...";
                    labelCaption.Text = $"{caption.TokenNameShort()}:";
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
            if (_showAddToWatchedAccounts)
            {
                var walletRepository = RepositoryManager.Instance.WalletRepository;
                buttonAddWatchedAccount.Enabled =
                    walletRepository.MyAccounts.All(a => a.AddressBech32 != _bech32Address)
                    && walletRepository.WatchedAccounts.All(a => a.AddressBech32 != _bech32Address);
            }
            var masterPanel = DrillDownMasterPanelControl.FindParentDrillDownMasterPanel(this);
            if (masterPanel?.ContainsValueUniqueId(
                    ValueSelectionHelper.GetValueUniqueId(new AddressValue(_bech32Address))) == true)
            {
                buttonOpen.Enabled = false;
            }
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
                    SecondForm.ShowDetailsAsForm(ValueSelectionHelper.CreateDisplayControl(new AddressValue(Bech32Address)));
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

        private void buttonAddWatchedAccount_Click(object sender, EventArgs e)
        {
            var result = AddWatchedAccountForm.Execute(this.ParentForm!, 
                _bech32Address,
                KnownAddressService.Instance.GetName(_bech32Address));

            if (result != null)
            {
                RepositoryManager.Instance.WalletRepository.AddAccount(
                    WatchedAccount.Create(result.AccountName, result.Address, result.IsMyAccount)
                );
                buttonAddWatchedAccount.Enabled = false;
            }
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

    }
}
