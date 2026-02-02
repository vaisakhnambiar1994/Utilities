using GoetheApp.Core.Managers;
using Microsoft.Playwright;

namespace Utilities.File.Generators.PDF.Browser.Tools
{
    public class BrowserProvider : IAsyncDisposable
    {
        private IBrowser _browser;

        private readonly SemaphoreSlim _semaphore = new(1, 1);
        private IPlaywright _playWright;

        public async Task<IBrowserContext> GetInstance()
        {
            if (_browser != null)
                return await _browser.NewContextAsync();

            await _semaphore.WaitAsync();
            try
            {
                if (_browser == null)
                {
                    _playWright = await Playwright.CreateAsync();
                    _browser = await _playWright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = true,
                        Args = new[] { "--no-sandbox", "--disable-setuid-sandbox" },
                        ExecutablePath = ApplicationConfigurationManager.GetValue<string>(Constants.ChromiumExecutablePath)
                    });
                }
                return await _browser.NewContextAsync();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_browser != null)
                await _browser.CloseAsync();

            _playWright?.Dispose();
        }
    }
}
