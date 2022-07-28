namespace Zilliqa.DesktopWallet.TestApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new DatabaseStorageTestForm();
            form.Show(this);
        }
    }
}