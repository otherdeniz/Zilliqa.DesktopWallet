using Zilliqa.DesktopWallet.Core.Cryptography;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Properties;
using Zilliqa.DesktopWallet.Gui.WinForms.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class StakingStakeForm : DialogBaseForm
    {
        private AccountViewModel _account = null!;

        public StakingStakeForm()
        {
            InitializeComponent();
        }

        public string SsnAddress { get; private set; } = string.Empty;

        public decimal Amount { get; private set; } = 0;

        public string Password { get; private set; } = string.Empty;

        public static StakingStakeResult? Execute(Form parentForm, AccountViewModel account)
        {
            using (var form = new StakingStakeForm())
            {
                form._account = account;
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                {
                    return new StakingStakeResult()
                    {
                        Password = new PasswordInfo(form.Password),
                        SsnAddress = new AddressValue(form.SsnAddress),
                        Amount = form.Amount
                    };
                }
            }

            return null;
        }

        protected override bool OnOk()
        {
            if (CheckFields(true))
            {
                //SsnAddress = textToAddress.Text;
                Password = textPassword1.Text;
                Amount = decimal.Parse(textAmount.Text);
                return true;
            }
            return false;
        }

        private bool CheckFields(bool validatePassword)
        {
            if (validatePassword &&
                !EncryptionUtils.ValidatePasswordHash(textPassword1.Text, WalletDat.Instance.PasswordHash))
            {
                MessageBox.Show(Resources.EnterPasswordForm_WrongPassword_Text, Resources.EnterPasswordForm_WrongPassword_Title,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }

            var ok = decimal.TryParse(textAmount.Text, out _)
                     && textPassword1.Text.Length >= 1;
            buttonOk.Enabled = ok;
            return ok;
        }

        private void StakingStakeForm_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxSsn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPassword1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
