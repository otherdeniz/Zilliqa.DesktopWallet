using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Zillifriends.Shared.Common;

namespace Zilliqa.DesktopWallet.Core
{
    public static class Logging
    {
        private static readonly Regex LogFileNameRegex =
            new Regex(@"(\d{4})-(\d{2})-(\d{2})_(\w+)\.log", RegexOptions.Compiled);
        private static readonly object LogFileLock = new();
        private static string? _loggingPath;

        public static void Setup(string loggingPath)
        {
            if (Directory.Exists(loggingPath))
            {
                //remove all files older than 30 days
                foreach (var filePath in Directory.GetFiles(loggingPath))
                {
                    try
                    {
                        var fileInfo = new FileInfo(filePath);
                        var nameMatch = LogFileNameRegex.Match(fileInfo.Name);
                        if (nameMatch.Success)
                        {
                            var fileYear = int.Parse(nameMatch.Groups[1].Value);
                            var fileMonth = int.Parse(nameMatch.Groups[2].Value);
                            var fileDay = int.Parse(nameMatch.Groups[3].Value);
                            var fileDate = new DateTime(fileYear, fileMonth, fileDay);
                            if (fileDate < DateTime.Today.AddDays(-30))
                            {
                                fileInfo.Delete();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        //skip
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(loggingPath);
            }
            _loggingPath = loggingPath;
        }

        public static void LogInfo(string message)
        {
            WriteToFile("info", $"{GetTimestamp()} - {message}");
        }

        public static void LogWarning(string message)
        {
            WriteToFile("warning", $"{GetTimestamp()} - {message}");
            LogInfo($"WARNING:{message}");
        }

        public static void LogError(string message, Exception exception, object? data = null)
        {
            var logText = $"{GetTimestamp()} - {message}{Environment.NewLine}{new ExceptionParser(exception).FullText}";
            if (data != null)
            {
                logText += Environment.NewLine + "DATA: " + JsonConvert.SerializeObject(data);
            }
            WriteToFile("error", logText);
            LogInfo($"ERROR:{message} - {exception.Message}");
        }

        private static string GetTimestamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private static void WriteToFile(string fileSufix, string message)
        {
            if (_loggingPath == null)
            {
                return;
            }

            lock (LogFileLock)
            {
                try
                {
                    var logFilePath = Path.Combine(_loggingPath, $"{DateTime.Today:yyyy-MM-dd}_{fileSufix}.log");
                    using (var fileStream = File.Open(logFilePath, FileMode.OpenOrCreate))
                    {
                        fileStream.Seek(0, SeekOrigin.End);
                        using (var writer = new StreamWriter(fileStream, Encoding.UTF8))
                        {
                            writer.WriteLine(message);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Logging failed: {e.Message}");
                }
            }
        }

    }
}
