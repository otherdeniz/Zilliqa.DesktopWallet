using Zilligraph.Database.Storage;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ZilligraphDb;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class StartupDialogForm : Form
    {
        private readonly List<IZilligraphTable> _zilligraphTables = new();

        public StartupDialogForm()
        {
            InitializeComponent();
            var database = RepositoryManager.Instance.DatabaseRepository.Database;
            _zilligraphTables.Add(database.GetTable<Block>());
            _zilligraphTables.Add(database.GetTable<Transaction>());
        }

        public static bool Execute(Form parent)
        {
            using (var form = new StartupDialogForm())
            {
                return form.ShowDialog(parent) == DialogResult.OK;
            }
        }

        private void timerRefreshStatus_Tick(object sender, EventArgs e)
        {
            if (!RepositoryManager.Instance.CoingeckoRepository.StartupCompleted)
            {
                labelStatus.Text = "Starting Services ...";
                return;
            }

            var upgareTable = _zilligraphTables.FirstOrDefault(t => !t.InitialisationCompleted);
            if (upgareTable != null)
            {
                upgareTable.EnsureInitialisationIsStarted();
                if (upgareTable.InitialisationCompletedPercent > 0
                    && upgareTable.InitialisationCompletedPercent < 100)
                {
                    labelStatus.Text = $"Upgrading Database Table '{upgareTable.TableName}' : {upgareTable.InitialisationCompletedPercent:0.00}%";
                }
                return;
            }

#if !DEBUG
            if (ZilliqaBlockchainCrawler.Instance.RunningState == RunningState.Stopped)
            {
                labelStatus.Text = "Starting Blockchain Sync ...";
                ZilliqaBlockchainCrawler.Instance.Start();
                return;
            }
#endif

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
