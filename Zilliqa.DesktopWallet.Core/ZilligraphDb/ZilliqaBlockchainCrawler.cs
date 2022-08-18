using System.Diagnostics;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Repository;
using ApiModel = Zilliqa.DesktopWallet.ApiClient.Model;
using DbModel = Zilligraph.Database.Schema.ZilliqaBlockchain;

namespace Zilliqa.DesktopWallet.Core.ZilligraphDb
{
    public sealed class ZilliqaBlockchainCrawler
    {
        public static ZilliqaBlockchainCrawler Instance { get; } = new();

        private CancellationTokenSource? _refreshCancellationTokenSource;
        private Task? _transactionsCrawlerJobTask;
        private Task? _blocksCrawlerJobTask;

        private ZilliqaBlockchainCrawler()
        {
            SetNumberOfBlocksProcessed();
        }

        public RunningState RunningState { get; private set; } = RunningState.Stopped;

        public bool IsCompleted { get; private set; }

        public int NumberOfBlocksOnChain
            => RepositoryManager.Instance.BlockchainBrowserRepository.BlockchainInfo.NumberOfBlocks - 1;

        public int NumberOfBlocksProcessed { get; private set; }

        public void Start(int startupDelaySeconds = 5)
        {
            if (RunningState == RunningState.Stopped)
            {
                RunningState = RunningState.Running;
                _refreshCancellationTokenSource = new CancellationTokenSource();
                CrawlerStateDat.Instance.EnsureExists();
                _blocksCrawlerJobTask = Task.Run(async () =>
                {
                    try
                    {
                        await BlocksCrawlerJob(startupDelaySeconds, _refreshCancellationTokenSource.Token);
                    }
                    catch (TaskCanceledException)
                    {
                        // expected
                    }
                    catch (Exception e)
                    {
                        // logging!
                        Debug.WriteLine(e.Message);
                    }

                    _blocksCrawlerJobTask = null;
                    CheckStoppedState();
                });
                _transactionsCrawlerJobTask = Task.Run(async () =>
                {
                    try
                    {
                        await TransactionsCrawlerJob(startupDelaySeconds + 1, _refreshCancellationTokenSource.Token);
                    }
                    catch (TaskCanceledException)
                    {
                        // expected
                    }
                    catch (Exception e)
                    {
                        // logging!
                        Debug.WriteLine(e.Message);
                    }

                    _transactionsCrawlerJobTask = null;
                    CheckStoppedState();
                });
            }
        }

        public void Stop(bool wait = false)
        {
            if (RunningState != RunningState.Running) return;
            RunningState = RunningState.Stopping;
            _refreshCancellationTokenSource?.Cancel();
            _refreshCancellationTokenSource = null;
            if (wait)
            {
                while (RunningState != RunningState.Stopped)
                {
                    Task.Run(async () => await Task.Delay(1000)).GetAwaiter().GetResult();
                }
            }
        }

        private void CheckStoppedState()
        {
            if (_blocksCrawlerJobTask == null
                && _transactionsCrawlerJobTask == null)
            {
                RunningState = RunningState.Stopped;
            }
        }

        private void SetNumberOfBlocksProcessed()
        {
            NumberOfBlocksProcessed = CrawlerStateDat.Instance.TransactionCrawler.HighestBlock > 0
                ? CrawlerStateDat.Instance.TransactionCrawler.HighestBlock - CrawlerStateDat.Instance.TransactionCrawler.LowestBlock + 1
                : 0;
        }

