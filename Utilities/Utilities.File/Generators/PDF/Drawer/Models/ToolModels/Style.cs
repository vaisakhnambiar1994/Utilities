using PdfSharp.Drawing;

namespace Utilities.File.Generators.PDF.Drawer.Models.ToolModels
{
    public class Style
    {
        public XPen? Pen { get; set; }
        public XBrush? Brush { get; set; }
        public XFont? Font { get; set; }
    }
}
