using System.ComponentModel;
using System.Drawing;
using Zilligraph.Database.Storage.FilterQuery;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel.DataSource;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;
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
