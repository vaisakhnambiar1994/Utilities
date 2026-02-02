namespace Utilities.File.Generators.PDF.FastReport.Models
{
    public class TableData
    {
        public string TableName { get; set; }
        public int? NumberOfColumns { get; set; }
        public int? NumberOfRows { get; set; }
        public double ColumnWidth { get; set; }
        public double RowHeight { get; set; }
        public List<List<CellData>> Columns { get; set; }
    }
}
