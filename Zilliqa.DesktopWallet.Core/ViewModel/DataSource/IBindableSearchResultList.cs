namespace Zilliqa.DesktopWallet.Core.ViewModel.DataSource;

public interface IBindableSearchResultList
{
    event EventHandler<EventArgs>? LoadCompleted;
}