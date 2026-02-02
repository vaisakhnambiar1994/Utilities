using Utilities.File.Generators.PDF.Browser.Contracts;
using Utilities.File.Generators.PDF.Browser.Tools;

namespace Utilities.File.Generators.PDF.Browser.Extensions
{
    public static class BrowserExtension
    {
        public static void AddPdfBrowser(this IServiceCollection services)
        {
            services.AddScoped<BrowserProvider>();
            services.AddScoped<Renderer>();
            services.AddScoped<IPdfBrowser, Browser>();
        }
    }
}
