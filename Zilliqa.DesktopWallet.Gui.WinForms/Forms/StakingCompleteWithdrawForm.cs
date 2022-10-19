using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Gui.WinForms.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class StakingCompleteWithdrawForm : DialogWithPasswordBaseForm
    {
        public StakingCompleteWithdrawForm()
        {
            InitializeComponent();
        }

        public static DialogWithPasswordResult? Execute(Form parentForm)
        {
            using (var form = new StakingCompleteWithdrawForm())
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

    }
}
