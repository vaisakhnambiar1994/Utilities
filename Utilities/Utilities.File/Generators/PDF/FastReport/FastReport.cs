using FastReport;
using System.Text;
using Utilities.File.Generators.PDF.FastReport.Contracts;
using Utilities.File.Generators.PDF.FastReport.Manager;
using Utilities.File.Generators.PDF.FastReport.Models;

namespace Utilities.File.Generators.PDF.FastReport
{
    public class FastReport : IPdfFast
    {
        public byte[] Generate(string template, FastPDFParameter pdfParameter)
        {
            using (Report report = new Report())
            {
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(template)))
                    report.Load(stream);

                var toolManager = new ToolManager(report);
                toolManager.Render(pdfParameter.Parameters, pdfParameter.Images, pdfParameter.Tables);

                report.Prepare();

                using (MemoryStream outStream = new MemoryStream())
                {
                    var pdf = new PDFSimpleExport();
                    report.Export(pdf, outStream);

                    return outStream.ToArray();
                }
            }
        }

        /// <summary>
        /// Generate multiple
        /// </summary>
        /// <param name="template"></param>
        /// <param name="pdfParameters"></param>
        /// <returns></returns>
        public byte[] Generate(string template, List<FastPDFParameter> pdfParameters)
        {
            using (Report report = new Report())
            {
                bool firstReport = true;

                foreach (var pdfParameter in pdfParameters)
                {
                    report.LoadFromString(template);

                    var toolManager = new ToolManager(report);
                    toolManager.Render(pdfParameter.Parameters, pdfParameter.Images, pdfParameter.Tables);

                    report.Prepare(!firstReport);
                    firstReport = false;
                }
                using (MemoryStream outStream = new MemoryStream())
                {
                    var pdf = new PDFSimpleExport();
                    report.Export(pdf, outStream);
                    return outStream.ToArray();
                }
            }
        }
    }
}
