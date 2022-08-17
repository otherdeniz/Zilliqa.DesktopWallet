using Zilligraph.Database.Definition;

namespace Zilligraph.Database.Storage.IntegrationTests.Model
{
    public class SimpleRecord
    {
        public static List<SimpleRecord> Generate(int number)
        {
            var list = new List<SimpleRecord>();

            for (int i = 0; i < number; i++)
            {
                list.Add(new SimpleRecord
                {
                    IndexedStringX = "All_the_same",
                    IndexedStringA = $"FixPrefix_{RandomGenerator.RandomNumber(1, 5)}",
                    IndexedStringB = RandomGenerator.RandomString(50),
                    IndexedInt32SmallRange = RandomGenerator.RandomNumber(1, 5),
                    IndexedInt32LargeRange = RandomGenerator.RandomNumber(1, 500000000),
                    Data = RandomGenerator.RandomString(2048)
                });
            }
            return list;
        }

        [SchemaIndex]
        public string IndexedStringX { get; set; }

        [SchemaIndex]
        public string IndexedStringA { get; set; }

        [SchemaIndex]
        public string IndexedStringB { get; set; }

        [SchemaIndex]
        public int IndexedInt32SmallRange { get; set; }

        [SchemaIndex]
        public int IndexedInt32LargeRange { get; set; }

        public string Data { get; set; }
    }
}
