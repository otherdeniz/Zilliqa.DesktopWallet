using System.ComponentModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet
{
    public partial class AddAccountControl : UserControl
    {
        public AddAccountControl()
        {
            InitializeComponent();
            panelPrivateKey.Dock = DockStyle.Fill;
        }

        public event EventHandler<EventArgs>? ValueChanged;

        [Browsable(false)]
        public string Title => textWalletName.Text;

        [Browsable(false)]
        public AddWalletType AddType
        {
            get
            {
                if (radioButtonNew.Checked)
                {
                    return AddWalletType.AddNew;
                }
                if (radioButtonImportPrivateKey.Checked)
                {
                    return AddWalletType.ImportPrivateKey;
                }
                if (radioButtonLedger.Checked)
                {
                    return AddWalletType.ConnectLedger;
                }
                return AddWalletType.NotSelected;
            }
        }

        [Browsable(false)]
        public string PrivateKey => textPrivateKey.Text;

        public bool CheckFields()
        {
            if (AddType == AddWalletType.NotSelected
                || string.IsNullOrEmpty(Title))
            {
                return false;
            }
            if (AddType == AddWalletType.ImportPrivateKey)
            {
                return !string.IsNullOrEmpty(PrivateKey);
            }
            return true;
        }

        private void OnValueChanged()
        {
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }

        private void textWalletName_TextChanged(object sender, EventArgs e)
        {
            OnValueChanged();
        }

        private void radioButtonNew_Click(object sender, EventArgs e)
        {
            panelPrivateKey.Visible = false;
            OnValueChanged();
        }

        private void radioButtonImportPrivateKey_CheckedChanged(object sender, EventArgs e)
        {
            panelPrivateKey.Visible = true;
            OnValueChanged();
        }

        private void radioButtonLedger_CheckedChanged(object sender, EventArgs e)
        {
            panelPrivateKey.Visible = false;
            OnValueChanged();
        }

        private void textPrivateKey_TextChanged(object sender, EventArgs e)
        {
            OnValueChanged();
        }

        public enum AddWalletType
        {
            NotSelected = 0,
            AddNew = 1,
            ImportPrivateKey = 2,
            ConnectLedger = 3
        }
    }
}
