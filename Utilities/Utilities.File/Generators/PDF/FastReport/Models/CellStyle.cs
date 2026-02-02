using FastReport;
using System.Drawing;

namespace Utilities.File.Generators.PDF.FastReport.Models
{
    public class CellStyle
    {
        public string FontName { get; set; } = "OpenSans";
        public float FontSize { get; set; } = 10f;
        public bool IsBold { get; set; } = false;
        public Color? TextColor { get; set; }
        public HorzAlign HorizontalAlignment { get; set; } = HorzAlign.Center;
        public VertAlign VerticalAlignment { get; set; } = VertAlign.Center;
        public BorderLines Borders { get; set; } = BorderLines.All;
    }
}
