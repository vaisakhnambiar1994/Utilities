using Utilities.File.Generators.PDF.Drawer.Models.ToolModels;

namespace Utilities.File.Generators.PDF.Drawer.Tools.Contracts
{
    public interface IDrawTool
    {
        void Draw(Layout layout, Style style, Field? field = null);
    }
}
