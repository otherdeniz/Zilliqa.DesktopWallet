using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.DataSource;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class AddressBookForm : DialogBaseForm
    {
        public static AddressValue? Execute(Form parentForm)
        {
            using (var form = new AddressBookForm())
            {
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                {
                    return form.SelectedAddress;
                }
            }
            return null;
        }

        public AddressBookForm()
        {
            InitializeComponent();
            panelAddressBook.Dock = DockStyle.Fill;
            gridViewKnownAddresses.Dock = DockStyle.Fill;
        }

        public AddressValue? SelectedAddress { get; private set; }

        protected override bool OnOk()
        {
            if (buttonTabAddressBook.Checked)
            {
                if (gridViewAddressBook.SelectedItem?.Value is AddressbookEntryViewModel addressbookEntry)
                {
                    SelectedAddress = new AddressValue(addressbookEntry.Address);
                    return true;
                }
            }
            else if (buttonTabKnownAddresses.Checked)
            {
                if (gridViewKnownAddresses.SelectedItem?.Value is KnownAddressViewModel knownAddress)
                {
                    SelectedAddress = new AddressValue(knownAddress.Address);
                    return true;
                }
            }
            return false;
        }

        private void CheckFields()
        {
            buttonAddressRemove.Enabled = gridViewAddressBook.SelectedItem != null;
            buttonOk.Enabled = (buttonTabAddressBook.Checked && gridViewAddressBook.SelectedItem != null)
                               || (buttonTabKnownAddresses.Checked && gridViewKnownAddresses.SelectedItem != null);
        }

        private void ReloadAddressBook()
        {
            gridViewAddressBook.ClearSelection();
            var addressBookData = new PageableDataSource<AddressbookEntryViewModel>();
            addressBookData.Load(AddressBookFile.Instance.Entries
                .OrderBy(a => a.Name).ToList());
            gridViewAddressBook.LoadData(addressBookData);
        }

        private void AddressBookForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                TabButtonClick(buttonTabAddressBook, panelAddressBook);
                Task.Run(() =>
                {
                    var addressBookData = new PageableDataSource<AddressbookEntryViewModel>();
                    addressBookData.Load(AddressBookFile.Instance.Entries
                        .OrderBy(a => a.Name).ToList());

                    var knownAddressesData = new PageableDataSource<KnownAddressViewModel>();
                    knownAddressesData.Load(KnownAddressService.Instance.Bech32AddressNames.Values
                        .OrderBy(a => a.Category).ThenBy(a => a.Name).ToList());

                    WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                    {
                        gridViewAddressBook.LoadData(addressBookData);
                        gridViewKnownAddresses.LoadData(knownAddressesData);
                    });
                });
            }
        }

        private void buttonTabAddressBook_Click(object sender, EventArgs e)
        {
            TabButtonClick(buttonTabAddressBook, panelAddressBook);
            CheckFields();
        }

        private void buttonTabKnownAddresses_Click(object sender, EventArgs e)
        {
            TabButtonClick(buttonTabKnownAddresses, gridViewKnownAddresses);
            CheckFields();
        }

        private void TabButtonClick(ToolStripButton button, Control tabPageControl)
        {
            foreach (var item in toolStripTabs.Items)
            {
                if (item is ToolStripButton itemButton)
                {
                    itemButton.Checked = false;
                    itemButton.Font = new Font(itemButton.Font, FontStyle.Regular);
                }
            }
            button.Checked = true;
            button.Font = new Font(button.Font, FontStyle.Bold);

            foreach (Control pageControl in panelTabs.Controls)
            {
                pageControl.Visible = false;
            }
            tabPageControl.Visible = true;
        }

        private void gridViewAddressBook_SelectionChanged(object sender, Controls.GridView.GridViewControl.SelectedItemEventArgs e)
        {
            CheckFields();
        }

        private void gridViewKnownAddresses_SelectionChanged(object sender, Controls.GridView.GridViewControl.SelectedItemEventArgs e)
        {
            CheckFields();
        }

        private void buttonAddressAdd_Click(object sender, EventArgs e)
        {
            if (AddressBookAddForm.Execute(this))
            {
                ReloadAddressBook();
            }
        }

        private void buttonAddressRemove_Click(object sender, EventArgs e)
        {
            if (gridViewAddressBook.SelectedItem?.Value is AddressbookEntryViewModel addressbookEntry)
            {
                AddressBookFile.Instance.Entries.Remove(addressbookEntry);
                AddressBookFile.Instance.Save();
                ReloadAddressBook();
            }
        }
    }
}
