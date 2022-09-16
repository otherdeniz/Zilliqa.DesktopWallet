using Zilliqa.DesktopWallet.ApiClient.Utils;
using Zilliqa.DesktopWallet.Gui.WinForms.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class AddWatchedAccountForm : DialogBaseForm
    {
        public AddWatchedAccountForm()
        {
            InitializeComponent();
        }

        public string AccountName { get; private set; } = string.Empty;

        public string AddressBech32 { get; private set; } = string.Empty;

        public bool IsMyAccount { get; private set; }

        public static AddWatchedAccountResult? Execute(Form parentForm, string? address = null, string? addressTitle = null)
        {
            using (var form = new AddWatchedAccountForm())
            {
                if (address != null)
                {
                    form.textAddress.Text = address;
                }
                if (addressTitle != null)
                {
                    form.textWalletName.Text = addressTitle;
                }
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                {
                    return new AddWatchedAccountResult
                    {
                        AccountName = form.AccountName,
                        Address = form.AddressBech32,
                        IsMyAccount = form.IsMyAccount
                    };
                }
            }

            return null;
        }

        protected override bool OnOk()
        {
            if (CheckFields(true))
            {
                AccountName = textWalletName.Text;
                AddressBech32 = textAddress.Text;
                IsMyAccount = checkBoxMyAddress.Checked;
                return true;
            }
            return false;
        }

        private bool CheckFields(bool validateValues)
        {
            if (validateValues)
            {
                if (!MusBech32.IsValidZilAddress(textAddress.Text))
                {
                    MessageBox.Show("Invalid Zilliqa Address", "The Zilliqa Address is not valid",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return false;
                }
            }

            var ok = textWalletName.Text.Length >= 1
                     && textAddress.Text.Length >= 1;
            buttonOk.Enabled = ok;
            return ok;
        }

        private void textWalletName_TextChanged(object sender, EventArgs e)
        {
            CheckFields(false);
        }

        private void textAddress_TextChanged(object sender, EventArgs e)
        {
            CheckFields(false);
        }

    }
}
