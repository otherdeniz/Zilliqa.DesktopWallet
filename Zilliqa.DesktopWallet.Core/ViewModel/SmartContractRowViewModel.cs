﻿using System.ComponentModel;
using System.Drawing;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Data.Images;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    [DetailsTitle(nameof(Icon48), nameof(ContractName), nameof(Type))]
    public class SmartContractRowViewModel : IDetailsViewModel
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

        [Browsable(false)]
        public Image Icon48 => LogoImages.Instance.GetImage(_address.Address.GetBech32()).Icon48!;

        [DetailsProperty]
        [Browsable(false)]
        [DisplayName("Contract Address")]
        public AddressValue ContractAddress => _address;

        [DetailsProperty]
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
        public string ContractName => SmartContractModel.TokenName() ?? SmartContractModel.ContractName;

        [DetailsProperty]
        [ColumnWidth(150)]
        public AddressValue Owner => _ownerAddress ??= new AddressValue(SmartContractModel.OwnerAddress);


        public string GetUniqueId()
        {
            return $"Contract-{SmartContractModel.DeploymentTransactionId}";
        }

        public string GetDisplayTitle()
        {
            return $"Contract: {SmartContractModel.DisplayName()}";
        }
    }
}
