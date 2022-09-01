using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Zilliqa.DesktopWallet.Core.ViewModel.DataSource
{
    public class PageableDataSource<TViewModel> : IPageableDataSource 
        where TViewModel : class
    {
        private readonly int _pageSize;
        private readonly Dictionary<int, Collection<TViewModel>> _pages = new();
        private List<TViewModel>? _records;

        public PageableDataSource(int pageSize = 1000)
        {
            _pageSize = pageSize;
        }

        public event EventHandler<EventArgs>? AfterLoadCompleted;

        public event EventHandler<EventArgs>? PageCountChanged;

        public bool LoadCompleted { get; private set; }

        public Type ViewModelType => typeof(TViewModel);

        public List<TViewModel>? Records => _records;

        public long RecordCount { get; private set; }

        public int PageSize => _pageSize;

        public int PageCount { get; private set; }

        public int CurrentPageNumber { get; private set; }

        public IList? CurrentPage { get; private set; }

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
        }

        public void ExecuteAfterLoadCompleted(Action<IPageableDataSource> action, bool executeOnWinFormsThread = false)
        {
            if (LoadCompleted)
            {
                action(this);
            }
            else
            {
                AfterLoadCompleted += (sender, args) =>
                {
                    if (executeOnWinFormsThread)
                    {
                        WinFormsSynchronisationContext.ExecuteSynchronized(() => action(this));
                    }
                    else
                    {
                        action(this);
                    }
                };
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
                if (toTop)
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
                if (oldPageCount > 0 && oldPageCount != PageCount)
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
            return pageNumber == 0 || pageNumber == PageCount
                ? new BindingList<TViewModel>(list) 
                : new Collection<TViewModel>(list);
        }
    }
}
