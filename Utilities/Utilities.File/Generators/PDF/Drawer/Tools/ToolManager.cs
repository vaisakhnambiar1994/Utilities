using GoetheApp.Core.Models.Exceptions;
using Utilities.File.Generators.PDF.Drawer.Tools.Contracts;
using Utilities.File.Generators.PDF.Drawer.Tools.Implementations;
using PdfSharp.Drawing;

namespace Utilities.File.Generators.PDF.Drawer.Tools
{
    public class ToolManager
    {
        private Rectangle _rectangle;
        private TextString _value;
        private Image _image;
        private Line _line;

        public ToolManager(XGraphics graphics)
        {
            _image = new Image(graphics);
            _rectangle = new Rectangle(graphics);
            _value = new TextString(graphics);
            _line = new Line(graphics);
        }

        public IDrawTool Tool<T>()
        {
            if (typeof(T) == typeof(Rectangle))
                return _rectangle;
            if (typeof(T) == typeof(Image))
                return _image;
            if (typeof(T) == typeof(TextString))
                return _value;
            if (typeof(T) == typeof(Line))
                return _line;

            throw new ApplicationException<InvalidCastException>("No tool found");
        }
    }
}
