using Zilligraph.Database.Storage.FilterQuery;

namespace Zilligraph.Database.Storage
{
    public class DatabaseInstanceRepository<TRecordModel> : IDisposable where TRecordModel : class, new()
    {
        private readonly Stream _dataStream;
        private readonly Stream _indexStream;
        private readonly Stream _metaDataStream;

        public DatabaseInstanceRepository(Stream dataStream, Stream indexStream, Stream metaDataStream)
        {
            _dataStream = dataStream;
            _indexStream = indexStream;
            _metaDataStream = metaDataStream;
        }

        public void AddRecord(TRecordModel record)
        {
            throw new NotImplementedException("nid fertig :P");
        }

        public TRecordModel GetRecord(long recordIndex)
        {
            throw new NotImplementedException("nid fertig :P");
        }

        public List<TRecordModel> FindRecords(FilterQueryBase queryFilter)
        {
            throw new NotImplementedException("nid fertig :P");
        }

        public void Dispose()
        {
            _dataStream.Flush();
            _dataStream.Close();
            _dataStream.Dispose();

            _indexStream.Flush();
            _indexStream.Close();
            _indexStream.Dispose();

            _metaDataStream.Flush();
            _metaDataStream.Close();
            _metaDataStream.Dispose();
        }
    }
}