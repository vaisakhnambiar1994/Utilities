using FastReport;

namespace Utilities.File.Generators.PDF.FastReport.Tools
{
    public class Image
    {
        private Report _report;

        public Image(Report report)
        {
            _report = report;
        }

        public void Add(Dictionary<string, byte[]> images)
        {
            foreach (var image in images)
            {
                var picture = _report.FindObject(image.Key) as PictureObject;
                if (picture != null && image.Value != null)
                    using (var stream = new MemoryStream(image.Value))
                        picture.Image = System.Drawing.Image.FromStream(stream);
            }
        }
    }
}
