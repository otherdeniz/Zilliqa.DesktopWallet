using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Data.Model;

namespace Zilliqa.DesktopWallet.Core.Services
{
    public class DisplayCurrenciesService
    {
        public static DisplayCurrenciesService Instance { get; } = new();

        private DisplayCurrenciesService()
        {
            CurrentDisplayed = SettingsFile.Instance.DisplayCurrencies;
        }

        public event EventHandler<EventArgs>? DisplayCurrenciesChanged;

        public DisplayCurrenciesModel CurrentDisplayed { get; }

        public void ChangeDisplayedCurrencies(Action<DisplayCurrenciesModel> changeDisplayAction)
        {
            changeDisplayAction(CurrentDisplayed);
            SettingsFile.Instance.Save();
            WinFormsSynchronisationContext.ExecuteSynchronized(() =>
            {
                DisplayCurrenciesChanged?.Invoke(this, EventArgs.Empty);
            });
        }
    }
}
