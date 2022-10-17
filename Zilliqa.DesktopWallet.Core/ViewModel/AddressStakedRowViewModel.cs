using System.ComponentModel;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class AddressStakedRowViewModel : IDetailsLabel, IDetailsViewModel
    {
        private readonly StakingDelegatorAmount _stakingDelegatorAmount;
        private readonly StakingDelegatorAmount? _unclaimedRewardAmount;
        private readonly StakingNodeViewModel _stakingNodeViewModel;

        public AddressStakedRowViewModel(StakingDelegatorAmount stakingDelegatorAmount, 
            StakingDelegatorAmount? unclaimedRewardAmount)
        {
            _stakingDelegatorAmount = stakingDelegatorAmount;
            _unclaimedRewardAmount = unclaimedRewardAmount;
            _stakingNodeViewModel = new StakingNodeViewModel(
                StakingService.Instance.GetSeedNodeList()
                    .FirstOrDefault(s => s.SsnAddress == stakingDelegatorAmount.StakingNodeAddress)
                ?? new StakingSeedNode(stakingDelegatorAmount.StakingNodeAddress));
        }

        [Browsable(false)]
        public StakingSeedNode StakingNode => _stakingNodeViewModel.StakingSeedNodeModel;

        [DisplayName("Staking Node")]
        public string StakingNodeName => _stakingNodeViewModel.Name;

        [DisplayName("Staked Amount")]
        [GridViewFormat("#,##0.00 ZIL")]
        public decimal StakeAmount => _stakingDelegatorAmount.StakeAmount;

        [DisplayName("Unclaimed rewards")]
        [GridViewFormat("#,##0.00 ZIL")]
        [GridViewDynamicColumn(DynamicColumnCategory.Common)]
        public decimal UnclaimedRewards => _unclaimedRewardAmount?.StakeAmount ?? 0;

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
