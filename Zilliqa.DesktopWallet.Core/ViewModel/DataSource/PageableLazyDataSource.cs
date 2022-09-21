using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Zilligraph.Database.Storage.Result;

namespace Zilliqa.DesktopWallet.Core.ViewModel.DataSource;

public class PageableLazyDataSource<TViewModel, TRecordModel> : IPageableDataSource 
    where TViewModel : class
    where TRecordModel : class, new()
{
    private readonly int _pageSize;
    private readonly Dictionary<int, Collection<TViewModel>> _pages = new();
    private PagedRecordResult<TRecordModel>? _pagedRecords;
    private Func<TRecordModel, TViewModel>? _recordToViewModelMapping;
    private readonly List<AfterLoadCompletedAction> _afterLoadCompletedActions = new();

    public PageableLazyDataSource(int pageSize = 1000)
    {
        _pageSize = pageSize;
    }

    public event EventHandler<EventArgs>? AfterLoadCompleted;

    public event EventHandler<EventArgs>? PageCountChanged;

    public bool LoadCompleted { get; private set; }

    public Type ViewModelType => typeof(TViewModel);

    public long RecordCount { get; private set; }

    public int PageSize => _pageSize;

    public int PageCount { get; private set; }

    public int CurrentPageNumber { get; private set; }

    public IList? CurrentPage { get; private set; }

    public void Dispose()
    {
        _pagedRecords = null;
        _pages.Clear();
        _afterLoadCompletedActions.Clear();
    }

    public IList GetPage(int pageNumber)
    {
        if (_pages.TryGetValue(pageNumber, out var existingPage))
        {
            CurrentPage = existingPage;
            CurrentPageNumber = pageNumber;
            return existingPage;
        }

        var page = CreatePage(pageNumber);
        _pages.Add(pageNumber, page);
        CurrentPage = page;
        CurrentPageNumber = pageNumber;
        return page;
    }

    private Collection<TViewModel> CreatePage(int pageNumber)
    {
        if (_pagedRecords == null || _recordToViewModelMapping == null) return new Collection<TViewModel>();
        var list = _pagedRecords.GetPage(pageNumber).Select(r => _recordToViewModelMapping(r)).ToList();
        return pageNumber == 1 || pageNumber == PageCount
            ? new BindingList<TViewModel>(list)
            : new Collection<TViewModel>(list);
    }

    public void Load(PagedRecordResult<TRecordModel> pagedRecords, Func<TRecordModel, TViewModel> recordToViewModelMapping)
    {
        _pagedRecords = pagedRecords;
        _recordToViewModelMapping = recordToViewModelMapping;
        RefreshRecordCount();
        LoadCompleted = true;
        AfterLoadCompleted?.Invoke(this, EventArgs.Empty);
        _afterLoadCompletedActions.ForEach(a =>
        {
            if (a.ExecuteOnWinFormsThread)
            {
                WinFormsSynchronisationContext.ExecuteSynchronized(() => a.Action(this));
            }
            else
            {
                a.Action(this);
            }
        });
        _afterLoadCompletedActions.Clear();
    }

    public void ExecuteAfterLoadCompleted(Action<IPageableDataSource> action, bool executeOnWinFormsThread = false)
    {
        if (LoadCompleted)
        {
            action(this);
        }
        else
        {
            _afterLoadCompletedActions.Add(new AfterLoadCompletedAction(action, executeOnWinFormsThread));
        }
    }

    //public void InsertRecord(TViewModel record, bool toTop)
    //{
    //    if (_records != null)
    //    {
    //        if (toTop)
    //        {
    //            var page = GetPage(1);
    //            page.Insert(0, record);
    //            _records.Insert(0, record);
    //        }
    //        else
    //        {
    //            var page = GetPage(PageCount);
    //            page.Add(record);
    //            _records.Add(record);
    //        }
    //        RefreshRecordCount();
    //    }
    //}

    private void RefreshRecordCount()
    {
        if (_pagedRecords != null)
        {
            var oldPageCount = PageCount;
            RecordCount = _pagedRecords.RecordCount;
            var pagesFraction = Convert.ToDecimal(RecordCount) / Convert.ToDecimal(_pageSize);
            var pageCount = Math.Floor(pagesFraction);
            if (pagesFraction > pageCount)
            {
                pageCount += 1;
            }
            PageCount = Convert.ToInt32(pageCount);
            if (LoadCompleted && oldPageCount != PageCount)
            {
                WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                    PageCountChanged?.Invoke(this, EventArgs.Empty)
                );
            }
        }
    }

    private class AfterLoadCompletedAction
    {
        public AfterLoadCompletedAction(Action<IPageableDataSource> action, bool executeOnWinFormsThread)
        {
            Action = action;
            ExecuteOnWinFormsThread = executeOnWinFormsThread;
        }

        public Action<IPageableDataSource> Action { get; }

        public bool ExecuteOnWinFormsThread { get; }
    }

}