using System.ComponentModel;
using System.Drawing;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    [DetailsTitle(nameof(Icon48), nameof(Name), nameof(Symbol))]
    public class TokenDetailsViewModel
    {
        public TokenDetailsViewModel(TokenModel model)
        {
            Model = model;
            ContractAddress = Model.SmartContractModels.Select(s => new AddressValue(s.ContractAddress))
                .FirstOrDefault();
            MoreAddresses = Model.SmartContractModels.Count > 1 
                ? Model.SmartContractModels.Skip(1).Select(s => s.ContractAddress).ToArray() 
                : new string[] {};
        }

        [Browsable(false)]
        public TokenModel Model { get; }

        [Browsable(false)]
        public Image Icon48 => Model.Icon.Icon48 ?? IconResources.CircleDotGray48;

        [Browsable(false)]
        public string Name => Model.Name;

        [Browsable(false)]
        public string Symbol => Model.Symbol;

        [DisplayName("Created")]
        [DetailsProperty]
        public string? CreatedDate => Model.CreatedDate?.ToString("g");

        [DisplayName("Contract Address")]
        [DetailsProperty]
        public AddressValue? ContractAddress { get; }

        [DisplayName("More Addresses")]
        [DetailsProperty(DetailsPropertyType.AddressList)]
        public string[] MoreAddresses { get; }

    }
}
