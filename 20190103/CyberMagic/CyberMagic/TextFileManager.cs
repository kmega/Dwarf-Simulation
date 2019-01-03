using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberMagic
{
    public static class TextFileManager
    {
        public static string ReadFile(string fileName)
        {
            string text = File.ReadAllText(fileName);
            return text;

        }
        public static void WriteResults(string[] toSave)
        {
            File.AppendAllLines("result.txt", toSave);
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
