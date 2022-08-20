using Zilligraph.Database.Contract;

namespace Zilligraph.Database.Storage.IntegrationTests.Model
{
    public class ChildRecord
    {
        public static List<ChildRecord> Generate(int number, int numberOfParents)
        {
            var list = new List<ChildRecord>();

            for (int i = 0; i < number; i++)
            {
                list.Add(new ChildRecord
                {
                    PrimaryKey = i + 1,
                    ParentKey = RandomGenerator.RandomNumber(1, numberOfParents),
                    AnyNumber = RandomGenerator.RandomNumber(1, 100),
                    Data = RandomGenerator.RandomString(256)
                });
            }
            return list;
        }

        [SchemaIndex]
        public int PrimaryKey { get; set; }

        public int ParentKey { get; set; }

        [SchemaReference(nameof(ParentKey), nameof(ParentRecord.PrimaryKey))]
        public LazyReference<ParentRecord>? LazyParent { get; set; }

        [SchemaReference(nameof(ParentKey), nameof(ParentRecord.PrimaryKey))]
        public ParentRecord? Parent { get; set; }

        public int AnyNumber { get; set; }

        public string? Data { get; set; }

    }
}
