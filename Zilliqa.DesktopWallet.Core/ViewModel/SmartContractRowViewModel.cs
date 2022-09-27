using System.ComponentModel;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class SmartContractRowViewModel
    {
        private string? _date;
        private string? _contractAddress;
        private AddressValue? _ownerAddress;

        public SmartContractRowViewModel(SmartContract smartContractModel)
        {
            SmartContractModel = smartContractModel;
        }

        [Browsable(false)]
        public SmartContract SmartContractModel { get; }

        [DisplayName("Created")]
        public string DeploymentDate => _date ??= SmartContractModel.Timestamp.ToLocalTime().ToString("g");

        public string Address => _contractAddress 
            ??= new AddressValue(SmartContractModel.ContractAddress).Address.GetBech32().FromBech32ToShortReadable();

        [ColumnWidth(100)]
        [DisplayName("Contract Name")]
        public string ContractName => SmartContractModel.ContractLibrary;

        [ColumnWidth(150)]
        [DisplayName("Token Name")]
        public string? TokenName => SmartContractModel.TokenName();

        [ColumnWidth(150)]
        public AddressValue Owner => _ownerAddress ??= new AddressValue(SmartContractModel.OwnerAddress);


    }
}
