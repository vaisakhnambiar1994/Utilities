using GoetheApp.Common;
using GoetheApp.Core.Extensions;
using GoetheApp.Core.Models.Exceptions;
using GoetheApp.ExceptionUtilities.Contracts;
using GoetheApp.ExceptionUtilities.Models;
using System.Reflection;

namespace GoetheApp.ExceptionUtilities.Handlers.Implementations
{
    public class ApplicationExceptionHandler : IExceptionHandler
    {
        private StackTraceParser _stackTracePracer;
        private HttpRequestParser _requestParser;
        public ApplicationExceptionHandler(StackTraceParser stackTracePracer, HttpRequestParser requestParser)
        {
            _stackTracePracer = stackTracePracer;
            _requestParser = requestParser;
        }
        public ExceptionModel GetException(CoreException exception, HttpContext context)
        {
            var stackTrace = _stackTracePracer.Parse(exception);
            var exceptionModel = new ExceptionModel
            {
                Category = ExceptionCategory.Application,
                Description = exception.Message,
                ErrorMessage = exception.InnerException?.Message,
                ExceptionCode = exception.HResult,
                ErrorLineNo = stackTrace?.StackFrames?.First()?.LineNumber.ToString(),
                StackTrace = stackTrace,
                Request = _requestParser.Parse(context?.Request),
                MicroServiceName = Assembly.GetEntryAssembly()?.GetName().Name,
                ErrorOccurredAt = DateTime.UtcNow
            };

            switch (exception)
            {
                case ApplicationException<NullReferenceException> ex:
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
