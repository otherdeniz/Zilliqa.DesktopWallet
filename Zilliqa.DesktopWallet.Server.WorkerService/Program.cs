using Zilliqa.DesktopWallet.Server.WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<DbCrawlerWorker>();
    })
    .UseWindowsService()
    .Build();

await host.RunAsync();
