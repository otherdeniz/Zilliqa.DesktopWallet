using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Gui.WinForms.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class StakingClaimForm : DialogWithPasswordBaseForm
    {
        public static DialogWithPasswordResult? Execute(Form parentForm)
        {
            using (var form = new StakingClaimForm())
            {
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                {
                    return new DialogWithPasswordResult
                    {
                        Password = new PasswordInfo(form.Password)
                    };
                }
            }

            return null;
        }

        public StakingClaimForm()
        {
            InitializeComponent();
        }
    }
}
