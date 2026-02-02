using Utilities.File.Generators.PDF.Drawer.Models.ToolModels;

namespace Utilities.File.Generators.PDF.Drawer.Contracts
{
    public interface IDraw
    {
        void Draw(List<DrawModel> models);
    }
}
