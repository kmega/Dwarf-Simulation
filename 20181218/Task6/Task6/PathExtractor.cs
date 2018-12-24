using System.IO;

namespace Task6
{
    class PathExtractor
    {
        public string[] ExtractPathsToFile(string folderPath)
        {
            return Directory.GetFiles(folderPath);
        }
    }
}
