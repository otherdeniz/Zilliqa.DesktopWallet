using System.ComponentModel;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;
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

        [DefaultValue(false)]
        public bool OnlyContractAddresses { get; set; }

        [DefaultValue(null)]
        public AddressValue? Address
        {
            get => AddressValue.TryParse(textAddress.Text, out var addressValue) 
                ? addressValue 
                : null;
            set => textAddress.Text = value?.Address.GetBech32() ?? "";
        }

        private void textAddress_TextChanged(object sender, EventArgs e)
        {
            var validBefore = labelValid.Visible;
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
                    if (OnlyContractAddresses
                        && RepositoryManager.Instance.DatabaseRepository.Database.GetTable<SmartContract>()
                            .FindRecord(nameof(SmartContract.ContractAddress), 
                                addressValue!.Address.GetBase16(false)) == null)
                    {
                        labelInvalid.Text = "Address is not a Smart Contract";
                        labelInvalid.Visible = true;
                        labelValid.Visible = false;
                    }
                    else
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
                        AddressChanged?.Invoke(this, EventArgs.Empty);
                        return;
                    }
                }
                else
                {
                    labelInvalid.Text = "Invalid Address";
                    labelInvalid.Visible = true;
                    labelValid.Visible = false;
                }
            }
            if (validBefore)
            {
                AddressChanged?.Invoke(this, EventArgs.Empty);
            }
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
