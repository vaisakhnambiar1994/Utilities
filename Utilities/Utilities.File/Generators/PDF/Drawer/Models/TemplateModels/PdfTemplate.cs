using System.Xml.Serialization;

namespace Utilities.File.Generators.PDF.Drawer.Models.TemplateModels
{
    public class PdfTemplate
    {
        [XmlElement("DrawTemplate")]
        public List<DrawTemplate> DrawTemplates { get; set; }
    }
}
