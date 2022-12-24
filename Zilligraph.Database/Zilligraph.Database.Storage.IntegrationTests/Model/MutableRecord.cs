using Zilligraph.Database.Contract;

namespace Zilligraph.Database.Storage.IntegrationTests.Model
{
    [TableModel(TableKind.Mutable)]
    public class MutableRecord
    {
        public static List<MutableRecord> Generate(int number)
        {
            var list = new List<MutableRecord>();

            for (int i = 0; i < number; i++)
            {
                var record = new MutableRecord
                {
                    PrimaryKey = i + 1,
                    OriginalString = RandomGenerator.RandomString(10),
                    IndexedInt32SmallRange = RandomGenerator.RandomNumber(1, 5),
                    OriginalNumber = RandomGenerator.RandomNumber(1, 100),
                    Data = RandomGenerator.RandomString(50)
                };
                record.ChangeableNumber = record.OriginalNumber;
                record.ChangeableString = record.OriginalString;
                list.Add(record);
            }
            return list;
        }

        [PrimaryKey]
        public int PrimaryKey { get; set; }

        [PropertyIndex]
        [FieldLength(10)]
        public string OriginalString { get; set; }

        [FieldLength(10)]
        public string ChangeableString { get; set; }

        [PropertyIndex]
        public int IndexedInt32SmallRange { get; set; }

        public int OriginalNumber { get; set; }

        public int ChangeableNumber { get; set; }

        [FieldLength(50)]
        public string? Data { get; set; }

    }
}
