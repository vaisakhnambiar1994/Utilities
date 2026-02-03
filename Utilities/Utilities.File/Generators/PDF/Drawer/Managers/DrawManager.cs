using PdfSharp.Drawing;
using Utilities.File.Generators.PDF.Drawer.Contracts;
using Utilities.File.Generators.PDF.Drawer.Implementations;
using Utilities.File.Generators.PDF.Drawer.Models.ToolModels;
using Utilities.File.Generators.PDF.Drawer.Tools;

namespace Utilities.File.Generators.PDF.Drawer.Managers
{
    public class DrawManager
    {
        private IDraw _imageDraw;
        private IDraw _textDraw;
        private IDraw _lineDraw;
        private IDraw _rectangleDraw;

        public void Initialize(XGraphics graphics)
        {
            var toolManager = new ToolManager(graphics);
            _imageDraw = new ImageDraw(toolManager);
            _textDraw = new TextDraw(toolManager);
            _lineDraw = new LineDraw(toolManager);
            _rectangleDraw = new RectangleDraw(toolManager);
        }

        public void Draw(List<DrawModel> models)
        {
            _textDraw.Draw(models.Where(item => item.Type == DrawType.Text).ToList());
            _imageDraw.Draw(models.Where(item => item.Type == DrawType.Image).ToList());
            _lineDraw.Draw(models.Where(item => item.Type == DrawType.Line).ToList());
            _rectangleDraw.Draw(models.Where(item => item.Type == DrawType.Rectangle).ToList());
        }
    }
}
