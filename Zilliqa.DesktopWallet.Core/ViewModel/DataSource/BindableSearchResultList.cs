using System.ComponentModel;

namespace Zilliqa.DesktopWallet.Core.ViewModel.DataSource
{
    public class BindableSearchResultList<TViewModel> : BindingList<TViewModel>, IBindableSearchResultList
    {
        public BindableSearchResultList(IList<TViewModel> list)
            : base(list)
        {
        }

        public event EventHandler<EventArgs>? LoadCompleted;

        public void RaiseLoadCompleted()
        {
            LoadCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}
