using GoetheApp.Common;
using GoetheApp.Core.Extensions;
using GoetheApp.Core.Models.Exceptions;
using GoetheApp.ExceptionUtilities.Models;

namespace GoetheApp.ExceptionUtilities.Handlers.Implementations
{
    public class SystemExceptionHandler
    {
        private StackTraceParser _stackTraceParser;
        private HttpRequestParser _requestParser;

        public SystemExceptionHandler(StackTraceParser stackTraceParser, HttpRequestParser requestParser)
        {
            _stackTraceParser = stackTraceParser;
            _requestParser = requestParser;
        }

        public ExceptionModel GetException(Exception exception, HttpContext context)
        {
            var stackTrace = _stackTraceParser.Parse(exception);
            var exceptionModel = new ExceptionModel
            {
                Category = ExceptionCategory.Application,
                ErrorMessage = exception.Message,
                StackTrace = stackTrace,
                ErrorLineNo = stackTrace?.StackFrames.First()?.LineNumber.ToString(),
                ErrorOccurredAt = DateTime.UtcNow,
                Request = _requestParser.Parse(context?.Request),
                ExceptionCode = exception.HResult
            };

            switch (exception)
            {
                case NullReferenceException ex:
                    exceptionModel.ExceptionType = typeof(NullReferenceException).Name;
                    break;

                case ApplicationException<ArgumentNullException> ex:
                    exceptionModel.ExceptionType = typeof(ArgumentNullException).Name;
                    break;

                case ApplicationException<ArgumentOutOfRangeException> ex:
                    exceptionModel.ExceptionType = typeof(ArgumentOutOfRangeException).Name;
                    break;

                case ApplicationException<InvalidOperationException> ex:
                    exceptionModel.ExceptionType = typeof(InvalidOperationException).Name;
                    break;

                case ApplicationException<IOException> ex:
                    exceptionModel.ExceptionType = typeof(IOException).Name;
                    break;

                case ApplicationException<UnauthorizedAccessException> ex:
                    exceptionModel.ExceptionType = typeof(UnauthorizedAccessException).Name;
                    break;

                default:
                    exceptionModel.ExceptionType = exception.GetType().Name;
                    break;
            }
            exceptionModel.StackTrace.Identifier = (exceptionModel.ExceptionType + exceptionModel.StackTrace.Identifier).GetConsistentHash();

            return exceptionModel;
        }
    }
}
