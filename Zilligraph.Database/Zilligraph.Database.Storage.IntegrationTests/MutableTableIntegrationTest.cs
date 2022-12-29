using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage.FilterQuery;
using Zilligraph.Database.Storage.IntegrationTests.Model;

namespace Zilligraph.Database.Storage.IntegrationTests;

[TestClass]
public class MutableTableIntegrationTest
{
    private readonly string _dbPath = Path.Combine(Path.GetTempPath(), "Zilligraph_DatabaseTableTest");

    [TestMethod]
    public void AddingMultipleRecords_And_SearchThem_Success()
    {
        TestCleanup();

        using (var dbTable = CreateDatabase().GetTable<MutableRecord>())
        {
            var sourceRecords = MutableRecord.Generate(100);

            // adding all records
            foreach (var sourceRecord in sourceRecords)
            {
                dbTable.AddRecord(sourceRecord);
            }

            foreach (var iPk in new int[] {1,2,3,9})
            {
                // get original record
                var originalRecord = dbTable.FindRecord(nameof(MutableRecord.PrimaryKey), iPk)
                                     ?? throw new Exception("record not found");

                // change data and update record
                originalRecord.ChangeableString = $"CHANGED{iPk}";
                originalRecord.ChangeableNumber = 0- iPk;
                dbTable.UpdateRecord(originalRecord);

                // read modified record from db
                var modifiedRecord = dbTable.FindRecord(nameof(MutableRecord.PrimaryKey), iPk)
                                     ?? throw new Exception("record not found");

                Assert.AreEqual(originalRecord.OriginalString, modifiedRecord.OriginalString);
                Assert.AreEqual(originalRecord.Data, modifiedRecord.Data);
                Assert.AreEqual(originalRecord.ChangeableString, modifiedRecord.ChangeableString);
                Assert.AreEqual(originalRecord.ChangeableNumber, modifiedRecord.ChangeableNumber);
            }
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