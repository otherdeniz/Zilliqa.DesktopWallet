using Zilligraph.Database.Contract;
using Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

namespace Zilliqa.DesktopWallet.DatabaseSchema.CalculatedIndexes
{
    public class TransactionTokenTransferSender : IndexCalculatorBase<Transaction, string>
    {
        public override string? CalculateIndex(Transaction record)
        {
            if (!record.TransactionFailed && 
                DataContractCall.TryParse(record.Data, out var data))
            {
                if (data.Tag == "Transfer")
                {
                    var firstEvent = record.Receipt.EventLogs.FirstOrDefault();
                    if (firstEvent?.Eventname == "TransferSuccess")
                    {
                        return firstEvent.Params
                            .Where(p => p.Vname == "sender")
                            .Select(p => p.ResolvedValue.ToString())
                            .FirstOrDefault();
                    }
                }
            }

            return null;
        }
    }
}
