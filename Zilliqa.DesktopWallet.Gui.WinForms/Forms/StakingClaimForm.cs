using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.Gui.WinForms.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class StakingClaimForm : DialogWithPasswordBaseForm
    {
        public static StakingClaimResult? Execute(Form parentForm, AccountViewModel account)
        {
            using (var form = new StakingClaimForm())
            {
                form._stakes = account.Stakes;
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                {
                    return new StakingClaimResult
                    {
                        Password = new PasswordInfo(form.Password),
                        SsnAddressList = form.SsnAddressList
                    };
                }
            }

            return null;
        }

        private IList<AddressStakedRowViewModel>? _stakes;

        public StakingClaimForm()
        {
            InitializeComponent();
        }

        public List<AddressValue> SsnAddressList { get; } = new();

        protected override bool CheckFields()
        {
            return base.CheckFields()
                && checkedListBoxSsn.SelectedIndices.Count > 0;
        }

        protected override bool OnOk()
        {
            if (base.OnOk())
            {
                SsnAddressList.Clear();
                foreach (int selectedIndex in checkedListBoxSsn.CheckedIndices)
                {
                    SsnAddressList.Add(new AddressValue(_stakes![selectedIndex].StakingNode.SsnAddress));
                }
                return true;
            }
            return false;
        }

        private void checkedListBoxSsn_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            RefreshOkButton();
        }

        private void StakingClaimForm_Load(object sender, EventArgs e)
        {
            foreach (var stake in _stakes!)
            {
                checkedListBoxSsn.Items.Add($"{stake.StakingNodeName}  -  You staked: {stake.StakeAmount:#,##0.00} ZIL  -  Unclaimed: {stake.UnclaimedRewards:#,##0.00} ZIL");
            }
        }

    }
}
