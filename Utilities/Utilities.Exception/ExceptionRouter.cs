using GoetheApp.Common.Models;
using GoetheApp.Core.Models.Exceptions;
using GoetheApp.ExceptionUtilities.Contracts;
using GoetheApp.ExceptionUtilities.Handlers.Implementations;
using GoetheApp.ExceptionUtilities.Models;

namespace GoetheApp.ExceptionUtilities
{
    public class ExceptionRouter
    {
        private ApplicationExceptionHandler _applicationExceptionHandler;
        private DatabaseExceptionHandler _databaseExceptionHandler;
        private DataEventExceptionHandler _dataEventExceptionHandler;
        private SystemExceptionHandler _systemExceptionHandler;

        public ExceptionRouter(ApplicationExceptionHandler applicationExceptionHandler,
            DataEventExceptionHandler dataEventExceptionHandler,
            DatabaseExceptionHandler databaseExceptionHandler,
            SystemExceptionHandler systemExceptionHandler)
        {
            _applicationExceptionHandler = applicationExceptionHandler;
            _databaseExceptionHandler = databaseExceptionHandler;
            _systemExceptionHandler = systemExceptionHandler;
            _dataEventExceptionHandler = dataEventExceptionHandler;
        }

        public ExceptionModel GetException(Exception exception, HttpContext context = null)
        {
            ExceptionModel exceptionModel;
            if (exception is CoreException coreException)
            {
                IExceptionHandler exceptionHandler;
                if (coreException is DatabaseException)
                    exceptionHandler = _databaseExceptionHandler;
                else if (coreException is DataEventException)
                    exceptionHandler = _dataEventExceptionHandler;
                else
                    exceptionHandler = _applicationExceptionHandler;

                exceptionModel = exceptionHandler.GetException(coreException, context);
            }
            else
                exceptionModel = _systemExceptionHandler.GetException(exception, context);

            return exceptionModel;
        }
    }
}
