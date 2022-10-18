using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;

namespace Zilliqa.DesktopWallet.Gui.WinForms
{
    public partial class SecondForm : Form
    {
        public static List<SecondForm> ActiveForms { get; } = new List<SecondForm>();

        public static SecondForm ShowDetailsAsForm(Control detailsControl)
        {
            var form = new SecondForm();
            form.LoadDetails(detailsControl);
            form.Show(MainForm.Instance);
            ActiveForms.Add(form);
            return form;
        }

        public SecondForm()
        {
            InitializeComponent();
        }

        private void LoadDetails(Control detailsControl)
        {
            ResetMasterPanelRecursive(detailsControl);
            masterPanel.LoadLeftControl(detailsControl);
        }

        private void ResetMasterPanelRecursive(Control parentControl)
        {
            foreach (Control childControl in parentControl.Controls)
            {
                if (childControl is IMasterPanelRelatedControl masterPanelRelated)
                {
                    masterPanelRelated.ResetMasterPanel();
                }
                else
                {
                    ResetMasterPanelRecursive(childControl);
                }
            }
        }
        private void SecondForm_Load(object sender, EventArgs e)
        {
            this.Text = ApplicationInfo.MainFormTitle;
            if (ZilliqaClient.UseTestnet)
            {
                Icon = ImageResources.Zilliqa_icon_testnet;
            }
            var screen = Screen.FromControl(this);
            Left = screen.Bounds.Width - Width - 50;
        }

        private void SecondForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ActiveForms.Remove(this);
        }
    }
}
