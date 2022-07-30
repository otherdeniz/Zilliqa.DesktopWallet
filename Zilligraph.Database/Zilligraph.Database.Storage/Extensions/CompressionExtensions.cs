using System.IO.Compression;
using System.Text;
using Newtonsoft.Json;

namespace Zilligraph.Database.Storage.Extensions
{
    public static class CompressionExtensions
    {
        private static readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public static TResult DecompressObjectFromStream<TResult>(this Stream compressedStream)
        {
            using (var gZipStream = new GZipStream(compressedStream, CompressionLevel.Fastest, true))
            {
                using (var reader = new StreamReader(gZipStream, Encoding.UTF8, leaveOpen: true))
                {
                    return JsonConvert.DeserializeObject<TResult>(reader.ReadToEnd(), _serializerSettings);
                }
            }
        }

        public static void CompressObjectToStream(this object item, Stream targetStream)
        {
            using (var gZipStream = new GZipStream(targetStream, CompressionLevel.Fastest, true))
            {
                using (var writer = new StreamWriter(gZipStream, Encoding.UTF8, leaveOpen: true))
                {
                    writer.Write(JsonConvert.SerializeObject(item, Formatting.None, _serializerSettings));
                }
            }
        }
    }
}
