using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Zilliqa.DesktopWallet.Core.ViewModel.DataSource
{
    public class PageableDataSource<TViewModel> : IPageableDataSource 
        where TViewModel : class
    {
        private readonly int _pageSize;
        private readonly Func<TViewModel, string, bool>? _searchFunction;
        private readonly Dictionary<int, Collection<TViewModel>> _pages = new();
        private List<TViewModel>? _records;
        private readonly List<AfterLoadCompletedAction> _afterLoadCompletedActions = new();

        public PageableDataSource(int pageSize = 1000, Func<TViewModel, string, bool>? searchFunction = null)
        {
            _pageSize = pageSize;
            _searchFunction = searchFunction;
        }

        public event EventHandler<EventArgs>? AfterLoadCompleted;

        public event EventHandler<EventArgs>? PageCountChanged;

        public bool LoadCompleted { get; private set; }

        public bool CanSearch => _searchFunction != null;

        public Type ViewModelType => typeof(TViewModel);

        public List<TViewModel>? Records => _records;

        public long RecordCount { get; private set; }

        public int PageSize => _pageSize;

        public int PageCount { get; private set; }

        public int CurrentPageNumber { get; private set; }

        public IList Search(string searchText)
        {
            if (_searchFunction == null)
            {
                throw new NotSupportedException("Search Function not provided");
            }
            if (_records == null)
            {
                throw new NotSupportedException("Records not loaded");
            }
            return _records.Where(r => _searchFunction(r, searchText)).Take(_pageSize).ToList();
        }

        public IList? CurrentPage { get; private set; }

        public void Dispose()
        {
            _records = null;
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

        public void Load(List<TViewModel> records)
        {
            _records = records;
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

        public TViewModel? GetFirstItem()
        {
            return _records?.FirstOrDefault();
        }

        public void InsertRecord(TViewModel record, bool toTop)
        {
            if (_records != null)
            {
                if (toTop || PageCount == 0)
                {
                    var page = GetPage(1);
                    page.Insert(0, record);
                    _records.Insert(0, record);
                }
                else
                {
                    var page = GetPage(PageCount);
                    page.Add(record);
                    _records.Add(record);
                }
                RefreshRecordCount();
            }
        }

        private void RefreshRecordCount()
        {
            if (_records != null)
            {
                var oldPageCount = PageCount;
                RecordCount = _records.Count;
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

        private Collection<TViewModel> CreatePage(int pageNumber)
        {
            if (_records == null) return new Collection<TViewModel>();
            var listSource = pageNumber == 1
                ? _records.AsEnumerable()
                : _records.Skip((pageNumber - 1) * _pageSize);
            var list = listSource.Take(_pageSize).ToList();
            return pageNumber == 1 || pageNumber == PageCount
                ? new BindingList<TViewModel>(list) 
                : new Collection<TViewModel>(list);
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
}
