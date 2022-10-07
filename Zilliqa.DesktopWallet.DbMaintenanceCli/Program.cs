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
            Console.WriteLine($"to   DB: {targetPath}");

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

            //if (args.Any(a => a == "--create-table=FungibleToken"))
            //{
            //    CreateTableFungibleToken(sourceDatabase, targetDatabase);
            //    return;
            //}
            
            Console.WriteLine("argument command is missing");
        }

        private static void OrderTableTransaction(ZilligraphDatabase sourceDatabase, ZilligraphDatabase targetDatabase)
        {
            Console.WriteLine("Start: ordering Table 'Transaction' by Block ASC");
            // order Table Transaction by Timestamp ASC
            var sourceTable = sourceDatabase.GetTable<Transaction>();
            var targetTable = targetDatabase.GetTable<Transaction>();
            var sourceRows = sourceTable.CompressedDataFiles[0].AllRows();
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
            var printWritingInfo = true;
            var filter = new FilterQueryField(nameof(Transaction.TransactionType),
                (int)TransactionType.ContractDeployment);
            var checkTargetHasRecord = targetDbSmartContractTable.RecordCount > 0;
            var transactions = sourceDbTransactionTable.EnumerateRecords(filter).Where(t => !t.TransactionFailed);
            foreach (var transaction in transactions)
            {
                if (checkTargetHasRecord)
                {
                    var targetTableRecord =
                        targetDbSmartContractTable.FindRecord(nameof(SmartContract.DeploymentTransactionId), transaction.Id, false);
                    if (targetTableRecord?.DeploymentTransactionId == transaction.Id)
                    {
                        skippedCount++;
                        if (skippedCount % 100 == 0)
                        {
                            Console.WriteLine($"Skipped records: {skippedCount:#,##0}");
                        }

                        printWritingInfo = true;
                        continue;
                    }
                }

                if (sourceDatabase.DatabasePath != targetDatabase.DatabasePath)
                {
                    try
                    {
                        var sourceTableRecord =
                            sourceDbSmartContractTable.FindRecord(nameof(SmartContract.DeploymentTransactionId), transaction.Id, false);
                        if (sourceTableRecord?.DeploymentTransactionId == transaction.Id)
                        {
                            if (sourceTableRecord.OwnerAddress.StartsWith("0x"))
                            {
                                sourceTableRecord.OwnerAddress = sourceTableRecord.OwnerAddress.Substring(2);
                            }
                            importedCount++;
                            targetDbSmartContractTable.AddRecord(sourceTableRecord);
                            if (importedCount % 100 == 0)
                            {
                                Console.WriteLine($"Imported records from source DB: {importedCount:#,##0}");
                            }

                            printWritingInfo = true;
                            continue;
                        }
                    }
                    catch (Exception)
                    {
                        // import failed, skip import from now on
                    }
                }

                var smartContract = SmartContractModelCreator.CreateModel(transaction);
                if (smartContract != null)
                {
                    recordCount++;
                    targetDbSmartContractTable.AddRecord(smartContract);
                    if (recordCount % 100 == 0 || printWritingInfo)
                    {
                        printWritingInfo = false;
                        Console.WriteLine($"Written records: {recordCount:#,##0}");
                    }
                }
                else
                {
                    Console.WriteLine($"WARNING: could not create SmartContract model for Transaction Id: {transaction.Id}");
                }
            }

            sourceDbTransactionTable.EndBulkOperation();
            targetDbSmartContractTable.EndBulkOperation();

            Console.WriteLine($"Finished. Total Records written: {recordCount:#,##0}");
        }

        //private static void CreateTableFungibleToken(ZilligraphDatabase sourceDatabase, ZilligraphDatabase targetDatabase)
        //{
        //    Console.WriteLine("Start: creating Table 'FungibleToken'");

        //    var sourceDbTableSource = sourceDatabase.GetTable<SmartContract>();
        //    var sourceDbTableTarget = sourceDatabase.GetTable<FungibleToken>();
        //    var targetDbTableTarget = targetDatabase.GetTable<FungibleToken>();

        //    sourceDbTableSource.StartBulkOperation();
        //    targetDbTableTarget.StartBulkOperation();

        //    int recordCount = 0;
        //    int importedCount = 0;
        //    int skippedCount = 0;
        //    var printWritingInfo = true;
        //    var checkTargetHasRecord = targetDbTableTarget.RecordCount > 0;
        //    var sourceRecords = sourceDbTableSource.EnumerateAllRecords()
        //        .Where(sc => sc.ConstructorValues.Any(v => v.Vname == "decimals"));
        //    foreach (var sourceRecord in sourceRecords)
        //    {
        //        if (checkTargetHasRecord)
        //        {
        //            var targetTableRecord =
        //                targetDbTableTarget.FindRecord(nameof(FungibleToken.DeploymentTransactionId), sourceRecord.DeploymentTransactionId, false);
        //            if (targetTableRecord?.DeploymentTransactionId == sourceRecord.DeploymentTransactionId)
        //            {
        //                skippedCount++;
        //                if (skippedCount % 100 == 0)
        //                {
        //                    Console.WriteLine($"Skipped records: {skippedCount:#,##0}");
        //                }

        //                printWritingInfo = true;
        //                continue;
        //            }
        //        }

        //        if (sourceDatabase.DatabasePath != targetDatabase.DatabasePath)
        //        {
        //            try
        //            {
        //                var sourceTableRecord =
        //                    sourceDbTableTarget.FindRecord(nameof(FungibleToken.DeploymentTransactionId), sourceRecord.DeploymentTransactionId, false);
        //                if (sourceTableRecord?.DeploymentTransactionId == sourceRecord.DeploymentTransactionId)
        //                {
        //                    importedCount++;
        //                    targetDbTableTarget.AddRecord(sourceTableRecord);
        //                    if (importedCount % 100 == 0)
        //                    {
        //                        Console.WriteLine($"Imported records from source DB: {importedCount:#,##0}");
        //                    }

        //                    printWritingInfo = true;
        //                    continue;
        //                }
        //            }
        //            catch (Exception)
        //            {
        //                // import failed, skip import from now on
        //            }
        //        }

        //        //var smartContract = SmartContractModelCreator.CreateModel(sourceRecord);
        //        //if (smartContract != null)
        //        //{
        //        //    recordCount++;
        //        //    targetDbTableTarget.AddRecord(smartContract);
        //        //    if (recordCount % 100 == 0 || printWritingInfo)
        //        //    {
        //        //        printWritingInfo = false;
        //        //        Console.WriteLine($"Written records: {recordCount:#,##0}");
        //        //    }
        //        //}
        //        //else
        //        //{
        //        //    Console.WriteLine($"WARNING: could not create SmartContract model for Transaction Id: {sourceRecord.Id}");
        //        //}
        //    }

        //    sourceDbTableSource.EndBulkOperation();
        //    targetDbTableTarget.EndBulkOperation();

        //    Console.WriteLine($"Finished. Total Records written: {recordCount:#,##0}");
        //}
    }

}