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
                SsnAddress = GetSelectedSeedNode()!.StakingNode.SsnAddress;
                Amount = decimal.Parse(textAmount.Text);
                return true;
            }
            return false;
        }

        protected override bool CheckFields()
        {
            return base.CheckFields()
                   && GetSelectedSeedNode() != null
                   && decimal.TryParse(textAmount.Text, out _);
        }

        private AddressStakedRowViewModel? GetSelectedSeedNode()
        {
            if (_stakes != null && comboBoxSsn.SelectedIndex > -1)
            {
                return _stakes[comboBoxSsn.SelectedIndex];
            }

            return null;
        }

        private void comboBoxSsn_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshOkButton();
        }

        private void textAmount_TextChanged(object sender, EventArgs e)
        {
            RefreshOkButton();
        }

        private void buttonUnstakeMax_Click(object sender, EventArgs e)
        {

        }
    }
}
