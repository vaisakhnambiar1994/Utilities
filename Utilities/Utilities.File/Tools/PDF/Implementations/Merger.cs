using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using Utilities.File.Tools.PDF.Contracts;

namespace Utilities.File.Tools.PDF.Implementations
{
    public class Merger : IPdfMerger
    {
        public byte[] Merge(List<byte[]> pdfParts)
        {
            using (var outputDocument = new PdfDocument())
            {
                foreach (var pdf in pdfParts)
                {
                    using (var memoryStream = new MemoryStream(pdf))
                    {
                        var inputDoc = PdfReader.Open(memoryStream, PdfDocumentOpenMode.Import);
                        for (int j = 0; j < inputDoc.PageCount; j++)
                        {
                            outputDocument.AddPage(inputDoc.Pages[j]);
                        }
                    }
                }

                using (var memoryStream = new MemoryStream())
                {
                    outputDocument.Save(memoryStream, false);
                    return memoryStream.ToArray();
                }
            }
        }
    }
}
