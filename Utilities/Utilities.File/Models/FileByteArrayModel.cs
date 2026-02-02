namespace Utilities.File.Models
{
    public class FileByteArrayModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public string ContentType { get; set; }
    }
}
