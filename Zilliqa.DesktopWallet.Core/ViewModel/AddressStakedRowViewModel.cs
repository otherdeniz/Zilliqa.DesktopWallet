using System.ComponentModel;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class AddressStakedRowViewModel : IDetailsLabel, IDetailsViewModel
    {
        private readonly StakingDelegatorAmount _stakingDelegatorAmount;
        private readonly StakingNodeViewModel _stakingNodeViewModel;

        public AddressStakedRowViewModel(StakingDelegatorAmount stakingDelegatorAmount)
        {
            _stakingDelegatorAmount = stakingDelegatorAmount;
            _stakingNodeViewModel = new StakingNodeViewModel(
                StakingService.Instance.GetSeedNodeList()
                    .FirstOrDefault(s => s.SsnAddress == stakingDelegatorAmount.StakingNode)
                ?? new StakingSeedNode(stakingDelegatorAmount.StakingNode));
        }

        [DisplayName("Staking Node")]
        public string StakingNode => _stakingNodeViewModel.Name;

        [DisplayName("Staked Amount")]
        [GridViewFormat("#,##0.00 ZIL")]
        public decimal StakeAmount => _stakingDelegatorAmount.StakeAmount;

        public string GetUniqueId()
        {
            return _stakingNodeViewModel.GetUniqueId();
        }

        public string GetDisplayTitle()
        {
            return _stakingNodeViewModel.GetDisplayTitle();
        }

        public object GetViewModel()
        {
            return _stakingNodeViewModel;
        }
    }
}
