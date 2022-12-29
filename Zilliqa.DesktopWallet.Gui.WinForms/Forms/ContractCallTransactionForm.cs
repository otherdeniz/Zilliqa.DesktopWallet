using System.Globalization;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.ContractCode;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;
using Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values.Arguments;

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

        private IList<CodeTransition>? _codeTransitions;
        private List<CodeTransitionArgument>? _codeTransitionArguments;
        private List<ArgumentEditBaseControl>? _argumentEditControls;

        public ContractCallTransactionForm()
        {
            InitializeComponent();
        }

        protected override void ExecuteResult()
        {
            var methodName = _codeTransitions![comboBoxMethod.SelectedIndex].Name;
            var zilAmount = decimal.TryParse(textAmount.Text, out var decimalValue) ? decimalValue : 0m;
            var parameters = _argumentEditControls!.Select(c => new DataParam
            {
                Vname = c.ArgumentName,
                Type = c.ArgumentType,
                Value = c.ArgumentValue
            }).ToList();
            var addressText = addressTextBox.Address!;
            Task.Run(() =>
            {
                var sendResult = SendTransactionService.Instance.CallContract(
                    SenderAccount!.GetSenderAccount(),
                    addressText,
                    methodName,
                    parameters,
                    zilAmount);
                WinFormsSynchronisationContext.ExecuteSynchronized(() => 
                    TransactionSendResultForm.ExecuteShow(this.Owner, sendResult));
            });
        }

        protected override bool CheckFields()
        {
            return base.CheckFields()
                   && addressTextBox.Address != null
                   && _codeTransitions != null
                   && _argumentEditControls?.All(c => c.IsValid) == true;
        }

        protected override void AccountSelected(AccountViewModel selectedAccount)
        {
            textAvailableFunds.Text = selectedAccount.ZilLiquidBalance
                .ToString("#,##0.00##########", CultureInfo.CurrentCulture);
        }

        private void ContractCallTransactionForm_Load(object sender, EventArgs e)
        {
            textGasPrice.Text = RepositoryManager.Instance.BlockchainBrowserRepository.MinimumGasPrice
                .ZilSatoshisToZil().ToString(CultureInfo.CurrentCulture);
        }

        private void RefreshExpectedFee()
        {
            if (addressTextBox.Address != null 
                && _codeTransitions != null 
                && comboBoxMethod.SelectedIndex > -1)
            {
                var contractAddress = addressTextBox.Address;
                var methodName = _codeTransitions[comboBoxMethod.SelectedIndex].Name;
                Task.Run(() =>
                {
                    var dbRepo = RepositoryManager.Instance.DatabaseRepository;
                    var lastContractTransaction = dbRepo.GetLatestContractCallTransaction(contractAddress, methodName);
                    var gasLimit = lastContractTransaction?.Receipt.CumulativeGas ??
                                   SendTransactionService.GasLimitDefaultContractCall / 5;
                    var expectedFee = RepositoryManager.Instance.BlockchainBrowserRepository.MinimumGasPrice *
                                      gasLimit;
                    WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                    {
                        textGasCost.Text = gasLimit.ToString("#,##0");
                        textFee.Text = expectedFee.ZilSatoshisToZil().ToString(CultureInfo.CurrentCulture);
                    });
                });
            }
            else
            {
                textGasCost.Text = "";
                textFee.Text = "";
            }
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
            _codeTransitionArguments = null;
            _argumentEditControls = null;
            var disposableControls = panelArguments.Controls.OfType<ArgumentEditBaseControl>().ToArray();
            panelArguments.Controls.Clear();
            foreach (var control in disposableControls)
            {
                control.ArgumentValueChanged -= ArgumentEditControl_ValueChanged;
                control.Dispose();
            }

            if (_codeTransitions != null && comboBoxMethod.SelectedIndex > -1)
            {
                _codeTransitionArguments = _codeTransitions[comboBoxMethod.SelectedIndex].ParseArguments();
                _argumentEditControls = new List<ArgumentEditBaseControl>();
                foreach (var transitionArgument in _codeTransitionArguments.AsEnumerable().Reverse())
                {
                    var control = ArgumentEditBaseControl.CreateControl(transitionArgument.Type);
                    control.ArgumentValueChanged += ArgumentEditControl_ValueChanged;
                    control.NameMinWidth = 90;
                    control.TypeMinWidth = 65;
                    control.Dock = DockStyle.Top;
                    control.ArgumentName = transitionArgument.Name;
                    _argumentEditControls.Insert(0, control);
                    panelArguments.Controls.Add(control);
                }
            }
        }

        private void ArgumentEditControl_ValueChanged(object? sender, EventArgs e)
        {
            RefreshOkButton();
        }

        private void addressTextBox_AddressChanged(object sender, EventArgs e)
        {
            LoadMethods();
            RefreshOkButton();
        }

        private void comboBoxMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshExpectedFee();
            LoadArguments();
            RefreshOkButton();
        }

    }
}
