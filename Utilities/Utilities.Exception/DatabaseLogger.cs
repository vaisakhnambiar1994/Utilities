using AutoMapper;
using GoetheApp.Common;
using GoetheApp.Core.Contracts;
using GoetheApp.ExceptionUtilities.MetaModels.Data;
using GoetheApp.ExceptionUtilities.Models;
using GoetheApp.ExceptionUtilities.Publishers.Contracts;

namespace GoetheApp.ExceptionUtilities
{
    public class DatabaseLogger : IMiddlewareLogger, IServiceLayerLogger
    {
        private IExceptionPublisher _exceptionPublisher;
        private ExceptionRouter _router;
        private IMapper _mapper;

        public DatabaseLogger(IExceptionPublisher exceptionPublisher, ExceptionRouter router, IMapper mapper)
        {
            _exceptionPublisher = exceptionPublisher;
            _router = router;
            _mapper = mapper;

        }

        public async Task SendError(Exception exception, HttpContext context = null, string? additionalInfo = null)
        {
            var exceptionModel = _router.GetException(exception, context);
            var metaData = _mapper.Map<ExceptionModel, ExceptionMetaData>(exceptionModel);
            _exceptionPublisher.Publish(metaData, DataEventType.Create);
        }

        public async Task SendInfo(string information)
        {
            throw new NotImplementedException();
        }
    }
}
