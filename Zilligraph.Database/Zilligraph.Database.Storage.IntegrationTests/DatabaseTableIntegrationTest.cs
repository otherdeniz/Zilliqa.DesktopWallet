using Zilligraph.Database.Storage.FilterQuery;
using Zilligraph.Database.Storage.IntegrationTests.Model;
using Directory = System.IO.Directory;

namespace Zilligraph.Database.Storage.IntegrationTests
{
    [TestClass]
    public class DatabaseTableIntegrationTest
    {
        private readonly string _dbPath = Path.Combine(Path.GetTempPath(), "Zilligraph_DatabaseTableTest");

        private void TestCleanup()
        {
            if (Directory.Exists(_dbPath))
            {
                // we keep the root folder (for now)
                foreach (var subPath in Directory.GetDirectories(_dbPath))
                {
                    Directory.Delete(subPath, true);
                }
            }
        }

        private ZilligraphDatabase CreateDatabase()
        {
            return new ZilligraphDatabase(_dbPath);
        }

        [TestMethod]
        public void AddingMultipleRecords_And_SearchThem_Success()
        {
            TestCleanup();

            using (var dbTable = CreateDatabase().GetTable<SimpleRecord>())
            {
                var sourceRecords = SimpleRecord.Generate(2000);

                // adding all records
                foreach (var sourceRecord in sourceRecords)
                {
                    dbTable.AddRecord(sourceRecord);
                }

                // search all matching the first "IndexedStringX"
                var valueStringX = sourceRecords[0].IndexedStringX;
                var dbResultStringX = dbTable
                    .FindRecords(new FilterQueryField(nameof(SimpleRecord.IndexedStringX), valueStringX)).ToList();
                Assert.AreEqual(sourceRecords.Count, dbResultStringX.Count);

                // search all matching the first "IndexedStringA"
                var valueStringA = sourceRecords[0].IndexedStringA;
                var sourceRecordsStringA = sourceRecords.Where(r => r.IndexedStringA == valueStringA).ToList();
                var dbResultStringA = dbTable
                    .FindRecords(new FilterQueryField(nameof(SimpleRecord.IndexedStringA), valueStringA)).ToList();
                Assert.AreEqual(sourceRecordsStringA.Count, dbResultStringA.Count);
                for (int iStringA = 0; iStringA < sourceRecordsStringA.Count; iStringA++)
                {
                    Assert.AreEqual(sourceRecordsStringA[iStringA].IndexedInt32LargeRange, dbResultStringA[iStringA].IndexedInt32LargeRange);
                    Assert.AreEqual(sourceRecordsStringA[iStringA].Data, dbResultStringA[iStringA].Data);
                }

                // search all matching the first "IndexedInt32SmallRange"
                var valueInt = sourceRecords[0].IndexedInt32SmallRange;
                var sourceRecordsInt = sourceRecords.Where(r => r.IndexedInt32SmallRange == valueInt).ToList();
                var dbResultInt = dbTable
                    .FindRecords(new FilterQueryField(nameof(SimpleRecord.IndexedInt32SmallRange), valueInt)).ToList();
                Assert.AreEqual(sourceRecordsInt.Count, dbResultInt.Count);
                for (int iStringA = 0; iStringA < sourceRecordsInt.Count; iStringA++)
                {
                    Assert.AreEqual(sourceRecordsInt[iStringA].IndexedInt32LargeRange, dbResultInt[iStringA].IndexedInt32LargeRange);
                    Assert.AreEqual(sourceRecordsInt[iStringA].Data, dbResultInt[iStringA].Data);
                }
            }

            TestCleanup();
        }

    }
}