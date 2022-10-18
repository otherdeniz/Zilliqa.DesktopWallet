using System.ComponentModel;
using System.Drawing;
using Newtonsoft.Json.Linq;
using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage.FilterQuery;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Data.Images;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel.DataSource;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    [DetailsTitle(nameof(Icon48), nameof(ContractName), nameof(Type))]
    [GridSearchable(nameof(SearchTerm))]
    public class SmartContractViewModel : IDetailsLabel
    {
        private string? _date;
        private string? _contractAddress;
        private AddressValue? _ownerAddress;
        private Image? _logoIcon;
        private ScillaCodeValue? _scillaCodeValue;
        private readonly AddressValue _address;

        public SmartContractViewModel(SmartContract smartContractModel)
        {
            SmartContractModel = smartContractModel;
            _address = new AddressValue(SmartContractModel.ContractAddress, false);
        }

        [Browsable(false)]
        public SmartContract SmartContractModel { get; }

        [Browsable(false)]
        public Image Icon48 => LogoImages.Instance.GetImage(_address.Address.GetBech32()).Icon48!;

        [Browsable(false)]
        public string SearchTerm =>
            $"{SmartContractModel.ContractName.ToLower()}|{SmartContractModel.TokenName()?.ToLower()}|{SmartContractModel.TokenSymbol()?.ToLower()}";

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
        public AddressValue Owner => _ownerAddress ??= 
            new AddressValue(SmartContractModel.OwnerAddress);

        [Browsable(false)]
        [DetailsChildObject("Deployment Transaction")]
        public Transaction? DeploymentTransaction => SmartContractModel.DeploymentTransaction.Value;

        [Browsable(false)]
        [DetailsChildObject("Code")]
        public ScillaCodeValue Code => _scillaCodeValue ??= 
            new ScillaCodeValue(SmartContractModel.DeploymentTransaction.Value?.Code ?? "");

        [Browsable(false)]
        [DetailsChildObject("Contract Details")]
        public ContractFieldsValues ContractFieldsValues => new ContractFieldsValues(SmartContractModel);

        [DetailsGridView("Transactions")]
        public PageableLazyDataSource<ContractCallTransactionRowViewModel, Transaction> ContractTransactionsDataSource()
        {
            var filter = new FilterCombination
            {
                Method = FilterQueryCombinationMethod.And ,
                Queries = new List<IFilterQuery>
                {
                    new FilterQueryField(nameof(Transaction.TransactionType), (int)TransactionType.ContractCall, cache: true),
                    new FilterCombination
                    {
                        Method = FilterQueryCombinationMethod.Or,
                        Queries = new List<IFilterQuery>
                        {
                            new FilterQueryField(nameof(Transaction.SenderAddress), SmartContractModel.ContractAddress),
                            new FilterQueryField(nameof(Transaction.ToAddress), SmartContractModel.ContractAddress)
                        }
                    }
                }
            };
            var contractAddress = new Address(SmartContractModel.ContractAddress);
            var dataSource = RepositoryManager.Instance.DatabaseRepository
                .ReadViewModelsPaged<ContractCallTransactionRowViewModel, Transaction>(t =>
                        new ContractCallTransactionRowViewModel(contractAddress, t),
                    filter);
            return dataSource;
        }

        [Browsable(false)] 
        public bool HasHolders => Code.ScillaParser.ParseFields().Any(f => f == "balances");

        [DetailsGridView("Holders", nameof(HasHolders))]
        public PageableDataSource<AddressAmountRowViewModel> GetHolders()
        {
            var dataSource = new PageableDataSource<AddressAmountRowViewModel>();
            try
            {
                var holdersJToken = Task.Run(async () =>
                    await ZilliqaClient.DefaultInstance.GetSmartContractSubStateValue<JToken>(
                        SmartContractModel.ContractAddress, "balances")
                ).GetAwaiter().GetResult();
                if (holdersJToken != null)
                {
                    var holders = holdersJToken.Children().OfType<JProperty>()
                        .Select(p => (p.Name, SmartContractModel.AmountToDecimal(p.Value.Value<decimal>())))
                        .Where(h => h.Item2 > 0).ToList();
                    var sumAmount = holders.Any() 
                        ? holders.Sum(h => h.Item2) 
                        : 0m;
                    dataSource.Load(holders.OrderByDescending(h => h.Item2)
                        .Select(h => new AddressAmountRowViewModel(h.Name, h.Item2,
                            sumAmount > 0 ? 100m / sumAmount * h.Item2 : 0))
                        .ToList());
                }
                else
                {
                    dataSource.Load(new List<AddressAmountRowViewModel>());
                }
            }
            catch (Exception e)
            {
                Logging.LogError($"SmartContractViewModel.GetHolders() of Contract {ContractName} failed", e);
            }
            return dataSource;
        }

        public string GetUniqueId()
        {
            return SmartContractModel.ContractAddress;
        }

        public string GetDisplayTitle()
        {
            return $"Contract: {SmartContractModel.DisplayName()}";
        }
    }
}
