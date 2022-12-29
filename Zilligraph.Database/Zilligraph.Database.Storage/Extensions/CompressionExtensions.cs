using System.IO.Compression;
using System.Text;
using Newtonsoft.Json;
using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage.Extensions
{
    public static class CompressionExtensions
    {
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.None
        };

        public static TResult DecompressObjectFromStream<TResult>(this Stream compressedStream)
        {
            using (var gZipStream = new GZipStream(compressedStream, CompressionMode.Decompress, true))
            {
                using (var reader = new StreamReader(gZipStream, Encoding.UTF8, leaveOpen: true))
                {
                    return JsonConvert.DeserializeObject<TResult>(reader.ReadToEnd(), SerializerSettings)
                        ?? throw new RuntimeException("DecompressObjectFromStream has returned null on DeserializeObject");
                }
            }
        }

        public static void CompressObjectToStream(this object item, Stream targetStream)
        {
            using (var gZipStream = new GZipStream(targetStream, CompressionLevel.Fastest, true))
            {
                using (var writer = new StreamWriter(gZipStream, Encoding.UTF8, leaveOpen: true))
                {
                    writer.Write(JsonConvert.SerializeObject(item, SerializerSettings));
                }
            }
        }
    }
}
