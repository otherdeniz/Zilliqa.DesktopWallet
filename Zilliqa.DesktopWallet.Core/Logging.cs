using System.Text;
using System.Text.RegularExpressions;
using Zillifriends.Shared.Common;

namespace Zilliqa.DesktopWallet.Core
{
    public static class Logging
    {
        private static readonly Regex LogFileNameRegex =
            new Regex(@"(\d{4})-(\d{2})-(\d{2})\.log", RegexOptions.Compiled);
        private static readonly object LogFileLock = new();
        private static string? LogfilePath;

        public static void Setup(string loggingPath)
        {
            var today = DateTime.Today;

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
                            if (fileDate < today.AddDays(-30))
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
            LogfilePath = Path.Combine(loggingPath, $"{today:yyyy-MM-dd}.log");
        }

        public static void LogInfo(string message)
        {
            WriteToFile($"INFO - {GetTimestamp()} - {message}");
        }

        public static void LogError(string message, Exception exception)
        {
            WriteToFile($"ERROR - {GetTimestamp()} - {message}{Environment.NewLine}{new ExceptionParser(exception).FullText}");
        }

        private static string GetTimestamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private static void WriteToFile(string message)
        {
            if (LogfilePath == null)
            {
                return;
            }

            lock (LogFileLock)
            {
                using (var fileStream = File.Open(LogfilePath, FileMode.OpenOrCreate))
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
