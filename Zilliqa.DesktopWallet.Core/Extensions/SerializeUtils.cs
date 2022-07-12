using System.IO.Compression;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.Core.Extensions
{
    public static class SerializeUtils
    {
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            //ContractResolver = new AllPropertiesContractResolver(),
            TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
            TypeNameHandling = TypeNameHandling.Auto,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        #region XML

        public static string XmlSerializeToString(object obj)
        {
            if (obj == null)
            {
                return null;
            }

            XmlSerializer serializer = new XmlSerializer(obj.GetType());

            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, obj);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public static void XmlSerialize(object obj, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (FileStream stream = File.Open(fileName, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    serializer.Serialize(writer, obj);
                }
            }
        }

        public static T XmlDeserializeString<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                return (T)serializer.Deserialize(stream);
            }
        }

        public static byte[] Serialize(object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (GZipStream zipStream = new GZipStream(stream, CompressionMode.Compress, true))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(zipStream, obj);
                }
                return stream.ToArray();
            }
        }

        public static object Deserialize(byte[] data, bool throwExceptionOnError = false)
        {
            try
            {
                using (MemoryStream strm = new MemoryStream(data))
                {
                    using (GZipStream compressionStream = new GZipStream(strm, CompressionMode.Decompress, true))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        return formatter.Deserialize(compressionStream);
                    }
                }
            }
            catch (Exception ex)
            {
                if (throwExceptionOnError)
                {
                    throw new ApplicationException("Data Could not be Deserialized", ex);
                }
                return null;
            }
        }

        public static T Deserialize<T>(byte[] data, bool throwExceptionOnError = false)
        {
            return (T)Deserialize(data, throwExceptionOnError);
        }

        public static string EncodeBase64(object obj)
        {
            byte[] data = Serialize(obj);
            return Convert.ToBase64String(data);
        }

        public static T DecodeBase64<T>(string base64String)
        {
            byte[] data = Convert.FromBase64String(base64String);
            return Deserialize<T>(data);
        }


        //public static string DataContractSerialize<TGraph>(this TGraph graph)
        //{
        //    return DataContractSerialize(graph, typeof(TGraph));
        //}

        //public static string DataContractSerialize(this object graph, Type graphType)
        //{
        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        //DataContractSerializer serializer = new DataContractSerializer(graphType);
        //        serializer.WriteObject(stream, graph);
        //        return Encoding.UTF8.GetString(stream.ToArray());
        //    }
        //}

        //public static TGraph DataContractDeserialize<TGraph>(this string serializedGraph)
        //{
        //    return (TGraph)DataContractDeserialize(serializedGraph, typeof(TGraph));
        //}

        //public static object DataContractDeserialize(this string serializedGraph, Type graphType)
        //{
        //    if (string.IsNullOrWhiteSpace(serializedGraph))
        //    {
        //        return null;
        //    }

        //    using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(serializedGraph)))
        //    {
        //        DataContractSerializer serializer = new DataContractSerializer(graphType);
        //        return serializer.ReadObject(stream);
        //    }
        //}

        #endregion

        #region Compress / Decompress

        [Obsolete("use SerializeUtils.Compress (faster and smaller because of JSON)")]
        public static string CompressString(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            var memoryStream = new MemoryStream();
            using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
            {
                gZipStream.Write(buffer, 0, buffer.Length);
            }

            memoryStream.Position = 0;

            var compressedData = new byte[memoryStream.Length];
            memoryStream.Read(compressedData, 0, compressedData.Length);

            var gZipBuffer = new byte[compressedData.Length + 4];
            Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);
            return Convert.ToBase64String(gZipBuffer);
        }

        [Obsolete("use SerializeUtils.Decompress (faster and smaller because of JSON)")]
        public static string DecompressString(string compressedText)
        {
            byte[] gZipBuffer = Convert.FromBase64String(compressedText);
            using (var memoryStream = new MemoryStream())
            {
                int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);

                var buffer = new byte[dataLength];

                memoryStream.Position = 0;
                using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    gZipStream.Read(buffer, 0, buffer.Length);
                }

                return Encoding.UTF8.GetString(buffer);
            }
        }

        public static string Compress(this string s)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (GZipStream zipStream = new GZipStream(stream, CompressionMode.Compress))
                {
                    byte[] content = Encoding.UTF8.GetBytes(s);
                    zipStream.Write(content, 0, content.Length);
                }
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        public static async Task<string> CompressAsync(this string s)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (GZipStream zipStream = new GZipStream(stream, CompressionMode.Compress))
                {
                    byte[] content = Encoding.UTF8.GetBytes(s);
                    await zipStream.WriteAsync(content, 0, content.Length);
                }
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        public static Stream Compress(this Stream stream)
        {
            MemoryStream compressedStream = new MemoryStream();
            using (GZipStream zipStream = new GZipStream(compressedStream, CompressionMode.Compress))
            {
                stream.CopyTo(zipStream);
                compressedStream.Seek(0, SeekOrigin.Begin);
            }
            return compressedStream;
        }

        public static async Task<Stream> CompressAsync(this Stream stream)
        {
            MemoryStream compressedStream = new MemoryStream();
            using (GZipStream zipStream = new GZipStream(compressedStream, CompressionMode.Compress))
            {
                await stream.CopyToAsync(zipStream);
                compressedStream.Seek(0, SeekOrigin.Begin);
            }
            return compressedStream;
        }

        public static string Decompress(this string s)
        {
            byte[] content = Convert.FromBase64String(s);
            using (MemoryStream stream = new MemoryStream(content))
            {
                using (GZipStream zipStream = new GZipStream(stream, CompressionMode.Decompress))
                {
                    using (MemoryStream uncompressedStream = new MemoryStream())
                    {
                        zipStream.CopyTo(uncompressedStream);
                        return Convert.ToBase64String(uncompressedStream.ToArray());
                    }
                }
            }
        }

        public static async Task<string> DecompressAsync(this string s)
        {
            byte[] content = Convert.FromBase64String(s);
            using (MemoryStream stream = new MemoryStream(content))
            {
                using (GZipStream zipStream = new GZipStream(stream, CompressionMode.Decompress))
                {
                    using (MemoryStream uncompressedStream = new MemoryStream())
                    {
                        await zipStream.CopyToAsync(uncompressedStream);
                        return Convert.ToBase64String(uncompressedStream.ToArray());
                    }
                }
            }
        }

        public static Stream Decompress(this Stream stream)
        {
            using (GZipStream zipStream = new GZipStream(stream, CompressionMode.Decompress, true))
            {
                using (MemoryStream uncompressedStream = new MemoryStream())
                {
                    zipStream.CopyTo(uncompressedStream);
                    uncompressedStream.Seek(0, SeekOrigin.Begin);
                    return uncompressedStream;
                }
            }
        }

        public static async Task<Stream> DecompressAsync(this Stream stream)
        {
            using (GZipStream zipStream = new GZipStream(stream, CompressionMode.Decompress, true))
            {
                using (MemoryStream uncompressedStream = new MemoryStream())
                {
                    await zipStream.CopyToAsync(uncompressedStream);
                    uncompressedStream.Seek(0, SeekOrigin.Begin);
                    return uncompressedStream;
                }
            }
        }

        #endregion

        #region Json

        public static string SerializeEverything(this object graph)
        {
            return JsonConvert.SerializeObject(graph, _settings);
        }

        public static void SerializeToJsonStream(this object graph, Stream stream)
        {
            JsonSerializer serializer = new JsonSerializer
            {
                //ContractResolver = new AllPropertiesContractResolver(),
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.Auto,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            using (var streamWriter = new StreamWriter(stream, Encoding.UTF8, 2048, true))
            {
                serializer.Serialize(streamWriter, graph);
            }
        }

        public static TGraph DeserializeEverything<TGraph>(this string serializedGraph)
        {
            return JsonConvert.DeserializeObject<TGraph>(serializedGraph, _settings);
        }

        public static T DeserializeFromJsonStream<T>(this Stream stream)
        {
            JsonSerializer serializer = new JsonSerializer
            {
                //ContractResolver = new AllPropertiesContractResolver(),
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.Auto,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            T data;
            using (var streamReader = new StreamReader(stream, Encoding.UTF8, false, 2048, true))
            {
                data = (T)serializer.Deserialize(streamReader, typeof(T));
            }
            return data;
        }

        #endregion
    }
}
