using PdfSharp.Drawing;
using Utilities.File.Generators.PDF.Drawer.Models.ToolModels;
using Utilities.File.Generators.PDF.Drawer.Tools.Contracts;

namespace Utilities.File.Generators.PDF.Drawer.Tools.Implementations
{
    public class Rectangle : IDrawTool
    {
        private XGraphics _graphics;

        public Rectangle(XGraphics graphics)
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
            var rectangle = new XRect(layout.PositionX, layout.PositionY, layout.Width, layout.Height);
            if (style.Pen != null)
                _graphics.DrawRectangle(style.Pen, rectangle);

            if (field != null && !string.IsNullOrEmpty(field.Value))
                _graphics.DrawString(field.Value, style.Font, style.Brush, rectangle, XStringFormats.Center);
        }
    }
}
