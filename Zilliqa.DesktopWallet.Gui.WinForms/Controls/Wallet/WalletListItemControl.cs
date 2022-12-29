using System.ComponentModel;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet
{
    public partial class WalletListItemControl : HighlitableBaseControl
    {
        private AccountViewModel? _accountViewModel;

        public WalletListItemControl()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs>? ButtonClicked;
        public event EventHandler<EventArgs>? EditClicked;
        public event EventHandler<EventArgs>? MoveUpClicked;
        public event EventHandler<EventArgs>? MoveDownClicked;

        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool CanMoveUp { get; set; }

        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool CanMoveDown { get; set; }

        public AccountViewModel Account => _accountViewModel!;

        public void AssignAccount(AccountViewModel account)
        {
            _accountViewModel = account;
            if (_accountViewModel.AccountData is MyAccount myAccountData)
            {
                if (myAccountData.Type == MyAccountType.EncryptedPrivateKey)
                {
                    pictureIcon.Image = ImageResources.key_icon_16;
                }
                else if (myAccountData.Type == MyAccountType.LedgerWallet)
                {
                    pictureIcon.Image = ImageResources.ledger_16;
                }
            }
            else if (_accountViewModel.AccountData is WatchedAccount watchedAccountData)
            {
                pictureIcon.Image = watchedAccountData.IsMyAccount
                    ? ImageResources.businessman_16
                    : ImageResources.businessman_bw_16;
            }
            Tag = account;
            labelName.Text = account.AccountData.Name;
            labelAddress.Text = account.AccountData.GetAddressBech32().FromBech32ToShortReadable();
            RefreshAccount();
        }

        public void RefreshAccount()
        {
            labelAmount.Text = $"{Account.ZilTotalBalance:#,##0.00} ZIL + {Account.TokenBalances?.Count ?? 0} Tokens = {Account.TotalValueUsd:#,##0.00} USD";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnMouseHoverEnter()
        {
            buttonEdit.Visible = true;
            buttonUp.Visible = CanMoveUp;
            buttonDown.Visible = CanMoveDown;
        }

        protected override void OnMouseHoverLeave()
        {
            buttonEdit.Visible = false;
            buttonUp.Visible = false;
            buttonDown.Visible = false;
        }

        private void OnAnyClick()
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void WalletListItemControl_Click(object sender, EventArgs e)
        {
            OnAnyClick();
        }

        private void labelName_Click(object sender, EventArgs e)
        {
            OnAnyClick();
        }

        private void labelAmount_Click(object sender, EventArgs e)
        {
            OnAnyClick();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EditClicked?.Invoke(this, EventArgs.Empty);
            UnHover();
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            MoveUpClicked?.Invoke(this, EventArgs.Empty);
            UnHover();
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            MoveDownClicked?.Invoke(this, EventArgs.Empty);
            UnHover();
        }

    }
}
