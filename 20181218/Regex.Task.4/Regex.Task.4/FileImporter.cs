using System.IO;

namespace Task4
{
    partial class MainClass
    {
        public class FileImporter
        {
            public string[] ListOfPaths(string folderPath)
            {
                return Directory.GetFiles(folderPath);
            }
        }
    }
}
