using Utilities.File.Generators.PDF.Drawer.Models.ToolModels;
using Utilities.File.Generators.PDF.Drawer.Tools.Contracts;
using PdfSharp.Drawing;

namespace Utilities.File.Generators.PDF.Drawer.Tools.Implementations
{
    public class Line : IDrawTool
    {
        private XGraphics _graphics;

        public Line(XGraphics graphics)
        {
            _graphics = graphics;
        }

        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="layout"></param>
        /// <param name="style"></param>
        /// <param name="field"></param>
        public void Draw(Layout layout, Style style, Field? field = null)
        {
            _graphics.DrawLine(style.Pen, layout.PositionX, layout.PositionY, layout.PositionX + layout.Width,
                 layout.PositionY + layout.Height);
        }
    }
}
