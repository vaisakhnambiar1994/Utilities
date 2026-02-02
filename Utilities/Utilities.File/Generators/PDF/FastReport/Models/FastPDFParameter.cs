namespace Utilities.File.Generators.PDF.FastReport.Models
{
    public class FastPDFParameter
    {
        public Dictionary<string, object> Parameters { get; set; }
        public Dictionary<string, byte[]> Images { get; set; }
        public List<TableData> Tables { get; set; }
    }
}
