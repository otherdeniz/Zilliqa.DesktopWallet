using Zilliqa.DesktopWallet.ApiClient;

namespace Zilliqa.DesktopWallet.Gui.WinForms
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            this.Text = ApplicationInfo.MainFormTitle;
            if (ZilliqaClient.UseTestnet)
            {
                Icon = ImageResources.Zilliqa_icon_testnet;
            }
            var screen = Screen.FromControl(this);
            Left = screen.Bounds.Width - Width - 50;
        }
    }
}
