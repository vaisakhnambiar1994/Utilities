using FastReport;

namespace Utilities.File.Generators.PDF.FastReport.Tools
{
    public class Parameter
    {
        private Report _report;

        public Parameter(Report report)
        {
            _report = report;
        }

        public void Add(Dictionary<string, object> parameters)
        {
            var textObjects = _report.AllObjects.OfType<TextObject>();

            foreach (var param in parameters)
            {
                string target = $"[{param.Key}]";
                string replacement = param.Value?.ToString() ?? "";

                foreach (var text in textObjects)
                {
                    if (text.Text.Contains(target))
                        text.Text = text.Text.Replace(target, replacement);
                }
            }
        }
    }
}
