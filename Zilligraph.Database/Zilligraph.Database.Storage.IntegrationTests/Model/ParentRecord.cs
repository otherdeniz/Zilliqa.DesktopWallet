using Zilligraph.Database.Contract;

namespace Zilligraph.Database.Storage.IntegrationTests.Model
{
    [TableModel(TableKind.NotMutable)]
    public class ParentRecord
    {
        public static List<ParentRecord> Generate(int number)
        {
            var list = new List<ParentRecord>();

            for (int i = 0; i < number; i++)
            {
                list.Add(new ParentRecord
                {
                    PrimaryKey = i + 1,
                    AnyNumber = RandomGenerator.RandomNumber(1, 100),
                    Data = RandomGenerator.RandomString(256)
                });
            }
            return list;
        }

        [PropertyIndex]
        public int PrimaryKey { get; set; }

        public int AnyNumber { get; set; }

        public string? Data { get; set; }

    }
}
