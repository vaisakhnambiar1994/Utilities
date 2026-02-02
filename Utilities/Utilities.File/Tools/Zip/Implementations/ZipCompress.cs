using Utilities.File.Models;
using Utilities.File.Tools.Zip.Contracts;
using System.IO.Compression;

namespace Utilities.File.Tools.Zip.Implementations
{
    public class ZipCompress : IZipCompress
    {
        public FileByteArrayModel Compress(List<FileByteArrayModel> files, string name)
        {
            using (var compressedStream = new MemoryStream())
            {
                using (var zipArchive = new ZipArchive(compressedStream, ZipArchiveMode.Create, false))
                {
                    foreach (var file in files)
                    {
                        var zipEntry = zipArchive.CreateEntry(file.Name);
                        using (var originalFileStream = new MemoryStream(file.Data))
                        {
                            using (var zipEntryStream = zipEntry.Open())
                            {
                                originalFileStream.CopyTo(zipEntryStream);
                            }
                        }
                    }
                }
                return new FileByteArrayModel { Data = compressedStream.ToArray(), ContentType = "application/zip", Name = name };
            }
        }
    }
}
