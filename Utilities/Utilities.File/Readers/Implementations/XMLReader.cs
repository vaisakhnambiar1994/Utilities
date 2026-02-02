using GoetheApp.Core.Models.Exceptions;
using Utilities.File.Readers.Contracts;
using System.Xml.Serialization;

namespace Utilities.File.Readers.Implementations
{
    public class XMLReader : IXMLReader
    {
        public T Deserialize<T>(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
                throw new ApplicationException<ArgumentException>("XML input is null or empty.");

            var serializer = new XmlSerializer(typeof(T));

            using (var reader = new StringReader(xml))
            {
                var result = serializer.Deserialize(reader);
                if (result == null)
                    throw new ApplicationException<InvalidOperationException>($"Failed to deserialize XML into type {typeof(T).FullName}.");

                return (T)result;
            }
        }
    }
}
