using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HappyPathsWithTests
{
    public class FileOps
    {
        public void SaveToFile(string resultPath, string name, int time, string preForm)
        {
            StreamWriter streamWriter = new StreamWriter(resultPath);
            streamWriter.WriteLine(preForm, name, time);
            streamWriter.Close();
        }

        public string ReadSingleFile(string path)
        {
            return File.ReadAllText(path);
        }

        public List<string> ReadAllPathsToFilesInFolder(string path)
        {
            string[] pathsToFiles = Directory.GetFiles(path);
            List<string> pathToFilesWithoutTemplates = new List<string>();

            foreach (string singlePathToFile in pathsToFiles)
            {
                if(!singlePathToFile.Contains("template"))
                    pathToFilesWithoutTemplates.Add(singlePathToFile);
            }

            return pathToFilesWithoutTemplates;
        }

        public List<string> ReadAllContent(List<string> pathsToFilesInFolder)
        {
            List<string> OpenedContentFromAllPaths = new List<string>();

            foreach (string folderPath in pathsToFilesInFolder)
            {
                OpenedContentFromAllPaths.Add(File.ReadAllText(folderPath));
            }

            return OpenedContentFromAllPaths;
        }
    }
}
