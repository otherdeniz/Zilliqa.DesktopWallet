using System.Collections;

namespace Zilliqa.DesktopWallet.Core.ViewModel.DataSource;

public interface IPageableDataSource : IDisposable
{
    event EventHandler<EventArgs>? AfterLoadCompleted;
    event EventHandler<EventArgs>? PageCountChanged;

    Type ViewModelType { get; }

    long RecordCount { get; }

    int PageSize { get; }

    int PageCount { get; }

    bool LoadCompleted { get; }

    int CurrentPageNumber { get; }

    IList? CurrentPage { get; }

    IList GetPage(int pageNumber);

    void ExecuteAfterLoadCompleted(Action<IPageableDataSource> action, bool executeOnWinFormsThread = false);
}