        private async Task TransactionsCrawlerJob(int startupDelaySeconds, CancellationToken cancellationToken)
        {
            await Task.Delay(startupDelaySeconds * 1000, cancellationToken);
            while (!cancellationToken.IsCancellationRequested)
            {
                var dbTableTransaction = RepositoryManager.Instance.ZilliqaBlockchainDbRepository.Database
                    .GetTable<DbModel.Transaction>();

                var newestBlock = NumberOfBlocksOnChain;
                int loopDelay = 5000;
                if (newestBlock > 0)
                {
                    var processBlockNumber = newestBlock;
                    if (CrawlerStateDat.Instance.TransactionCrawler.HighestBlock > 0)
                    {
                        if (CrawlerStateDat.Instance.TransactionCrawler.HighestBlock < newestBlock
                            && CrawlerStateDat.Instance.BlockCrawler.HighestBlock > CrawlerStateDat.Instance.TransactionCrawler.HighestBlock)
                        {
                            // process form highest upwards
                            processBlockNumber = CrawlerStateDat.Instance.TransactionCrawler.HighestBlock + 1;
                        }
                        else if (CrawlerStateDat.Instance.TransactionCrawler.LowestBlock > 1)
                        {
                            // process from lowest downwards
                            processBlockNumber = CrawlerStateDat.Instance.TransactionCrawler.LowestBlock - 1;
                        }
                        else
                        {
                            // nothing to process, all completed
                            processBlockNumber = 0;
                            IsCompleted = true;
                        }
                    }

                    if (processBlockNumber > 0)
                    {
                        try
                        {
                            var apiclient = new ZilliqaClient();
                            var blockTransactions = await apiclient.GetTxnBodiesForTxBlock(processBlockNumber);
                            foreach (var apiTransaction in blockTransactions)
                            {
                                var transactionModel = MapTransaction(processBlockNumber, apiTransaction);
                                dbTableTransaction.AddRecord(transactionModel);
                            }

                            if (CrawlerStateDat.Instance.TransactionCrawler.HighestBlock < processBlockNumber)
                            {
                                CrawlerStateDat.Instance.TransactionCrawler.HighestBlock = processBlockNumber;
                            }
                            if (CrawlerStateDat.Instance.TransactionCrawler.LowestBlock > processBlockNumber ||
                                CrawlerStateDat.Instance.TransactionCrawler.LowestBlock == 0)
                            {
                                CrawlerStateDat.Instance.TransactionCrawler.LowestBlock = processBlockNumber;
                            }
                            CrawlerStateDat.Instance.Save();
                            SetNumberOfBlocksProcessed();

                            loopDelay = 10;
                        }
                        catch (Exception e)
                        {
                            // logging !
                            Debug.WriteLine(e.Message);
                            throw;
                        }
                    }
                }
                await Task.Delay(loopDelay, cancellationToken);
            }
        }

        private DbModel.Transaction MapTransaction(int blockNumber, ApiModel.Transaction source)
        {
            var model = source.MapToModel<ApiModel.Transaction, DbModel.Transaction>();
            model.BlockNumber = blockNumber;
            return model;
        }

        private async Task BlocksCrawlerJob(int startupDelaySeconds, CancellationToken cancellationToken)
        {
            await Task.Delay(startupDelaySeconds * 1000, cancellationToken);
            while (!cancellationToken.IsCancellationRequested)
            {
                var dbTableBlock = RepositoryManager.Instance.ZilliqaBlockchainDbRepository.Database
                    .GetTable<DbModel.Block>();

                var newestBlock = NumberOfBlocksOnChain;
                int loopDelay = 5000;
                if (newestBlock > 0)
                {
                    var processBlockNumber = newestBlock;
                    if (CrawlerStateDat.Instance.BlockCrawler.HighestBlock > 0)
                    {
                        if (CrawlerStateDat.Instance.BlockCrawler.HighestBlock < newestBlock)
                        {
                            // process form highest upwards
                            processBlockNumber = CrawlerStateDat.Instance.BlockCrawler.HighestBlock + 1;
                        }
                        else if (CrawlerStateDat.Instance.BlockCrawler.LowestBlock > 1)
                        {
                            // process from lowest downwards
                            processBlockNumber = CrawlerStateDat.Instance.BlockCrawler.LowestBlock - 1;
                        }
                        else
                        {
                            // nothing to process, all completed
                            processBlockNumber = 0;
                            IsCompleted = true;
                        }
                    }

                    if (processBlockNumber > 0)
                    {
                        try
                        {
                            var apiclient = new ZilliqaClient();
                            var txBlock = await apiclient.GetTxBlock(processBlockNumber);
                            var blockModel = txBlock.MapToModel<ApiModel.TxBlock, DbModel.Block>();
                            dbTableBlock.AddRecord(blockModel);

                            if (CrawlerStateDat.Instance.BlockCrawler.HighestBlock < processBlockNumber)
                            {
                                CrawlerStateDat.Instance.BlockCrawler.HighestBlock = processBlockNumber;
                            }
                            if (CrawlerStateDat.Instance.BlockCrawler.LowestBlock > processBlockNumber ||
                                CrawlerStateDat.Instance.BlockCrawler.LowestBlock == 0)
                            {
                                CrawlerStateDat.Instance.BlockCrawler.LowestBlock = processBlockNumber;
                            }
                            CrawlerStateDat.Instance.Save();

                            loopDelay = 10;
                        }
                        catch (Exception e)
                        {
                            // logging !
                            Debug.WriteLine(e.Message);
                            throw;
                        }
                    }
                }
                await Task.Delay(loopDelay, cancellationToken);
            }
        }
    }

    public enum RunningState
    {
        Stopped = 0,
        Running = 1,
        Stopping = 2
    }
}
