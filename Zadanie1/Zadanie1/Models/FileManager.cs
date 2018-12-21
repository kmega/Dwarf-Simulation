using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    static class FileManager
    {

        public static void WriteResults(string[] toSave)
        {
            File.AppendAllLines("result.txt", toSave);
        }

        public static string ReadFile(string path)
        {
            string text = File.ReadAllText(path);
            return text;
        }

        public static List<string> ReadAllFiles(string directory)
        {
            List<string> fileNames = GetFileNames(directory);
            List<string> fileContents = new List<string>();
            foreach (var fileName in fileNames)
            {
                if (fileName.Contains("template"))
                {
                    continue;
                }
                else
                {
                    fileContents.Add(ReadFile(fileName));
                }
            }
            return fileContents;
        }

        public static List<string> GetFileNames(string directory)
        {
            return Directory.GetFiles(directory).ToList(); ;
        }
        
    }
}
