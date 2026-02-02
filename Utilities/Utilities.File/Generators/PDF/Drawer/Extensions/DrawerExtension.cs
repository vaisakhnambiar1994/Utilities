using Utilities.File.Generators.PDF.Drawer.Contracts;
using Utilities.File.Generators.PDF.Drawer.Managers;
using Utilities.File.Generators.PDF.Drawer.Mappers;
using Utilities.File.Readers.Contracts;
using Utilities.File.Readers.Implementations;

namespace Utilities.File.Generators.PDF.Drawer.Extensions
{
    public static class DrawerExtension
    {
        public static void AddPdfDrawer(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<FieldMapper>();
                cfg.AddProfile<LayoutMapper>();
                cfg.AddProfile<StyleMapper>();
                cfg.AddProfile<DrawMapper>();
            });

            services.AddScoped<IXMLReader, XMLReader>();
            services.AddScoped<DrawManager>();
            services.AddScoped<IPdfDrawer, Drawer>();
        }
    }
}
