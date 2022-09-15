using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage;
using Zilligraph.Database.Storage.FilterQuery;
using Zilliqa.DesktopWallet.Core.ZilligraphDb;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.DbMaintenanceCli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sourceFolder = args.FirstOrDefault(a => a.StartsWith("--source-folder="));
            if (sourceFolder == null)
            {
                Console.WriteLine("arguments 'source-folder' missing");
                return;
            }
            var targetFolder = args.FirstOrDefault(a => a.StartsWith("--target-folder="));
            if (targetFolder == null)
            {
                Console.WriteLine("arguments 'target-folder' missing");
                return;
            }

            var sourcePath = sourceFolder.Substring(16);
            var targetPath = targetFolder.Substring(16);

            Console.WriteLine($"from DB: {sourcePath}");
            Console.WriteLine($"to DB: {targetPath}");
            var sourceDatabase = new ZilligraphDatabase(sourcePath);
            var targetDatabase = new ZilligraphDatabase(targetPath);

            if (args.Any(a => a == "--order-table=Transaction"))
            {
                Console.WriteLine("Start: ordering Table 'Transaction' by Block ASC");
                // order Table Transaction by Timestamp ASC
                var sourceTable = sourceDatabase.GetTable<Transaction>();
                var targetTable = targetDatabase.GetTable<Transaction>();
                var sourceRows = sourceTable.DataFiles[0].AllRows();
                var blockRecordPositions = new List<(int Block, long RowPosition)>();
                foreach (var sourceRowBinary in sourceRows)
                {
                    var blockNum = sourceRowBinary.DecompressRowObject<Transaction>().BlockNumber;
                    blockRecordPositions.Add((blockNum, sourceRowBinary.RowPosition));
                    if (blockRecordPositions.Count % 10000 == 0)
                    {
                        Console.WriteLine($"Readed for Sorting: {blockRecordPositions.Count:#,##0}");
                    }
                }
                Console.WriteLine($"Sorting {blockRecordPositions.Count:#,##0} records");
                var sortedRecords = blockRecordPositions.OrderBy(b => b.Block);
                Console.WriteLine("Begin writing records...");
                int recordCount = 0;
                sourceTable.StartBulkOperation();
                targetTable.StartBulkOperation();
                foreach (var sortedRecord in sortedRecords)
                {
                    recordCount++;
                    var readRecord = sourceTable.ReadRecord(Convert.ToUInt64(sortedRecord.RowPosition + 1), false);
                    targetTable.AddRecord(readRecord);
                    if (recordCount % 10000 == 0)
                    {
                        Console.WriteLine($"Written records: {recordCount:#,##0}");
                    }
                }
                sourceTable.EndBulkOperation();
                targetTable.EndBulkOperation();
                Console.WriteLine("Finished.");
                return;
            }

            if (args.Any(a => a == "--create-table=SmartContract"))
            {
                Console.WriteLine("Start: creating Table 'SmartContract'");

                var sourceTable = sourceDatabase.GetTable<Transaction>();
                var targetTable = targetDatabase.GetTable<SmartContract>();

                sourceTable.StartBulkOperation();
                targetTable.StartBulkOperation();

                int recordCount = 0;
                var filter = new FilterQueryField(nameof(Transaction.TransactionType),
                    (int)TransactionType.ContractDeployment);
                var transactions = sourceTable.FindRecords(filter).Where(t => !t.TransactionFailed);
                foreach (var transaction in transactions)
                {
                    var smartContract = SmartContractModelCreator.CreateModel(transaction);
                    if (smartContract != null)
                    {
                        recordCount++;
                        targetTable.AddRecord(smartContract);
                        if (recordCount % 100 == 0)
                        {
                            Console.WriteLine($"Written records: {recordCount:#,##0}");
                        }
                    }
                    else
                    {
                        throw new RuntimeException(
                            $"SmartContract could not create model for Transaction Id: {transaction.Id}");
                    }
                }
                sourceTable.EndBulkOperation();
                targetTable.EndBulkOperation();

                Console.WriteLine($"Finished. Total Records written: {recordCount:#,##0}");
                return;
            }
            Console.WriteLine("argument command is missing");
        }
    }

}