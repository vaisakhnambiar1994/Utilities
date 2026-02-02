using Utilities.File.Generators.PDF.Drawer.Models.TemplateModels;

namespace Utilities.File.Generators.PDF.Drawer.Contracts
{
    public interface IPdfDrawer
    {
        byte[] Generate(PdfTemplate template);
        byte[] Generate(List<PdfTemplate> templates);
    }
}
