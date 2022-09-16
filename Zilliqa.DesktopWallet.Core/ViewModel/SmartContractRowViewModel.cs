using System.ComponentModel;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class SmartContractRowViewModel
    {
        private string? _contractAddress;
        private AddressValue? _ownerAddress;

        public SmartContractRowViewModel(SmartContract smartContractModel)
        {
            SmartContractModel = smartContractModel;
        }

        [Browsable(false)]
        public SmartContract SmartContractModel { get; }

        public string Address => _contractAddress 
            ??= new AddressValue(SmartContractModel.ContractAddress).Address.GetBech32().FromBech32ToShortReadable();

        public string Contract => SmartContractModel.ContractName;

        public string? Name => SmartContractModel.GetConstructorValue("name");

        [ColumnWidth(150)]
        public AddressValue Owner => _ownerAddress ??= new AddressValue(SmartContractModel.OwnerAddress);


    }
}
