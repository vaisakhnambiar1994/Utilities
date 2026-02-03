using GoetheApp.Common;
using GoetheApp.Common.Models;
using GoetheApp.Core.Extensions;
using GoetheApp.Core.Models.Exceptions;
using GoetheApp.ExceptionUtilities.Contracts;
using GoetheApp.ExceptionUtilities.MetaModels;
using GoetheApp.ExceptionUtilities.Models;
using System.Reflection;

namespace GoetheApp.ExceptionUtilities.Handlers.Implementations
{
    public class DataEventExceptionHandler : IExceptionHandler
    {
        private StackTraceParser _stackTracePracer;
        public DataEventExceptionHandler(StackTraceParser stackTracePracer)
        {
            _stackTracePracer = stackTracePracer;
        }

        public ExceptionModel GetException(CoreException exception, HttpContext httpContext)
        {
            var exceptionModel = new ExceptionModel
            {
                Description = exception.Message,
                Category = ExceptionCategory.EventBus,
                ExceptionCode = exception.HResult,
                ErrorMessage = exception.InnerException?.Message,
                MicroServiceName = Assembly.GetEntryAssembly()?.GetName().Name,
                StackTrace = _stackTracePracer.Parse(exception),
                ErrorOccurredAt = DateTime.UtcNow
            };

            var dataEventException = exception as DataEventException;
            exceptionModel.Request = new RequestMetaData
            {
                RequestUrl = dataEventException?.Source
            };
            exceptionModel.StackTrace.Identifier = (exceptionModel.ExceptionType + exceptionModel.StackTrace.Identifier).GetConsistentHash();

            return exceptionModel;
        }
    }
}
