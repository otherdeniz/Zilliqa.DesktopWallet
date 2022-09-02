﻿using Zilligraph.Database.Storage;
using Zilliqa.DesktopWallet.Core.Repository;
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
                labelStatus.Text = $"Upgrading Database Table '{upgareTable.TableName}' : {upgareTable.InitialisationCompletedPercent:0.00}%";
                return;
            }
            //if (!_zilligraphTables.All(t => t.InitialisationCompleted))
            //{
            //    var upgareTable = _zilligraphTables.FirstOrDefault(t =>
            //        t.InitialisationCompletedPercent > 0
            //        && t.InitialisationCompletedPercent < 100);
            //    var upgradeTableText = upgareTable == null
            //        ? "..."
            //        : $"Table '{upgareTable.TableName}' : {upgareTable.InitialisationCompletedPercent:0.0}%";
            //    labelStatus.Text = $"Upgrading Database {upgradeTableText}";
            //    return;
            //}

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
