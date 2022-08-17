using System.Diagnostics;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient;

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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            var zilNetwork = GetArgumentValue(arguments, "network", "mainnet");
            ZilliqaClient.UseTestnet = zilNetwork == "testnet";

            var dataPath = GetArgumentValue(arguments, "datapath", ZilliqaClient.UseTestnet ? "Testnet" : "Mainnet");
            DataPathBuilder.Setup(Path.Combine("ZilliqaDesktopWallet", dataPath));

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
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