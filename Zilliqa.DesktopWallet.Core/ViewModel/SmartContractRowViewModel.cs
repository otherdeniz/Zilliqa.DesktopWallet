using System.ComponentModel;
using System.Drawing;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Data.Images;
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
        private Image? _logoIcon;
        private readonly AddressValue _address;

        public SmartContractRowViewModel(SmartContract smartContractModel)
        {
            SmartContractModel = smartContractModel;
            _address = new AddressValue(SmartContractModel.ContractAddress);
        }

        [Browsable(false)]
        public SmartContract SmartContractModel { get; }

        [DisplayName("Created")]
        public string DeploymentDate => _date ??= SmartContractModel.Timestamp.ToLocalTime().ToString("g");

        [DisplayName("Address")]
        public string AddressBech32Short => _contractAddress 
            ??= _address.Address.GetBech32().FromBech32ToShortReadable();

        public string Type
        {
            get
            {
                switch (SmartContractModel.SmartContractTypeEnum)
                {
                    case SmartContractType.GenericDapp:
                        return "DApp";
                    case SmartContractType.FungibleToken:
                        return "Fungible Token";
                    case SmartContractType.NonfungibleToken:
                        return "NFT";
                    case SmartContractType.DecentralisedExchange:
                        return "DEX";
                    default:
                        return "";
                }
            }
        }

        [DisplayName(" ")]
        public Image? Logo => _logoIcon 
            ??= LogoImages.Instance.GetImage(_address.Address.GetBech32()).Icon16;

        [ColumnWidth(150)]
        [DisplayName("Name")]
        public string TokenName => SmartContractModel.TokenName() ?? SmartContractModel.ContractName;

        [ColumnWidth(150)]
        public AddressValue Owner => _ownerAddress ??= new AddressValue(SmartContractModel.OwnerAddress);


    }
}
