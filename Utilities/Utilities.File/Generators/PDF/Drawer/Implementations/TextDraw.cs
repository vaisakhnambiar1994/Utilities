using Utilities.File.Generators.PDF.Drawer.Contracts;
using Utilities.File.Generators.PDF.Drawer.Models.ToolModels;
using Utilities.File.Generators.PDF.Drawer.Tools;
using Utilities.File.Generators.PDF.Drawer.Tools.Implementations;

namespace Utilities.File.Generators.PDF.Drawer.Implementations
{
    public class TextDraw : IDraw
    {
        private ToolManager _toolManger;

        public TextDraw(ToolManager toolManager)
        {
            _toolManger = toolManager;
        }

        public void Draw(List<DrawModel> models)
        {
            foreach (var model in models)
                _toolManger.Tool<TextString>().Draw(model.Layout, model.Style, model.Field);
        }
    }
}
