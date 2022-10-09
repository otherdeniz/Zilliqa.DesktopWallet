using System.Globalization;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Cryptography;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Properties;
using Zilliqa.DesktopWallet.Gui.WinForms.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class StakingStakeForm : DialogBaseForm
    {
        private AccountViewModel _account = null!;
        private bool _feesLoaded;
        private decimal _feesToSafe = 20;
        private List<StakingSeedNode>? _seedNodes;

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
                SsnAddress = GetSelectedSeedNode()!.SsnAddress;
                Password = textPassword1.Text;
                Amount = decimal.Parse(textAmount.Text);
                return true;
            }
            return false;
        }

        private StakingSeedNode? GetSelectedSeedNode()
        {
            if (_seedNodes != null && comboBoxSsn.SelectedIndex > -1)
            {
                return _seedNodes[comboBoxSsn.SelectedIndex];
            }

            return null;
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

            var ok = _feesLoaded
                     && GetSelectedSeedNode() != null
                     && decimal.TryParse(textAmount.Text, out _)
                     && textPassword1.Text.Length >= 1;
            buttonOk.Enabled = ok;
            return ok;
        }

        private void StakingStakeForm_Load(object sender, EventArgs e)
        {
            textGasPrice.Text = RepositoryManager.Instance.BlockchainBrowserRepository.MinimumGasPrice
                .ZilSatoshisToZil().ToString(CultureInfo.CurrentCulture);
            Task.Run(() =>
            {
                var dbRepo = RepositoryManager.Instance.DatabaseRepository;
                var lastStakeTransaction = dbRepo.GetLatestContractCallTransaction(
                    new AddressValue(StakingService.Instance.CurrentProxy.Address), StakingService.ContractMethodStake);
                var lastClaimTransaction = dbRepo.GetLatestContractCallTransaction(
                    new AddressValue(StakingService.Instance.CurrentProxy.Address), StakingService.ContractMethodClaim);
                var stakeGasLimit = lastStakeTransaction?.Receipt.CumulativeGas ??
                                    SendTransactionService.GasLimitDefaultContractCall;
                var claimGasLimit = lastClaimTransaction?.Receipt.CumulativeGas ??
                                    SendTransactionService.GasLimitDefaultContractCall;
                var stakeFee = RepositoryManager.Instance.BlockchainBrowserRepository.MinimumGasPrice *
                               stakeGasLimit;
                var claimFee = RepositoryManager.Instance.BlockchainBrowserRepository.MinimumGasPrice *
                               claimGasLimit;
                _feesToSafe = Convert.ToDecimal(stakeFee + claimFee) * 1.5m;
                _feesLoaded = true;
                WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                {
                    buttonSendMax.Enabled = true;
                    textStakeFee.Text = stakeFee.ZilSatoshisToZil().ToString(CultureInfo.CurrentCulture);
                    textClaimFee.Text = claimFee.ZilSatoshisToZil().ToString(CultureInfo.CurrentCulture);
                    CheckFields(false);
                });
            });
            _seedNodes = StakingService.Instance.GetSeedNodeList().OrderByDescending(s => s.StakeAmount).ToList();
            //TODO: put the Zillifriends-SSN to the top of the list
            foreach (var stakingSeedNode in _seedNodes)
            {
                comboBoxSsn.Items.Add(
                    $"{stakingSeedNode.Name}   -   Staked: {stakingSeedNode.StakeAmount:#,##0} ZIL   -   Commission: {stakingSeedNode.CommissionRatePercent:0.00}%");
                if (_account.Stakes.Any(s => s.StakingNode.SsnAddress == stakingSeedNode.SsnAddress)
                    && comboBoxSsn.SelectedIndex == -1)
                {
                    comboBoxSsn.SelectedIndex = comboBoxSsn.Items.Count- 1;
                }
            }
            textAvailableFunds.Text = _account.ZilLiquidBalance.ToString("#,##0.0000", CultureInfo.CurrentCulture);
        }

        private void comboBoxSsn_SelectedIndexChanged(object sender, EventArgs e)
        {
            var seedNode = GetSelectedSeedNode();
            if (seedNode != null)
            {
                if (seedNode.SsnAddress == "REPLACE:[Zillifriends-SSN-Address]")
                {
                    // perfect, SSN of Zillifriends :)
                    pictureNodeHint.Image = IconResources.SmileyLove32;
                }
                else if (_account.Stakes.Count == 0)
                {
                    // no SSN used yet
                    pictureNodeHint.Image = IconResources.SmileySmile32;
                }
                else if (_account.Stakes.Any(s => s.StakingNode.SsnAddress == seedNode.SsnAddress))
                {
                    // already used SSN
                    pictureNodeHint.Image = IconResources.SmileySmile32;
                }
                else
                {
                    // not yet used SSN
                    pictureNodeHint.Image = IconResources.SmileyQuestion32;
                }
            }

            CheckFields(false);
        }

        private void textAmount_TextChanged(object sender, EventArgs e)
        {
            CheckFields(false);
        }

        private void textPassword1_TextChanged(object sender, EventArgs e)
        {
            CheckFields(false);
        }

        private void buttonSendMax_Click(object sender, EventArgs e)
        {
            textAmount.Text = (_account.ZilLiquidBalance - _feesToSafe.ZilSatoshisToZil())
                .ToString(CultureInfo.CurrentCulture);
        }
    }
}
