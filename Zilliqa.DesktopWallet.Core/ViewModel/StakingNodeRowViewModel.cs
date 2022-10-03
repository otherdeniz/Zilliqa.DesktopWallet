using System.ComponentModel;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class StakingNodeRowViewModel
    {
        public static List<StakingNodeRowViewModel> CreateViewModel()
        {
            return StakingService.Instance.GetSeedNodeList()
                .Select(ssn => new StakingNodeRowViewModel(ssn))
                .OrderByDescending(ssn => ssn.StakedAmount)
                .ToList();
        }

        private AddressValue? _ssnAddress;
        private AddressValue? _commissionAddress;

        public StakingNodeRowViewModel(StakingSeedNode stakingSeedNodeModel)
        {
            StakingSeedNodeModel = stakingSeedNodeModel;
        }

        [Browsable(false)]
        public StakingSeedNode StakingSeedNodeModel { get; }

        [ColumnWidth(150)]
        public string Name => StakingSeedNodeModel.Name;

        [DisplayName("Staked")]
        [GridViewFormat("#,##0.0 ZIL")]
        public decimal StakedAmount => StakingSeedNodeModel.StakeAmount.ZilSatoshisToZil();

        [DisplayName("Commission")]
        [GridViewFormat("0.00 '%'")]
        public decimal CommissionRate => StakingSeedNodeModel.CommissionRate;

        [DisplayName("Buffered")]
        [GridViewFormat("#,##0.0 ZIL")]
        public decimal BufferedDeposit => StakingSeedNodeModel.BufferedDeposit.ZilSatoshisToZil();

        [DisplayName("Payed Rewards")]
        [GridViewFormat("#,##0.0 ZIL")]
        public decimal StakeRewards => StakingSeedNodeModel.StakeRewards.ZilSatoshisToZil();

        [DisplayName("Node Address")]
        [ColumnWidth(150)]
        public AddressValue SsnAddress => _ssnAddress ??= new AddressValue(StakingSeedNodeModel.SsnAddress);

        [DisplayName("Commission Address")]
        [ColumnWidth(150)]
        public AddressValue CommissionAddress => _commissionAddress ??= new AddressValue(StakingSeedNodeModel.CommissioningAddress);
    }
}
