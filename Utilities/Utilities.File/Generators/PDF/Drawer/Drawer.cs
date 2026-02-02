using AutoMapper;
using Utilities.File.Generators.PDF.Drawer.Contracts;
using Utilities.File.Generators.PDF.Drawer.Managers;
using Utilities.File.Generators.PDF.Drawer.Models.TemplateModels;
using Utilities.File.Generators.PDF.Drawer.Models.ToolModels;
using Utilities.File.Readers.Contracts;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Utilities.File.Generators.PDF.Drawer
{
    internal class Drawer : IPdfDrawer
    {
        private readonly IXMLReader _xmlReader;
        private readonly DrawManager _manager;
        private readonly IMapper _mapper;

        public Drawer(DrawManager manager, IXMLReader xmlReader, IMapper mapper)
        {
            _xmlReader = xmlReader;
            _manager = manager;
            _mapper = mapper;
        }

        /// <summary>
        /// Generate from xml
        /// </summary>
        /// <param name="xml"></param>
        public byte[] Generate(PdfTemplate template)
        {
            var document = new PdfDocument();
            Initialize(document);
            var models = _mapper.Map<List<DrawTemplate>, List<DrawModel>>(template.DrawTemplates);

            _manager.Draw(models);

            return GetBytes(document);
        }

        /// <summary>
        /// Generate from xml
        /// </summary>
        /// <param name="templates"></param>
        /// <returns></returns>
        public byte[] Generate(List<PdfTemplate> templates)
        {
            var document = new PdfDocument();
            foreach (var template in templates)
            {
                Initialize(document);
                var models = _mapper.Map<List<DrawTemplate>, List<DrawModel>>(template.DrawTemplates);
                _manager.Draw(models);
            }

            return GetBytes(document);
        }

        #region Private region

        private void Initialize(PdfDocument document)
        {
            var page = document.AddPage();
            page.Size = PageSize.A4;
            page.Orientation = PageOrientation.Portrait;
            page.TrimMargins.All = 0;

            var graphics = XGraphics.FromPdfPage(page);
            _manager.Initialize(graphics);
        }

        private byte[] GetBytes(PdfDocument document)
        {
            using (var stream = new MemoryStream())
            {
                document.Save(stream, false);
                return stream.ToArray();
            }
        }

        #endregion
    }
}
