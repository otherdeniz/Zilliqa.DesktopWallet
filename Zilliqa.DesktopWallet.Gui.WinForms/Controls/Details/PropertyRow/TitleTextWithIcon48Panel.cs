namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.PropertyRow
{
    public partial class TitleTextWithIcon48Panel : UserControl
    {
        public TitleTextWithIcon48Panel()
        {
            InitializeComponent();
        }

        public void LoadValues(string title, string subTitle, Image? icon48)
        {
            labelName.Text = title;
            labelDescription.Text = subTitle;
            pictureBoxIcon.Image = icon48;
        }
    }
}
