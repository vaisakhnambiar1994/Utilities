using GoetheApp.Common;
using GoetheApp.Core.Extensions;
using GoetheApp.Core.Models.Exceptions;
using GoetheApp.ExceptionUtilities.Contracts;
using GoetheApp.ExceptionUtilities.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Npgsql;
using System.Reflection;

namespace GoetheApp.ExceptionUtilities.Handlers.Implementations
{
    public class DatabaseExceptionHandler : IExceptionHandler
    {
        private StackTraceParser _stackTraceParser;
        private HttpRequestParser _requestParser;
        public DatabaseExceptionHandler(StackTraceParser stackTraceParser, HttpRequestParser requestParser)
        {
            _stackTraceParser = stackTraceParser;
            _requestParser = requestParser;
        }

        public ExceptionModel GetException(CoreException exception, HttpContext httpContext)
        {
            var stackTrace = _stackTraceParser.Parse(exception);
            var exceptionModel = new ExceptionModel
            {
                MicroServiceName = Assembly.GetEntryAssembly()?.GetName().Name,
                Category = ExceptionCategory.Database,
                ExceptionCode = exception.HResult,
                StackTrace = stackTrace,
                ErrorLineNo = stackTrace?.StackFrames?.First()?.LineNumber.ToString(),
                ErrorOccurredAt = DateTime.UtcNow,
                Request = _requestParser.Parse(httpContext?.Request)
            };

            if (exception.InnerException is DbUpdateException dbException)
            {
                exceptionModel.FaultyObject = JsonConvert.SerializeObject(dbException.Entries.Select(item => item.Entity));
                if (dbException.InnerException is PostgresException postgresException)
                {
                    exceptionModel.ErrorMessage = postgresException.Message;
                    exceptionModel.ExceptionType = postgresException.SqlState;

                    switch (postgresException.SqlState)
                    {
                        case "23505":
                            exceptionModel.Description = string.Format(ExceptionDescriptionFormat.DatabaseUniqueViolationFormat, postgresException.TableName,
                                postgresException.ColumnName, postgresException.ConstraintName);
                            break;

                        case "42703":
                            exceptionModel.Description = string.Format(ExceptionDescriptionFormat.DatabaseUndefinedColumnFormat,
                                postgresException.TableName, postgresException.SchemaName);
                            break;

                        case "23503":
                            exceptionModel.Description = string.Format(ExceptionDescriptionFormat.DatabaseForeignKeyViolationFormat,
                                postgresException.TableName, postgresException.ColumnName, postgresException.ConstraintName);
                            break;

                        case "23502":
                            exceptionModel.Description = string.Format(ExceptionDescriptionFormat.DatabaseNotNullViolationFormat,
                                postgresException.ColumnName, postgresException.TableName);
                            break;

                        case "23514":
                            exceptionModel.Description = string.Format(ExceptionDescriptionFormat.DatabaseCheckViolationFormat,
                                postgresException.ConstraintName);
                            break;

                        case "42P01":
                            exceptionModel.Description = string.Format(ExceptionDescriptionFormat.DatabaseUndefinedTableFormat,
                                postgresException.TableName);
                            break;

                        case "42601":
                            exceptionModel.Description = string.Format(ExceptionDescriptionFormat.DatabaseSyntaxErrorFormat,
                                postgresException.Position, postgresException.TableName);
                            break;

                        case "40P01":
                            exceptionModel.Description = string.Format(ExceptionDescriptionFormat.DatabaseDeadLockDetectedFormat,
                                postgresException.Detail, postgresException.Hint);
                            break;

                        default:
                            exceptionModel.Description = string.Format(ExceptionDescriptionFormat.DatabaseGenericFormat,
                                postgresException.MessageText, postgresException.Detail);
                            break;
                    }
                }
            }
            exceptionModel.StackTrace.Identifier = (exceptionModel.ExceptionType + exceptionModel.StackTrace.Identifier).GetConsistentHash();

            return exceptionModel;
        }

    }
}
