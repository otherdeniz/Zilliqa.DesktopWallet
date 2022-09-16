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
                OrderTableTransaction(sourceDatabase, targetDatabase);
                return;
            }

            if (args.Any(a => a == "--create-table=SmartContract"))
            {
                CreateTableSmartContract(sourceDatabase, targetDatabase);
                return;
            }
            Console.WriteLine("argument command is missing");
        }

        private static void OrderTableTransaction(ZilligraphDatabase sourceDatabase, ZilligraphDatabase targetDatabase)
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
        }

        private static void CreateTableSmartContract(ZilligraphDatabase sourceDatabase, ZilligraphDatabase targetDatabase)
        {
            Console.WriteLine("Start: creating Table 'SmartContract'");

            var sourceDbTransactionTable = sourceDatabase.GetTable<Transaction>();
            var sourceDbSmartContractTable = sourceDatabase.GetTable<SmartContract>();
            var targetDbSmartContractTable = targetDatabase.GetTable<SmartContract>();

            sourceDbTransactionTable.StartBulkOperation();
            targetDbSmartContractTable.StartBulkOperation();

            int recordCount = 0;
            int importedCount = 0;
            int skippedCount = 0;
            var filter = new FilterQueryField(nameof(Transaction.TransactionType),
                (int)TransactionType.ContractDeployment);
            var targetTableHasRecord = targetDbSmartContractTable.RecordCount > 0;
            var transactions = sourceDbTransactionTable.FindRecords(filter).Where(t => !t.TransactionFailed);
            var checkSourceHasRecord = sourceDatabase.DatabasePath != targetDatabase.DatabasePath;
            foreach (var transaction in transactions)
            {
                if (targetTableHasRecord)
                {
                    if (targetDbSmartContractTable.FindRecord(nameof(SmartContract.DeploymentTransactionId), transaction.Id) ==
                        null)
                    {
                        targetTableHasRecord = false;
                    }
                    else
                    {
                        skippedCount++;
                        if (skippedCount % 100 == 0)
                        {
                            Console.WriteLine($"Skipped records: {skippedCount:#,##0}");
                        }

                        continue;
                    }
                }

                if (checkSourceHasRecord)
                {
                    try
                    {
                        var sourceTableRecord =
                            sourceDbSmartContractTable.FindRecord(nameof(SmartContract.DeploymentTransactionId),
                                transaction.Id);
                        if (sourceTableRecord?.DeploymentTransactionId != transaction.Id)
                        {
                            checkSourceHasRecord = false;
                        }
                        else
                        {
                            importedCount++;
                            targetDbSmartContractTable.AddRecord(sourceTableRecord);
                            if (importedCount % 100 == 0)
                            {
                                Console.WriteLine($"Imported records from source DB: {importedCount:#,##0}");
                            }

                            continue;
                        }
                    }
                    catch (Exception)
                    {
                        // import failed, skip import from now on
                        checkSourceHasRecord = false;
                    }
                }

                var smartContract = SmartContractModelCreator.CreateModel(transaction);
                if (smartContract != null)
                {
                    recordCount++;
                    targetDbSmartContractTable.AddRecord(smartContract);
                    if (recordCount % 100 == 0)
                    {
                        Console.WriteLine($"Written records: {recordCount:#,##0}");
                    }
                }
                else
                {
                    Console.WriteLine($"CANCELING! SmartContract could not create model for Transaction Id: {transaction.Id}");
                    break;
                }
            }

            sourceDbTransactionTable.EndBulkOperation();
            targetDbSmartContractTable.EndBulkOperation();

            Console.WriteLine($"Finished. Total Records written: {recordCount:#,##0}");
        }

    }

}