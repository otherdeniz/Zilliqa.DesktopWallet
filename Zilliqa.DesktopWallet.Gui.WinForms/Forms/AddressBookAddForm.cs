using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class AddressBookAddForm : DialogBaseForm
    {
        public static bool Execute(Form parentForm, string? address = null, string? addressName = null)
        {
            using (var form = new AddressBookAddForm())
            {
                if (address != null)
                {
                    form.textAddress.Text = address;
                }
                if (addressName != null)
                {
                    form.textName.Text = addressName;
                }
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                {
                    return true;
                }
            }
            return false;
        }

        public AddressBookAddForm()
        {
            InitializeComponent();
        }

        private void CheckFields()
        {
            buttonOk.Enabled = textName.Text.Length > 0 
                               && textAddress.Text.Length > 0;
        }

        protected override bool OnOk()
        {
            if (!AddressValue.TryParse(textAddress.Text, out _))
            {
                MessageBox.Show("The provided Address is not a valid Zilliqa Address", "Invalid Address",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        protected override void ExecuteResult()
        {
            var addressEntry = new AddressbookEntryViewModel
            {
                Address = new Address(textAddress.Text).GetBech32(),
                Name = textName.Text
            };
            AddressBookFile.Instance.Entries.Add(addressEntry);
            AddressBookFile.Instance.Save();
            base.ExecuteResult();
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
        }

        private void textAddress_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
        }
    }
}
