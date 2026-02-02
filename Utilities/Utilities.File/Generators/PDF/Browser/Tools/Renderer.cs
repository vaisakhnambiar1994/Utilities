using Microsoft.Playwright;

namespace Utilities.File.Generators.PDF.Browser.Tools
{
    public class Renderer
    {
        private readonly BrowserProvider _provider;

        public Renderer(BrowserProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// Render from HTML
        /// </summary>
        /// <param name="htmlContent"></param>
        /// <param name="outputPath"></param>
        /// <returns></returns>
        public async Task Render(string htmlContent, string outputPath)
        {
            var page = await (await _provider.GetInstance()).NewPageAsync();
            await page.SetContentAsync(htmlContent, new PageSetContentOptions
            {
                WaitUntil = WaitUntilState.NetworkIdle
            });

            await page.WaitForSelectorAsync("body", new PageWaitForSelectorOptions
            {
                State = WaitForSelectorState.Visible
            });

            await page.PdfAsync(new PagePdfOptions
            {
                Path = outputPath,
                Format = "A4",
                PrintBackground = true
            });

            await page.CloseAsync();
        }
    }
}
