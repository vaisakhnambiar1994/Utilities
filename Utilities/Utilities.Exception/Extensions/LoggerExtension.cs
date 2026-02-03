using GoetheApp.Core.Contracts;
using GoetheApp.ExceptionUtilities.Handlers.Implementations;
using GoetheApp.ExceptionUtilities.Mappers;
using GoetheApp.ExceptionUtilities.Publishers.Contracts;
using GoetheApp.ExceptionUtilities.Publishers.Implementations;

namespace GoetheApp.ExceptionUtilities.Extensions
{
    public static class LoggerExtension
    {
        public static void AddDatabaseLogger(this IServiceCollection services)
        {
            services.AddSingleton<StackTraceParser>();
            services.AddSingleton<HttpRequestParser>();
            services.AddSingleton<ApplicationExceptionHandler>();
            services.AddSingleton<DatabaseExceptionHandler>();
            services.AddSingleton<DataEventExceptionHandler>();
            services.AddSingleton<SystemExceptionHandler>();
            services.AddAutoMapper(cfg => cfg.AddProfile<ExceptionMapper>());
            services.AddSingleton<ExceptionRouter>();
            services.AddSingleton<IExceptionPublisher, ExceptionPublisher>();
            services.AddSingleton<IMiddlewareLogger, DatabaseLogger>();
            services.AddSingleton<IServiceLayerLogger, DatabaseLogger>();
        }
    }
}
