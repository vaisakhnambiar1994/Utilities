using FastReport;
using FastReport.Table;
using GoetheApp.Core.Models.Exceptions;
using Utilities.File.Generators.PDF.FastReport.Models;
using System.Drawing;

namespace Utilities.File.Generators.PDF.FastReport.Tools
{
    public class Table
    {
        private Report _report;

        public Table(Report report)
        {
            _report = report;
        }

        public void Add(List<TableData> tables)
        {
            foreach (var tableData in tables)
            {
                if (_report.FindObject(tableData.TableName) is TableObject table)
                {
                    if (tableData.NumberOfColumns != null)
                        for (int i = 0; i < tableData.NumberOfColumns; i++)
                            table.Columns.Add(new TableColumn { Width = (float)tableData.ColumnWidth });

                    if (tableData.NumberOfRows != null)
                        for (int i = 0; i < tableData.NumberOfRows; i++)
                            table.Rows.Add(new TableRow { Height = (float)tableData.RowHeight });

                    foreach (var rowGroup in tableData.Columns.SelectMany(item => item).GroupBy(item => item.RowName))
                    {
                        var row = table.FindObject(rowGroup.Key) as TableRow;
                        if (row == null)
                            throw new ApplicationException<NullReferenceException>($"Could not find row {rowGroup.Key}");

                        foreach (var cell in rowGroup)
                        {
                            var tableCell = new TableCell
                            {
                                Text = cell.Text,
                                Width = (float)tableData.ColumnWidth * cell.ColumnSpan,
                                Height = row.Height,
                                HorzAlign = cell.Style.HorizontalAlignment,
                                VertAlign = cell.Style.VerticalAlignment,
                                RowSpan = cell.RowSpan,
                                ColSpan = cell.ColumnSpan,
                                Font = new Font(cell.Style.FontName, cell.Style.FontSize, cell.Style.IsBold ? FontStyle.Bold : FontStyle.Regular),
                                Border = { Lines = BorderLines.All }
                            };
                            tableCell.CreateUniqueName();
                            row.AddChild(tableCell);
                        }
                    }
                }
            }
        }
    }
}
