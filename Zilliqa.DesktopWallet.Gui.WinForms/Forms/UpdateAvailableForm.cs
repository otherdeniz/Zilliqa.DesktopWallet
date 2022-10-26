using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Services;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class UpdateAvailableForm : Form
    {
        public static bool Execute(Form parentForm, GithubReleaseInfo releaseInfo)
        {
            using (var form = new UpdateAvailableForm())
            {
                form.LoadRelease(releaseInfo);
                return form.ShowDialog(parentForm) == DialogResult.OK;
            }
        }

        private GithubReleaseInfo _releaseInfo = null!;

        public UpdateAvailableForm()
        {
            InitializeComponent();
        }

        private void LoadRelease(GithubReleaseInfo releaseInfo)
        {
            _releaseInfo = releaseInfo;
            labelCurrentVersion.Text = ApplicationInfo.ApplicationVersionText;
            labelNewVersion.Text = releaseInfo.Name;
            labelReleaseDate.Text = releaseInfo.CreatedAt.ToString("g");
            labelDownloadSize.Text = releaseInfo.FileSize.BytesToReadable();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                buttonUpdate.Enabled = false;
                buttonSkip.Enabled = false;
                labelQuestionTitle.Text = "Please wait, downloading...";
                Refresh();
                AutoUpdateService.Instance.UpdateNow(_releaseInfo.DownloadUrl);
                Close();
            }
            catch (Exception ex)
            {
                Logging.LogError("Update download failed", ex);
                MessageBox.Show("Error", $"Download failed: {ex.Message}", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                Close();
            }
        }

        private void buttonSkip_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
