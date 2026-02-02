using Utilities.File.Generators.PDF.Browser.Contracts;
using Utilities.File.Generators.PDF.Browser.Tools;
using System.Reflection;

namespace Utilities.File.Generators.PDF.Browser
{
    public class Browser : IPdfBrowser
    {
        private readonly Renderer _renderer;

        public Browser(Renderer renderer)
        {
            _renderer = renderer;
        }

        /// <summary>
        /// Generate from html
        /// </summary>
        /// <param name="html"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<byte[]> Generate(string template, string name)
        {
            var folderPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Constants.TemporaryFolder);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var filePath = Path.Combine(folderPath, name) + ".pdf";
            await _renderer.Render(template, filePath);
            byte[] bytes = File.ReadAllBytes(filePath);
            File.Delete(filePath);
            return bytes;
        }
    }
}
