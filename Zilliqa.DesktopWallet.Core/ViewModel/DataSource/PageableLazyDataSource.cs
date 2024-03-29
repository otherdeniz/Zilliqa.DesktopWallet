﻿using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using Zilligraph.Database.Storage.Result;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel.DataSource;

public class PageableLazyDataSource<TViewModel, TRecordModel> : IPageableDataSource 
    where TViewModel : class
    where TRecordModel : class, new()
{
    private readonly int _pageSize;
    private readonly Func<TViewModel, string, bool>? _searchFunction;
    private readonly Dictionary<int, Collection<TViewModel>> _pages = new();
    private PagedRecordResult<TRecordModel>? _pagedRecords;
    private Func<TRecordModel, TViewModel>? _recordToViewModelMapping;
    private readonly List<AfterLoadCompletedAction> _afterLoadCompletedActions = new();

    public PageableLazyDataSource(int pageSize = 1000, Func<TViewModel, string, bool>? searchFunction = null)
    {
        _pageSize = pageSize;
        _searchFunction = searchFunction ?? CreateSearchFunction();
    }

    public event EventHandler<EventArgs>? AfterLoadCompleted;

    public event EventHandler<EventArgs>? PageCountChanged;

    public bool LoadCompleted { get; private set; }

    public bool CanSearch => _searchFunction != null;

    public Type ViewModelType => typeof(TViewModel);

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
        if (_pagedRecords == null)
        {
            throw new NotSupportedException("Records not loaded");
        }
        if (PageCount == 0)
        {
            return new List<AfterLoadCompletedAction>();
        }
        var page1Result = GetPage(1).OfType<TViewModel>().Where(r => _searchFunction(r, searchText)).ToList();
        if (PageCount > 1)
        {
            var result = new BindableSearchResultList<TViewModel>(page1Result);
            Task.Run(() =>
            {
                try
                {
                    for (int i = 2; i <= PageCount; i++)
                    {
                        if (result.Count >= _pageSize) break;
                        var pageResult = GetPage(i).OfType<TViewModel>().Where(r => _searchFunction(r, searchText));
                        WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                        {
                            foreach (var addItem in pageResult)
                            {
                                result.Add(addItem);
                                if (result.Count >= _pageSize) break;
                            }
                        });
                    }
                }
                catch (Exception)
                {
                    // ignore
                }
                WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                {
                    result.RaiseLoadCompleted();
                });
            });
            return result;
        }
        return page1Result;
    }

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

    private Func<TViewModel, string, bool>? CreateSearchFunction()
    {
        if (ViewModelType.GetCustomAttribute(typeof(GridSearchableAttribute)) 
            is GridSearchableAttribute gridSearchableAttribute)
        {
            var searchPropertyInfo = ViewModelType.GetProperty(gridSearchableAttribute.SearchTermProperty);
            if (searchPropertyInfo != null)
            {
                return (vm, s) => searchPropertyInfo.GetValue(vm) is string stringValue 
                                  && stringValue.ToLower().Contains(s);
            }
        }
        return null;
    }

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