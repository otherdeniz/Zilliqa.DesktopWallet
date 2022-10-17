using System.ComponentModel;
using System.Drawing;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    [DetailsTitle(nameof(Icon48), nameof(Title), nameof(SubTitle))]
    public class TokenDetailsViewModel
    {
        public TokenDetailsViewModel(TokenModel model)
        {
            Model = model;
            ContractAddress = Model.SmartContractModels.Select(s => new AddressValue(s.ContractAddress))
                .LastOrDefault();
            MoreAddresses = Model.SmartContractModels.Count > 1 
                ? Model.SmartContractModels.Take(Model.SmartContractModels.Count-1).Select(s => s.ContractAddress).ToArray() 
                : new string[] {};
        }

        [Browsable(false)]
        public TokenModel Model { get; }

        [Browsable(false)]
        public Image Icon48 => Model.Icon.Icon48 ?? IconResources.CircleDotGray48;

        [Browsable(false)]
        public string Title => $"{Model.Name} ({Model.Symbol})";

        [Browsable(false)]
        public string SubTitle => $"{Model.SmartContractModels.Count} Smart Contracts";

        [DisplayName("Created")]
        [DetailsProperty]
        public string? CreatedDate => Model.CreatedDate?.ToString("g");

        [DisplayName("Contract Address")]
        [DetailsProperty]
        public AddressValue? ContractAddress { get; }

        [DisplayName("More Addresses")]
        [DetailsProperty(DetailsPropertyType.AddressList)]
        public string[] MoreAddresses { get; }

        [DetailsChildProperties("Coingecko Market Data")]
        public TokenMarketDataViewModel? CoingeckoMarketData => Model.CoinPrice != null
            ? new TokenMarketDataViewModel(Model.CoinPrice.MarketData)
            : null;

        //[DetailsGridView("Holders")]
        //public PageableLazyDataSource<ContractCallTransactionRowViewModel, Transaction> ContractTransactionsDataSource()
        //{
        //    var filter = new FilterCombination
        //    {
        //        Method = FilterQueryCombinationMethod.And,
        //        Queries = new List<IFilterQuery>
        //        {
        //            new FilterQueryField(nameof(Transaction.TransactionType), (int)TransactionType.ContractCall, cache: true),
        //            new FilterCombination
        //            {
        //                Method = FilterQueryCombinationMethod.Or,
        //                Queries = new List<IFilterQuery>
        //                {
        //                    new FilterQueryField(nameof(Transaction.SenderAddress), SmartContractModel.ContractAddress),
        //                    new FilterQueryField(nameof(Transaction.ToAddress), SmartContractModel.ContractAddress)
        //                }
        //            }
        //        }
        //    };
        //    var contractAddress = new Address(SmartContractModel.ContractAddress);
        //    var dataSource = RepositoryManager.Instance.DatabaseRepository
        //        .ReadViewModelsPaged<ContractCallTransactionRowViewModel, Transaction>(t =>
        //                new ContractCallTransactionRowViewModel(contractAddress, t),
        //            filter);
        //    return dataSource;
        //}
    }
}
