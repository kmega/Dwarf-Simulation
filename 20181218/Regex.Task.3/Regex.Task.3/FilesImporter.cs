using System.IO;

namespace Task3
{
    class FilesImporter
    {
        public string[] ImportAllFiles(string dirPath)
        {
            return Directory.GetFiles(dirPath);
        }
    }
}
