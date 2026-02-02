namespace Utilities.File.Readers.Contracts
{
    public interface IXMLReader
    {
        T Deserialize<T>(string xml);
    }
}
