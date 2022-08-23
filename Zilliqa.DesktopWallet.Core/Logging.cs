using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Zillifriends.Shared.Common;

namespace Zilliqa.DesktopWallet.Core
{
    public static class Logging
    {
        private static readonly Regex LogFileNameRegex =
            new Regex(@"(\d{4})-(\d{2})-(\d{2})\.log", RegexOptions.Compiled);
        private static readonly object LogFileLock = new();
        private static string? LoggingPath;

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
            LoggingPath = loggingPath;
        }

        public static void LogInfo(string message)
        {
            WriteToFile($"INFO - {GetTimestamp()} - {message}");
        }

        public static void LogError(string message, Exception exception, object? data = null)
        {
            var logText = $"ERROR - {GetTimestamp()} - {message}{Environment.NewLine}{new ExceptionParser(exception).FullText}";
            if (data != null)
            {
                logText += Environment.NewLine + "DATA: " + JsonConvert.SerializeObject(data);
            }
            WriteToFile(logText);
        }

        private static string GetTimestamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private static void WriteToFile(string message)
        {
            if (LoggingPath == null)
            {
                return;
            }

            lock (LogFileLock)
            {
                var logFilePath = Path.Combine(LoggingPath, $"{DateTime.Today:yyyy-MM-dd}.log");
                using (var fileStream = File.Open(logFilePath, FileMode.OpenOrCreate))
                {
                    fileStream.Seek(0, SeekOrigin.End);
                    using (var writer = new StreamWriter(fileStream, Encoding.UTF8))
                    {
                        writer.WriteLine(message);
                    }
                }
            }
        }

    }
}
