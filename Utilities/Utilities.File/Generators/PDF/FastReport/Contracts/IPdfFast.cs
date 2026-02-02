using Utilities.File.Generators.PDF.FastReport.Models;

namespace Utilities.File.Generators.PDF.FastReport.Contracts
{
    public interface IPdfFast
    {
        byte[] Generate(string template, FastPDFParameter pdfParameter);
        byte[] Generate(string template, List<FastPDFParameter> pdfParameters);
    }
}
