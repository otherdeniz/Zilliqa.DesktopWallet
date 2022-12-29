using Zilligraph.Database.Storage.FilterQuery;
using Zilligraph.Database.Storage.IntegrationTests.Model;
using Directory = System.IO.Directory;

namespace Zilligraph.Database.Storage.IntegrationTests
{
    [TestClass]
    public class DatabaseTableIntegrationTest
    {
        private readonly string _dbPath = Path.Combine(Path.GetTempPath(), "Zilligraph_DatabaseTableTest");

        //TODO: add new features and tests:
        // - number indexes sortable and greater/lower comperable
        // - transactions (to ensure all data is correctly written down, and to rollback uncomplete or failed data)
        //DONE: implemented, but no tests yet:
        // - CalculatedIndex
        // - add Index later after records exist and recalculate (use v1 and v2 model)
        // - ChangeNotifications to get notified on additions by filter

        [TestMethod]
        public void AddingMultipleRecords_And_SearchThem_Success()
        {
            TestCleanup();

            using (var dbTable = CreateDatabase().GetTable<SimpleRecord>())
            {
                var sourceRecords = SimpleRecord.Generate(500);

                // adding all records
                foreach (var sourceRecord in sourceRecords)
                {
                    dbTable.AddRecord(sourceRecord);
                }

                // search all matching the first "IndexedStringX"
                var valueStringX = sourceRecords[0].IndexedStringX;
                var dbResultStringX = dbTable
                    .EnumerateRecords(new FilterQueryField(nameof(SimpleRecord.IndexedStringX), valueStringX)).ToList();
                Assert.AreEqual(sourceRecords.Count, dbResultStringX.Count);

                // search all matching the first "IndexedStringA"
                var valueStringA = sourceRecords[0].IndexedStringA;
                var sourceRecordsStringA = sourceRecords.Where(r => r.IndexedStringA == valueStringA).ToList();
                var dbResultStringA = dbTable
                    .EnumerateRecords(new FilterQueryField(nameof(SimpleRecord.IndexedStringA), valueStringA)).ToList();
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
                    .EnumerateRecords(new FilterQueryField(nameof(SimpleRecord.IndexedInt32SmallRange), valueInt)).ToList();
                Assert.AreEqual(sourceRecordsInt.Count, dbResultInt.Count);
                for (int iStringA = 0; iStringA < sourceRecordsInt.Count; iStringA++)
                {
                    Assert.AreEqual(sourceRecordsInt[iStringA].IndexedInt32LargeRange, dbResultInt[iStringA].IndexedInt32LargeRange);
                    Assert.AreEqual(sourceRecordsInt[iStringA].Data, dbResultInt[iStringA].Data);
                }
            }

            TestCleanup();
        }

        [TestMethod]
        public void Resolvereferences_ParentsExist_Found()
        {
            TestCleanup();

            // Setup
            var db = CreateDatabase();
            var parentTable = db.GetTable<ParentRecord>();
            var childTable = db.GetTable<ChildRecord>();

            // Arrange
            var parents = ParentRecord.Generate(5);
            foreach (var parent in parents)
            {
                parentTable.AddRecord(parent);
            }
            var childs = ChildRecord.Generate(10, 5);
            foreach (var child in childs)
            {
                childTable.AddRecord(child);
            }

            // Assert
            foreach (var child in childs)
            {
                var childFromDb = childTable.FindRecord(nameof(ChildRecord.PrimaryKey), child.PrimaryKey);
                var parent = parents.First(p => p.PrimaryKey == child.ParentKey);
                Assert.AreEqual(parent.AnyNumber, childFromDb?.LazyParent?.Value?.AnyNumber);
                Assert.AreEqual(parent.AnyNumber, childFromDb?.Parent?.AnyNumber);
            }

            TestCleanup();
        }

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
    }
}