using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Services;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class StartupDialogForm : Form
    {
        public StartupDialogForm()
        {
            InitializeComponent();
        }

        public static bool Execute(Form parent)
        {
            using (var form = new StartupDialogForm())
            {
                return form.ShowDialog(parent) == DialogResult.OK;
            }
        }

        private void StartupDialogForm_Load(object sender, EventArgs e)
        {
            labelStatus.Text = StartupService.Instance.StartupStatus;
            StartupService.Instance.StatusChanged += (sender, args) =>
            {
                WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                {
                    if (args.IsCompleted)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        labelStatus.Text = args.StatusText;
                    }
                });
            };
        }
    }
}
