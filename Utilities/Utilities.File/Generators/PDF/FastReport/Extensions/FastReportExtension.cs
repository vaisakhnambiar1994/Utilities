using Utilities.File.Generators.PDF.FastReport.Contracts;

namespace Utilities.File.Generators.PDF.FastReport.Extensions
{
    public static class FastReportExtension
    {
        public static void AddPdfFast(this IServiceCollection services)
        {
            services.AddScoped<IPdfFast, FastReport>();
        }
    }
}
