using PdfSharp.Drawing;
using System.Text.RegularExpressions;
using Utilities.File.Generators.PDF.Drawer.Models.ToolModels;
using Utilities.File.Generators.PDF.Drawer.Tools.Contracts;

namespace Utilities.File.Generators.PDF.Drawer.Tools.Implementations
{
    public class Image : IDrawTool
    {
        private XGraphics _graphics;

        public Image(XGraphics graphics)
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
            if (field == null || string.IsNullOrEmpty(field.Value) || !Regex.IsMatch(field.Value.Trim(), @"^[a-zA-Z0-9\+/]*={0,2}$"))
                return;

            byte[] bytes = Convert.FromBase64String(field.Value);
            using (var stream = new MemoryStream(bytes))
            {
                XImage image = XImage.FromStream(stream);
                _graphics.DrawImage(image, layout.PositionX, layout.PositionY, layout.Width, layout.Height);
            }
        }
    }
}
