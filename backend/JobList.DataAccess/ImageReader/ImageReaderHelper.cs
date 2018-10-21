using System.IO;

namespace JobList.DataAccess.ImageReader
{
    public static class ImageReaderHelper
    {
        public static byte[] ReadImage (string name)
        {
            return File.ReadAllBytes($"Images/{name}.txt");
        }
    }
}
