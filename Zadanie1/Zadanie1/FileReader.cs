using System.IO;

namespace Zadanie1
{
    public class FileReader
    {
        public static string ReadTextFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
