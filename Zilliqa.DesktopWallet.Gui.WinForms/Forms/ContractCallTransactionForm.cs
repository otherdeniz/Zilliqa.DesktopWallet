using System.Globalization;
using Zilliqa.DesktopWallet.Core.ContractCode;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class ContractCallTransactionForm : DialogWithPasswordBaseForm
    {
        public static void ExecuteShow(Form parentForm, 
            AccountViewModel? account = null, 
            string? contractAddress = null)
        {
            var form = new ContractCallTransactionForm();
            form.LoadSenderAccounts(account?.AccountData as MyAccount);
            if (contractAddress != null)
            {
                form.addressTextBox.Address = new AddressValue(contractAddress);
            }
            form.Show(parentForm);
        }

        private AccountViewModel? _selectedAccount;
        private IList<CodeTransition>? _codeTransitions;

        public ContractCallTransactionForm()
        {
            InitializeComponent();
        }

        protected override void ExecuteResult()
        {

        }

        protected override bool OnOk()
        {
            if (base.OnOk())
            {
                return true;
            }
            return false;
        }

        protected override bool CheckFields()
        {
            return base.CheckFields()
                   && addressTextBox.Address != null
                   && comboBoxMethod.SelectedIndex > -1;
        }

        protected override void AccountSelected(AccountViewModel selectedAccount)
        {
            _selectedAccount = selectedAccount;
            textAvailableFunds.Text = selectedAccount.ZilLiquidBalance.ToString("#,##0.00##########", CultureInfo.CurrentCulture);
        }

        private void LoadMethods()
        {
            _codeTransitions = null;
            comboBoxMethod.Items.Clear();
            if (addressTextBox.Address != null)
            {
                var smartContract = RepositoryManager.Instance.DatabaseRepository.Database.GetTable<SmartContract>()
                    .FindRecord(nameof(SmartContract.ContractAddress), 
                        addressTextBox.Address.Address.GetBase16(false));
                if (smartContract != null)
                {
                    var contractFieldValues = new ContractFieldsValues(smartContract);
                    _codeTransitions = contractFieldValues.CodeTransitions;
                    foreach (var transition in contractFieldValues.CodeTransitions)
                    {
                        var arguments = string.Join(", ", transition.ParseArguments().Select(a => $"{a.Name} [{a.Type}]"));
                        comboBoxMethod.Items.Add($"{transition.Name} ({arguments})");
                    }
                }
            }
        }

        private void LoadArguments()
        {

        }

        private void addressTextBox_AddressChanged(object sender, EventArgs e)
        {
            LoadMethods();
            RefreshOkButton();
        }

        private void comboBoxMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadArguments();
            RefreshOkButton();
        }
    }
}
