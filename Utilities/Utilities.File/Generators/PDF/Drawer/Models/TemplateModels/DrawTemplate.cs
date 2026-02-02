namespace Utilities.File.Generators.PDF.Drawer.Models.TemplateModels
{
    public class DrawTemplate
    {
        public DrawType Type { get; set; }
        public string Index { get; set; }
        public FieldTemplate Field { get; set; } = new FieldTemplate();
        public LayoutTemplate Layout { get; set; } = new LayoutTemplate();
        public StyleTemplate Style { get; set; } = new StyleTemplate();
    }
}
