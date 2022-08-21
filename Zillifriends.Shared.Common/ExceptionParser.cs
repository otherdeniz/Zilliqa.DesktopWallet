using System.Text;

namespace Zillifriends.Shared.Common
{
    public class ExceptionParser
    {
        private readonly Func<Exception, string>? _getStackTrace;

        public ExceptionParser(Exception exception, Func<Exception, string> getStackTrace)
            : this(exception)
        {
            _getStackTrace = getStackTrace;
        }

        public ExceptionParser(Exception exception)
        {
            Exception = exception;
            if (exception is AggregateException aggregateException
                && aggregateException.InnerExceptions.Any())
            {
                Message = aggregateException.InnerExceptions.First().Message;
            }
            else
            {
                Message = exception.Message;
            }
        }

        public Exception Exception { get; }

        public string Message { get; }

        public string FullText => GetFullText(Exception);

        public override string ToString()
        {
            return FullText;
        }

        private string GetFullText(Exception ex)
        {
            var textBuilder = new StringBuilder();
            textBuilder.AppendLine($"{ex.GetType().FullName}: {ex.Message}");
            textBuilder.AppendLine(_getStackTrace == null ? ex.StackTrace : _getStackTrace(ex));
            if (ex.InnerException != null)
            {
                textBuilder.AppendLine("----------[InnerException]----------");
                textBuilder.AppendLine(GetFullText(ex.InnerException));
            }
            return textBuilder.ToString();
        }

    }
}
