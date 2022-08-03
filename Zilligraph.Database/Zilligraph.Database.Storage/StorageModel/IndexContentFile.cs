namespace Zilligraph.Database.Storage.StorageModel
{
    public class IndexContentFile
    {
        private readonly string _filePath;

        public IndexContentFile(ZilligraphFieldIndex fieldIndex)
        {
            FieldIndex = fieldIndex;
            _filePath = fieldIndex.Table.PathBuilder.GetFilePath($"{fieldIndex.PropertyName}_index_content.bin");
        }

        public ZilligraphFieldIndex FieldIndex { get; }
    }
}
