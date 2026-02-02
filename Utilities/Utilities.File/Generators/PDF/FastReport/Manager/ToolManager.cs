using FastReport;
using Utilities.File.Generators.PDF.FastReport.Models;
using Utilities.File.Generators.PDF.FastReport.Tools;

namespace Utilities.File.Generators.PDF.FastReport.Manager
{
    public class ToolManager
    {
        private Report _report;
        private Table _table;
        private Image _image;
        private Parameter _parameter;

        public ToolManager(Report report)
        {
            _report = report;
            _table = new Table(_report);
            _parameter = new Parameter(_report);
            _image = new Image(_report);
        }

        public void Render(Dictionary<string, object> parameters, Dictionary<string, byte[]> images, List<TableData> tables)
        {
            _parameter.Add(parameters);
            _image.Add(images);
            _table.Add(tables);
        }
    }
}
