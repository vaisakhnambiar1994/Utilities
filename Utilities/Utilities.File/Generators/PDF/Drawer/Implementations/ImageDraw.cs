using Utilities.File.Generators.PDF.Drawer.Contracts;
using Utilities.File.Generators.PDF.Drawer.Models.ToolModels;
using Utilities.File.Generators.PDF.Drawer.Tools;
using Utilities.File.Generators.PDF.Drawer.Tools.Implementations;

namespace Utilities.File.Generators.PDF.Drawer.Implementations
{
    public class ImageDraw : IDraw
    {
        private ToolManager _toolManager;

        public ImageDraw(ToolManager toolManger)
        {
            _toolManager = toolManger;
        }

        public void Draw(List<DrawModel> models)
        {
            foreach (var model in models)
                _toolManager.Tool<Image>().Draw(model.Layout, model.Style, model.Field);
        }
    }
}
