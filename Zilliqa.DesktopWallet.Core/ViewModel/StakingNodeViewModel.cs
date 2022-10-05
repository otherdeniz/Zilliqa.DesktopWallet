﻿using System.ComponentModel;
using System.Drawing;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    [DetailsTitle(nameof(Icon48), nameof(Name), nameof(ApiUrl))]
    public class StakingNodeViewModel : IDetailsLabel
    {
        public static List<StakingNodeViewModel> CreateViewModel()
        {
            return StakingService.Instance.GetSeedNodeList()
                .Select(ssn => new StakingNodeViewModel(ssn))
                .OrderByDescending(ssn => ssn.StakedAmount)
                .ToList();
        }

        private AddressValue? _ssnAddress;
        private AddressValue? _commissionAddress;

        public StakingNodeViewModel(StakingSeedNode stakingSeedNodeModel)
        {
            StakingSeedNodeModel = stakingSeedNodeModel;
        }

        [Browsable(false)]
        public StakingSeedNode StakingSeedNodeModel { get; }

        [Browsable(false)]
        public Image Icon48 => IconResources.StakingNode48;

        [ColumnWidth(150)]
        public string Name => StakingSeedNodeModel.Name;

        [DetailsProperty]
        [Browsable(false)]
        [DisplayName("API URL")]
        public string ApiUrl => StakingSeedNodeModel.ApiUrl;

        [DetailsProperty]
        [Browsable(false)]
        [DisplayName("Staking API URL")]
        public string StakingApiUrl => StakingSeedNodeModel.StakingApiUrl;

        [DetailsProperty]
        [DisplayName("Staked")]
        [GridViewFormat("#,##0.0 ZIL")]
        public decimal StakedAmount => StakingSeedNodeModel.StakeAmount.ZilSatoshisToZil();

        [DetailsProperty]
        [DisplayName("Commission")]
        [GridViewFormat("0.00 '%'")]
        public decimal CommissionRate => StakingSeedNodeModel.CommissionRate / 10000000;

        [DetailsProperty]
        [DisplayName("Buffered")]
        [GridViewFormat("#,##0.0 ZIL")]
        public decimal BufferedDeposit => StakingSeedNodeModel.BufferedDeposit.ZilSatoshisToZil();

        [DetailsProperty]
        [DisplayName("Payed Rewards")]
        [GridViewFormat("#,##0.0 ZIL")]
        public decimal StakeRewards => StakingSeedNodeModel.StakeRewards.ZilSatoshisToZil();

        [DetailsProperty]
        [DisplayName("Node Address")]
        [ColumnWidth(150)]
        public AddressValue SsnAddress => _ssnAddress ??= new AddressValue(StakingSeedNodeModel.SsnAddress);

        [DetailsProperty]
        [DisplayName("Commission Address")]
        [ColumnWidth(150)]
        public AddressValue CommissionAddress => _commissionAddress ??= new AddressValue(StakingSeedNodeModel.CommissioningAddress);

        public string GetUniqueId()
        {
            return $"SSN-{Name}";
        }

        public string GetDisplayTitle()
        {
            return $"Staking Seed Node: {Name}";
        }
    }
}