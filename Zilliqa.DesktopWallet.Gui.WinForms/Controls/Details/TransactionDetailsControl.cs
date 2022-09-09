﻿using System.Diagnostics;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details
{
    public partial class TransactionDetailsControl : DrillDownBaseControl
    {
        private TransactionRowViewModelBase _transactionViewModel;

        public TransactionDetailsControl()
        {
            InitializeComponent();
        }

        public void LoadTransaction(TransactionIdValue transactionId)
        {
            var transactionModel = RepositoryManager.Instance.DatabaseRepository.Database.GetTable<Transaction>()
                .FindRecord(nameof(Transaction.Id), transactionId.TransactionId);
            if (transactionModel == null)
            {
                throw new RuntimeException($"Transaction {transactionId.TransactionId} not found in DB");
            }
            LoadTransaction(new BlockTransactionRowViewModel(transactionModel));
        }

        public void LoadTransaction(TransactionRowViewModelBase transactionViewModel)
        {
            _transactionViewModel = transactionViewModel;
            labelId.Text = transactionViewModel.Transaction.Id;
            labelDate.Text = transactionViewModel.Transaction.Timestamp.ToString("g");
            labelBlockNumber.LoadValue(transactionViewModel.Block, DrillDownPanel);
            propertyGridModel.SelectedObject = transactionViewModel.Transaction;
        }

        private void labelId_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            contextMenuId.Show(labelId, 0, labelId.Height);
        }

        private void menuIdCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_transactionViewModel.Transaction.Id);
        }

        private void menuIdBlockExplorer_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = $"https://viewblock.io/zilliqa/tx/0x{_transactionViewModel.Transaction.Id}",
                UseShellExecute = true
            });
        }

        private void labelBlockNumber_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            contextMenuBlockNumber.Show(labelBlockNumber, 0, labelBlockNumber.Height);
        }

        private void menuBlockOpen_Click(object sender, EventArgs e)
        {
            DrillDownPanel?.DisplayValue(_transactionViewModel.Block, false);
        }

        private void menuBlockCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_transactionViewModel.Block.BlockNumber.ToString());
        }

        private void menuBlockOpenExplorer_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = $"https://viewblock.io/zilliqa/tx/0x{_transactionViewModel.Transaction.Id}",
                UseShellExecute = true
            });
        }

    }
}
