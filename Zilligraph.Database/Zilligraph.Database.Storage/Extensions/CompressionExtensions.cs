using System.IO.Compression;
using System.Text;
using Newtonsoft.Json;

namespace Zilligraph.Database.Storage.Extensions
{
    public static class CompressionExtensions
    {
        public static TResult DecompressObjectFromStream<TResult>(this Stream compressedStream)
        {
            using (var gZipStream = new GZipStream(compressedStream, CompressionLevel.Fastest, true))
            {
                using (var reader = new StreamReader(gZipStream, Encoding.UTF8, leaveOpen: true))
                {
                    return JsonConvert.DeserializeObject<TResult>(reader.ReadToEnd());
                }
            }
        }

        /// <summary>
        /// The return value is the position after compression
        /// </summary>
        public static void CompressObjectToStream(this object item, Stream targetStream)
        {
            using (var gZipStream = new GZipStream(targetStream, CompressionLevel.Fastest, true))
            {
                using (var writer = new StreamWriter(gZipStream, Encoding.UTF8, leaveOpen: true))
                {
                    writer.Write(JsonConvert.SerializeObject(item, Formatting.None));
                }
            }
        }
    }
}
