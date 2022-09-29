using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Data.Model;

namespace Zilliqa.DesktopWallet.Core.Services
{
    public class SettingsService
    {
        public static SettingsService Instance { get; } = new();

        private SettingsService()
        {
            CurrentDisplayedCurrencies = SettingsFile.Instance.DisplayCurrencies;
        }

        public event EventHandler<EventArgs>? DisplayCurrenciesChanged;

        public DisplayCurrenciesModel CurrentDisplayedCurrencies { get; }

        public void ChangeDisplayedCurrencies(Action<DisplayCurrenciesModel> changeDisplayAction)
        {
            changeDisplayAction(CurrentDisplayedCurrencies);
            SettingsFile.Instance.Save();
            WinFormsSynchronisationContext.ExecuteSynchronized(() =>
            {
                DisplayCurrenciesChanged?.Invoke(this, EventArgs.Empty);
            });
        }
    }
}
