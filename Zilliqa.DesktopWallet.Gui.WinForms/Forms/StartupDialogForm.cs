using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Repository;
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
            if (!CheckForUpdate())
            {
                Close();
                return;
            }
            if (!ZilliqaClient.UseTestnet &&
                !CheckForSnapshotDownload())
            {
                Close();
                return;
            }
            StartupServices();
        }

        private bool CheckForUpdate()
        {
            labelStatus.Text = "Checking for application update";
            Refresh();
            try
            {
                var latestRelease = AutoUpdateService.Instance.GetLatestRelease();
                if (latestRelease != null && latestRelease.Version > ApplicationInfo.ApplicationVersion)
                {
                    return UpdateAvailableForm.Execute(this, latestRelease);
                }
            }
            catch (Exception e)
            {
                Logging.LogError("Check for application update failed", e);
            }
            return true;
        }

        private bool CheckForSnapshotDownload()
        {
            if (CrawlerStateDat.Instance.NewestBlockDate == null 
                || CrawlerStateDat.Instance.NewestBlockDate.Value.AddDays(1) < DateTime.Now)
            {
                labelStatus.Text = "Checking for updated blockchain snapshot";
                Refresh();
                try
                {
                    var snapshotInfo = RepositoryManager.Instance.WalletWebClient.GetSnapshotInfo();
                    if (snapshotInfo != null
                        && snapshotInfo.AppVersion == ApplicationInfo.ApplicationVersion
                        && snapshotInfo.TimestampUtc > (CrawlerStateDat.Instance.NewestBlockDate?.AddDays(1) ?? DateTime.MinValue))
                    {
                        return DownloadSnapshotForm.Execute(this, snapshotInfo);
                    }
                }
                catch (Exception e)
                {
                    Logging.LogError("Check for updated blockchain snapshot failed", e);
                }
            }
            return true;
        }

        private void StartupServices()
        {
            StartupService.Instance.Startup();
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
