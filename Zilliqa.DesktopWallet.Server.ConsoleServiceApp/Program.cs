using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ZilligraphDb;

namespace Zilliqa.DesktopWallet.Server.ConsoleServiceApp;

internal class Program
{
    static void Main(string[] arguments)
    {
        var zilNetwork = GetArgumentValue(arguments, "network", "mainnet").ToLower();
        ZilliqaClient.UseTestnet = zilNetwork == "testnet";

        var dataPath = GetArgumentValue(arguments, "datapath", 
            ZilliqaClient.UseTestnet ? "Server-Testnet" : "Server-Mainnet");
        DataPathBuilder.Setup(Path.Combine("ZilliqaDesktopWallet", dataPath), true);

        Logging.Setup(Path.Combine(DataPathBuilder.UserDataRoot.FullPath, "Log"));
        var startupText = arguments.Length == 0
            ? "Startup with no arguments"
            : $"Startup with arguments : {string.Join(",", arguments)}";
        Logging.LogInfo(startupText);
        Console.WriteLine(startupText);

        AppDomain.CurrentDomain.UnhandledException +=
            (sender, args) => Logging.LogError("Unhandled Thread Exception!", (Exception)args.ExceptionObject);

        // Startup Services
        StartupService.Instance.Startup();
        StartupService.Instance.StatusChanged += (sender, args) =>
        {
            Console.WriteLine(args.StatusText);
        };
        while (!StartupService.Instance.StartupCompleted)
        {
            Task.Run(async () => await Task.Delay(1000)).GetAwaiter().GetResult();
        }

        Console.WriteLine("Service is running.");
        Console.WriteLine("[Press any key to shutdown]");
        Console.Read();

        // Shutdown
        Console.WriteLine("Shutdown...");
        ZilliqaBlockchainCrawler.Instance.Stop(true);
        RepositoryManager.Instance.Shutdown();

    }

    private static string GetArgumentValue(string[] arguments, string parameterName, string defaultValue = "")
    {
        var argument = arguments.FirstOrDefault(a => a.ToLower().StartsWith($"{parameterName}="));
        if (argument != null && argument.Length > parameterName.Length + 1)
        {
            return argument.Substring(parameterName.Length + 1);
        }

        return defaultValue;
    }

}