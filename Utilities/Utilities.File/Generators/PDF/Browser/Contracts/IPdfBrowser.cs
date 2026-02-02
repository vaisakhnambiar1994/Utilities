namespace Utilities.File.Generators.PDF.Browser.Contracts
{
    public interface IPdfBrowser
    {
        Task<byte[]> Generate(string template, string name);
    }
}
