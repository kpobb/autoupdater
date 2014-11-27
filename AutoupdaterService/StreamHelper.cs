using System.IO;

namespace AutoupdaterService
{
    public static class StreamHelper
    {
        public static MemoryStream ConvertToStream(string filePath)
        {
            var stream = new MemoryStream();

            using (var file = File.OpenRead(filePath))
            {
                file.CopyTo(stream);
            }

            // Important
            stream.Position = 0L;

            return stream;
        }

        public static byte[] ConvertToBytes(Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);

                return memoryStream.ToArray();
            }
        }
    }
}