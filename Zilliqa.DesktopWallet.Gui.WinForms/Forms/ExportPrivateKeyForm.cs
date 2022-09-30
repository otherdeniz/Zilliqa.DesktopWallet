using Zilliqa.DesktopWallet.Core.Cryptography;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Properties;
using Zilliqa.DesktopWallet.Gui.WinForms.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class ExportPrivateKeyForm : DialogBaseForm
    {
        public ExportPrivateKeyForm()
        {
            InitializeComponent();
        }

        public string Password { get; private set; } = string.Empty;

        public string FileName { get; private set; } = string.Empty;

        public static ExportPrivateKeyResult? Execute(Form parentForm, string address)
        {
            using (var form = new ExportPrivateKeyForm())
            {
                form.saveFileDialog.FileName = $"Zilliqa-PrivateKey-{address}.txt";
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                {
                    return new ExportPrivateKeyResult
                    {
                        Password = new PasswordInfo(form.Password),
                        FileName = form.FileName
                    };
                }
            }

            return null;
        }

        protected override bool OnOk()
        {
            if (CheckFields(true))
            {
                Password = textPassword1.Text;
                return true;
            }
            return false;
        }

        private bool CheckFields(bool validateValues)
        {
            if (validateValues)
            {
                if (!EncryptionUtils.ValidatePasswordHash(textPassword1.Text, WalletDat.Instance.PasswordHash))
                {
                    MessageBox.Show(Resources.EnterPasswordForm_WrongPassword_Text, Resources.EnterPasswordForm_WrongPassword_Title,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return false;
                }
            }

            var ok = FileName != "";
            buttonOk.Enabled = ok;
            return ok;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                FileName = saveFileDialog.FileName;
                textFileName.Text = FileName;
            }
            CheckFields(false);
        }
    }
}
