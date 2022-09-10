using Zilligraph.Database.Storage;
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

            if (args.Any(a => a == "--order-table=Transaction"))
            {
                Console.WriteLine("Start: ordering Table 'Transaction' by Block ASC");
                Console.WriteLine($"from: {sourcePath}");
                Console.WriteLine($"to: {targetPath}");
                // order Table Transaction by Timestamp ASC
                var sourceDatabase = new ZilligraphDatabase(sourcePath);
                var targetDatabase = new ZilligraphDatabase(targetPath);
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
                var sortedRecords = blockRecordPositions.OrderBy(b => b.Block);
                int recordCount = 0;
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
                Console.WriteLine("Finished.");
                Console.Read();
                return;
            }
            Console.WriteLine("argument command is missing");
        }
    }

}