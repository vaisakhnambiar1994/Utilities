using Utilities.File.Models;

namespace Utilities.File.Tools.Zip.Contracts
{
    public interface IZipCompress
    {
        FileByteArrayModel Compress(List<FileByteArrayModel> files, string name);
    }
}
