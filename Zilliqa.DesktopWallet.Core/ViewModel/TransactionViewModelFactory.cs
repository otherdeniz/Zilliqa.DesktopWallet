using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public static class TransactionViewModelFactory
    {
        public static ZilTransactionRowViewModel? CreateZilTransactionViewModel(Address ownerAddress, Transaction record)
        {
            if (record.TransactionTypeEnum == TransactionType.Payment)
            {
                return new ZilTransactionRowViewModel(ownerAddress, record);
            }
            return null;
        }

        public static TokenTransactionRowViewModel? CreateTokenTransactionViewModel(Address ownerAddress, Transaction record)
        {
            if (record.TransactionTypeEnum == TransactionType.ContractCall
                && record.DataContractCall.Tag == "Transfer")
            {
                var tokenModel = TokenDataService.Instance.FindTokenByAddress(record.ToAddress);
                if (tokenModel != null)
                {
                    return new TokenTransactionRowViewModel(ownerAddress, record, tokenModel);

                }
            }
            return null;
        }

        public static CommonTransactionRowViewModel CreateCommonTransactionViewModel(Address ownerAddress, Transaction record)
        {
            return new CommonTransactionRowViewModel(ownerAddress, record,
                CreateZilTransactionViewModel(ownerAddress, record) as TransactionRowViewModelBase
                ?? CreateTokenTransactionViewModel(ownerAddress, record));
        }
    }
}
