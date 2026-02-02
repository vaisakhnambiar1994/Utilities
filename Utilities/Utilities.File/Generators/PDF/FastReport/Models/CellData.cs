namespace Utilities.File.Generators.PDF.FastReport.Models
{
    public class CellData
    {
        public string? RowName { get; set; }
        public string? ColumnName { get; set; }
        public int ColumnSpan { get; set; } = 1;
        public int RowSpan { get; set; } = 1;
        public string Text { get; set; }
        public CellStyle? Style { get; set; } = new CellStyle();
    }
}
