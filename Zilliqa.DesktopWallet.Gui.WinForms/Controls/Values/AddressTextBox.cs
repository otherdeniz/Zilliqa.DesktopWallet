using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Forms;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values
{
    public partial class AddressTextBox : UserControl
    {
        public AddressTextBox()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs>? AddressChanged;

        public string Address
        {
            get => textAddress.Text;
            set => textAddress.Text = value;
        }

        private void textAddress_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textAddress.Text))
            {
                labelHint.Visible = true;
                labelInvalid.Visible = false;
                labelValid.Visible = false;
            }
            else
            {
                labelHint.Visible = false;
                if (AddressValue.TryParse(textAddress.Text, out var addressValue))
                {
                    labelInvalid.Visible = false;
                    labelValid.Visible = true;
                    var bech32 = addressValue!.Address.GetBech32();
                    var addressbookEntry =
                        AddressBookFile.Instance.Entries.FirstOrDefault(e => e.Address == bech32);
                    if (addressbookEntry != null)
                    {
                        labelValid.Text = $"Addressbook entry: {addressbookEntry.Name}";
                    }
                    else
                    {
                        var knownAddress = KnownAddressService.Instance.GetName(bech32);
                        labelValid.Text = knownAddress == null
                            ? "Valid Address"
                            : $"Known Address: {knownAddress.Name} ({knownAddress.Category})";
                    }
                }
                else
                {
                    labelInvalid.Visible = true;
                    labelValid.Visible = false;
                }
            }
            AddressChanged?.Invoke(this, EventArgs.Empty);
        }

        private void buttonAddressBook_Click(object sender, EventArgs e)
        {
            var address = AddressBookForm.Execute(this.ParentForm!);
            if (address != null)
            {
                textAddress.Text = address.Address.GetBech32();
            }
        }

    }
}
