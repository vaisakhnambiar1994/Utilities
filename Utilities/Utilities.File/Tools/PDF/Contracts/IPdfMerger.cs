namespace Utilities.File.Tools.PDF.Contracts
{
    public interface IPdfMerger
    {
        byte[] Merge(List<byte[]> pdfParts);
    }
}
