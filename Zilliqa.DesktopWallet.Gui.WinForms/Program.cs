using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.WebClient;

namespace Zilliqa.DesktopWallet.Gui.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] arguments)
        {
            var zilNetwork = GetArgumentValue(arguments, "network", "mainnet").ToLower();
            ZilliqaClient.UseTestnet = zilNetwork == "testnet";

            var dataPath = GetArgumentValue(arguments, "datapath", ZilliqaClient.UseTestnet ? "Testnet" : "Mainnet");
            DataPathBuilder.Setup(Path.Combine("ZilliqaDesktopWallet", dataPath));

            Logging.Setup(Path.Combine(DataPathBuilder.UserDataRoot.FullPath, "Log"));

            var webServerUrl = GetArgumentValue(arguments, "serverurl");
            if (!string.IsNullOrEmpty(webServerUrl))
            {
                RepositoryManager.Instance.WalletWebClient = new WalletWebClient(webServerUrl.TrimEnd('/'));
            }

#if !DEBUG
            var networkText = ZilliqaClient.UseTestnet ? "TESTNET" : "MAINNET";
            SingleInstance.Setup($"ZILWALLET_{networkText}");
            if (!SingleInstance.IsFirstInstance)
            {
                Logging.LogInfo("Application already running, exiting.");
                return;
            }
#endif
            if (arguments.Length == 0)
            {
                Logging.LogInfo("Startup with no arguments");
            }
            else
            {
                Logging.LogInfo($"Startup with arguments : {string.Join(",", arguments)}");
            }

            Application.ThreadException +=
                (sender, args) => Logging.LogError("Unhandled Thread Exception!", args.Exception);

            ApplicationConfiguration.Initialize();
            var mainForm = new MainForm();
#if !DEBUG
            SingleInstance.SetMainForm(mainForm);
#endif
            Application.Run(mainForm);

            StartupService.Instance.Shutdown();
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
}