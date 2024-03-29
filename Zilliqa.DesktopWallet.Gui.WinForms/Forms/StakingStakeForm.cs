﻿using System.Globalization;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.Gui.WinForms.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class StakingStakeForm : DialogWithPasswordBaseForm
    {
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

        private AccountViewModel _account = null!;
        private bool _feesLoaded;
        private decimal _feesToSafe = 20;
        private List<StakingSeedNode>? _seedNodes;

        public StakingStakeForm()
        {
            InitializeComponent();
        }

        public string SsnAddress { get; private set; } = string.Empty;

        public decimal Amount { get; private set; }

        protected override bool OnOk()
        {
            if (base.OnOk())
            {
                SsnAddress = GetSelectedSeedNode()!.SsnAddress;
                Amount = decimal.Parse(textAmount.Text);
                return true;
            }
            return false;
        }

        protected override bool CheckFields()
        {
            return base.CheckFields()
                   && _feesLoaded
                   && GetSelectedSeedNode() != null
                   && decimal.TryParse(textAmount.Text, out _);
        }

        private StakingSeedNode? GetSelectedSeedNode()
        {
            if (_seedNodes != null && comboBoxSsn.SelectedIndex > -1)
            {
                return _seedNodes[comboBoxSsn.SelectedIndex];
            }

            return null;
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
                    RefreshOkButton();
                });
            });
            _seedNodes = StakingService.Instance.GetSeedNodeList().OrderByDescending(s => s.StakeAmount).ToList();
            //TODO: put the Zillifriends-SSN to the top of the list
            foreach (var stakingSeedNode in _seedNodes)
            {
                var myStake =
                    _account.Stakes.FirstOrDefault(s => s.StakingNode.SsnAddress == stakingSeedNode.SsnAddress);
                var ssnText =
                    $"{stakingSeedNode.Name}   -   [{stakingSeedNode.CommissionRatePercent:0.00}%]   -   All stakes: {stakingSeedNode.StakeAmount.ZilSatoshisToZil():#,##0} ZIL"
                    + (myStake != null ? $"  -  You staked: {myStake.StakeAmount:#,##0} ZIL" : "");
                comboBoxSsn.Items.Add(ssnText);
                if (myStake != null
                    && comboBoxSsn.SelectedIndex == -1)
                {
                    comboBoxSsn.SelectedIndex = comboBoxSsn.Items.Count- 1;
                }
            }
            textAvailableFunds.Text = _account.ZilLiquidBalance.ToString("#,##0.00##########", CultureInfo.CurrentCulture);
        }

        private void comboBoxSsn_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pleaseUseZillifriendsSsn =
                "Please consider using 'Zillifriends' Stake Node. You directly support the Developers of this free Wallet Software by this way.";
            var seedNode = GetSelectedSeedNode();
            if (seedNode != null)
            {
                if (seedNode.SsnAddress == "REPLACE:[Zillifriends-SSN-Address]")
                {
                    // perfect, SSN of Zillifriends :)
                    pictureNodeHint.Image = IconResources.SmileyLove32;
                    labelNodeHint.Text =
                        "Thank you!\nYou directly support the Developers of this free Wallet Software by using this Stake Node.";
                }
                else if (_account.Stakes.Count == 0)
                {
                    // no SSN used yet
                    pictureNodeHint.Image = IconResources.SmileySmile32;
                    labelNodeHint.Text = "You dont have any Stakes yet, you can choose any Stake Node.\n" +
                                         pleaseUseZillifriendsSsn;
                }
                else if (_account.Stakes.Any(s => s.StakingNode.SsnAddress == seedNode.SsnAddress))
                {
                    // already used SSN
                    pictureNodeHint.Image = IconResources.SmileySmile32;
                    labelNodeHint.Text = "You already have Stakes on this Stake Node.";
                }
                else
                {
                    // not yet used SSN
                    pictureNodeHint.Image = IconResources.SmileyQuestion32;
                    labelNodeHint.Text = "You already have Stakes on another Stake Node. If you use multiple Nodes, your Transaction-Fees will increase for every Claim.\n" +
                                         pleaseUseZillifriendsSsn;
                }
            }
            RefreshOkButton();
        }

        private void textAmount_TextChanged(object sender, EventArgs e)
        {
            RefreshOkButton();
        }

        private void buttonSendMax_Click(object sender, EventArgs e)
        {
            var maxAmount = (_account.ZilLiquidBalance - _feesToSafe.ZilSatoshisToZil());
            textAmount.Text = maxAmount > 0
                ? maxAmount.ToString(CultureInfo.CurrentCulture)
                : "0";
        }
    }
}
