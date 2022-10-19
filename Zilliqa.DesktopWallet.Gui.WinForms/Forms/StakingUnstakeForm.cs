using System.Globalization;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.Gui.WinForms.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class StakingUnstakeForm : DialogWithPasswordBaseForm
    {
        public static StakingStakeResult? Execute(Form parentForm, AccountViewModel account)
        {
            using (var form = new StakingUnstakeForm())
            {
                form._stakes = account.Stakes;
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                {
                    return new StakingStakeResult
                    {
                        Password = new PasswordInfo(form.Password),
                        SsnAddress = new AddressValue(form.SsnAddress),
                        Amount = form.Amount
                    };
                }
            }

            return null;
        }

        private IList<AddressStakedRowViewModel>? _stakes;

        public StakingUnstakeForm()
        {
            InitializeComponent();
        }

        public string SsnAddress { get; private set; } = string.Empty;

        public decimal Amount { get; private set; }

        protected override bool OnOk()
        {
            if (base.OnOk())
            {
                var stake = GetSelectedStake()!;
                if (stake.UnclaimedRewards > 0)
                {
                    MessageBox.Show("This Account has unclaimed stake rewards.\nPlease claim rewards first.", 
                        "Unstake not possible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                SsnAddress = stake.StakingNode.SsnAddress;
                Amount = decimal.Parse(textAmount.Text);
                if (stake.StakeAmount < Amount + 10)
                {
                    MessageBox.Show("This Account has not enough staked funds to unstake this amount.\nYou can only unstake as much as you have staked, minus 10 ZIL.", 
                        "Unstake not possible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                return true;
            }
            return false;
        }

        protected override bool CheckFields()
        {
            return base.CheckFields()
                   && GetSelectedStake() != null
                   && decimal.TryParse(textAmount.Text, out var amountValue)
                   && amountValue > 0;
        }

        private AddressStakedRowViewModel? GetSelectedStake()
        {
            if (_stakes != null && comboBoxSsn.SelectedIndex > -1)
            {
                return _stakes[comboBoxSsn.SelectedIndex];
            }

            return null;
        }

        private void StakingUnstakeForm_Load(object sender, EventArgs e)
        {
            if (_stakes == null) return;
            foreach (var stake in _stakes)
            {
                var ssnText = $"{stake.StakingNode.Name}   -   You staked: {stake.StakeAmount:#,##0} ZIL";
                comboBoxSsn.Items.Add(ssnText);
            }
        }

        private void comboBoxSsn_SelectedIndexChanged(object sender, EventArgs e)
        {
            var stake = GetSelectedStake();
            if (stake != null)
            {
                textStakedFunds.Text = stake.StakeAmount.ToString("#,##0.00##########", CultureInfo.CurrentCulture);
                buttonUnstakeMax.Enabled = true;
            }
            RefreshOkButton();
        }

        private void textAmount_TextChanged(object sender, EventArgs e)
        {
            RefreshOkButton();
        }

        private void buttonUnstakeMax_Click(object sender, EventArgs e)
        {
            var stake = GetSelectedStake();
            if (stake != null)
            {
                var maxAmount = stake.StakeAmount - 10m;
                textAmount.Text = maxAmount > 0
                    ? maxAmount.ToString(CultureInfo.CurrentCulture)
                    : "0";
            }
        }

    }
}
