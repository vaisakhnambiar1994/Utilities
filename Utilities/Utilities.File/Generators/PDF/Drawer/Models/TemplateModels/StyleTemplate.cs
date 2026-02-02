namespace Utilities.File.Generators.PDF.Drawer.Models.TemplateModels
{
    public class StyleTemplate
    {
        public string FontFamily { get; set; } = "Open Sans";
        public double FontSize { get; set; } = 13;
        public string HexColor { get; set; } = "#292a2a";
        public bool Bold { get; set; }
        public bool Italic { get; set; }
        public string Alignment { get; set; } = "Left";
        public string VerticalAlignment { get; set; } = "Top";

        public double BorderWidth { get; set; }
        public string BorderColor { get; set; } = "#000000";
        public string DashStyle { get; set; } = "Solid";
        public string FillColor { get; set; } = "Transparent";

        public string ImageMode { get; set; } = "Stretch";
    }
}
