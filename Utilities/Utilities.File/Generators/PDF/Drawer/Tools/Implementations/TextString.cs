using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using Utilities.File.Generators.PDF.Drawer.Models.ToolModels;
using Utilities.File.Generators.PDF.Drawer.Tools.Contracts;

namespace Utilities.File.Generators.PDF.Drawer.Tools.Implementations
{
    public class TextString : IDrawTool
    {
        private XGraphics _graphics;

        public TextString(XGraphics graphics)
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
            if (field == null || string.IsNullOrEmpty(field.Value))
                return;

            XTextFormatter formatter = new XTextFormatter(_graphics);
            XRect rectangle = new XRect(layout.PositionX, layout.PositionY, layout.Width, layout.Height);

            formatter.DrawString(field.Value, style.Font, style.Brush, rectangle, XStringFormats.TopLeft);
        }
    }
}
