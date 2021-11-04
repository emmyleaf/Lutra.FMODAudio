using System.IO;

namespace Lutra.FMODAudio
{
    // TODO: Make sure this works!
    public static class FileLoader
    {
        public static string RootDirectory = "";

        /// <summary>
        /// Loads file as a byte array.
        /// </summary>
        public static byte[] LoadFileAsBuffer(string path)
        {
            using var fileStream = File.OpenRead(Path.Combine(RootDirectory, path));
            using var memoryStream = new MemoryStream();

            fileStream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
