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
        private Task? _crawlerJobTask;
        private int? _numberOfBlocks;

        private ZilliqaBlockchainCrawler()
        {
            SetNumberOfBlocksProcessed();
        }

        public RunningState RunningState { get; private set; } = RunningState.Stopped;

        public bool IsCompleted { get; private set; }

        public int NumberOfBlocksOnChain
        {
            get => _numberOfBlocks ??
                   RepositoryManager.Instance.BlockchainBrowserRepository.BlockchainInfo.NumberOfBlocks - 1;
            private set => _numberOfBlocks = value;
        }

        public int NumberOfBlocksProcessed { get; private set; }

        public void Start(int startupDelaySeconds = 5)
        {
            if (_crawlerJobTask == null)
            {
                RunningState = RunningState.Running;
                _refreshCancellationTokenSource = new CancellationTokenSource();
                _crawlerJobTask = Task.Run(async () =>
                {
                    try
                    {
                        await CrawlerJob(startupDelaySeconds, _refreshCancellationTokenSource.Token);
                    }
                    catch (Exception)
                    {
                        // logging!
                    }

                    RunningState = RunningState.Stopped;
                });
            }
        }

        public void Stop(bool wait = false)
        {
            if (RunningState != RunningState.Running) return;
            RunningState = RunningState.Stopping;
            _refreshCancellationTokenSource?.Cancel();
            _refreshCancellationTokenSource = null;
            _crawlerJobTask = null;
            if (wait)
            {
                while (RunningState != RunningState.Stopped)
                {
                    Task.Run(async () => await Task.Delay(1000)).GetAwaiter().GetResult();
                }
            }
        }

        private void SetNumberOfBlocksProcessed()
        {
            NumberOfBlocksProcessed = CrawlerStateDat.Instance.HighestBlock > 0
                ? CrawlerStateDat.Instance.HighestBlock - CrawlerStateDat.Instance.LowestBlock + 1
                : 0;
        }

        private async Task CrawlerJob(int startupDelaySeconds, CancellationToken cancellationToken)
        {
            await Task.Delay(startupDelaySeconds * 1000, cancellationToken);
            while (!cancellationToken.IsCancellationRequested)
            {
                var dbTableTransaction = RepositoryManager.Instance.ZilliqaBlockchainDbRepository.Database
                    .GetTable<DbModel.Transaction>();
                
                var newestBlock = RepositoryManager.Instance.BlockchainBrowserRepository.BlockchainInfo.NumberOfBlocks - 1;
                NumberOfBlocksOnChain = newestBlock;
                int loopDelay = 10000;
                if (newestBlock > 0)
                {
                    var processBlockNumber = newestBlock;
                    if (CrawlerStateDat.Instance.HighestBlock > 0)
                    {
                        if (CrawlerStateDat.Instance.HighestBlock < newestBlock)
                        {
                            // process form highest upwards
                            processBlockNumber = CrawlerStateDat.Instance.HighestBlock + 1;
                        }
                        else if (CrawlerStateDat.Instance.LowestBlock > 1)
                        {
                            // process from lowest downwards
                            processBlockNumber = CrawlerStateDat.Instance.LowestBlock - 1;
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
                            var blockData = await apiclient.GetTxnBodiesForTxBlock(processBlockNumber);
                            foreach (var apiTransaction in blockData)
                            {
                                var transactionModel = MapTransaction(apiTransaction);
                                dbTableTransaction.AddRecord(transactionModel);
                            }

                            if (CrawlerStateDat.Instance.HighestBlock < processBlockNumber)
                            {
                                CrawlerStateDat.Instance.HighestBlock = processBlockNumber;
                            }
                            if (CrawlerStateDat.Instance.LowestBlock > processBlockNumber ||
                                CrawlerStateDat.Instance.LowestBlock == 0)
                            {
                                CrawlerStateDat.Instance.LowestBlock = processBlockNumber;
                            }
                            CrawlerStateDat.Instance.Save();
                            SetNumberOfBlocksProcessed();

                            loopDelay = 100;
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

        private DbModel.Transaction MapTransaction(ApiModel.Transaction source)
        {
            var model = source.MapToModel<ApiModel.Transaction, DbModel.Transaction>();

            return model;
        }
    }

    public enum RunningState
    {
        Stopped = 0,
        Running = 1,
        Stopping = 2
    }
}
