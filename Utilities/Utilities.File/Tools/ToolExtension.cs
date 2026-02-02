using Utilities.File.Tools.PDF.Contracts;
using Utilities.File.Tools.PDF.Implementations;
using Utilities.File.Tools.Zip.Contracts;
using Utilities.File.Tools.Zip.Implementations;

namespace Utilities.File.Tools
{
    public static class ToolExtension
    {
        public static void AddFileTools(this IServiceCollection services)
        {
            services.AddScoped<IZipCompress, ZipCompress>();
            services.AddScoped<IPdfMerger, Merger>();
        }
    }
}
