using System.Collections;

namespace Zilligraph.Database.Storage.Table
{
    public class DataFileEnumerable : IEnumerable<DataRowBinary>
    {
        private readonly DataFile _dataFile;

        public DataFileEnumerable(DataFile dataFile)
        {
            _dataFile = dataFile;
        }

        public IEnumerator<DataRowBinary> GetEnumerator()
        {
            return new DataFileEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class DataFileEnumerator : IEnumerator<DataRowBinary>
        {
            private readonly DataFileEnumerable _enumerable;
            private bool _endOfFile;

            public DataFileEnumerator(DataFileEnumerable enumerable)
            {
                _enumerable = enumerable;
            }

            public bool MoveNext()
            {
                if (_endOfFile)
                {
                    return false;
                }
                var recordPoint = Current == null 
                    ? 1 
                    : Convert.ToUInt64(Current.RowPosition + 1 + Current.RowLength + 4);
                try
                {
                    Current = _enumerable._dataFile.Read(recordPoint);
                    return Current != null;
                }
                catch (Exception)
                {
                    // End of File
                    _endOfFile = true;
                    Current = null;
                    return false;
                }
            }

            public void Reset()
            {
                Current = null;
                _endOfFile = false;
            }

#pragma warning disable CS8766 //Nullability
            public DataRowBinary? Current { get; private set; }
#pragma warning restore CS8766

            object? IEnumerator.Current => Current;

            public void Dispose()
            {
                // nothing to do yet
            }
        }
    }
}
