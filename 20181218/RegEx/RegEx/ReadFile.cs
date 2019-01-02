using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using RegEx;

namespace RegEx
{
    public class ReadFile
    {
        public string ReadSingleFile(string filePath)
        {
            string textFromFile = File.ReadAllText(filePath);
            return textFromFile;
        }

        public List<string> ReadingAllFIlesInDirectory(string path)
        {
            List<string> allPeopleText = new List<string>();
            foreach (var file in Directory.EnumerateFiles(path, "*.md"))
            {
                allPeopleText.Add(ReadSingleFile(file));
            }
            return allPeopleText;
        }
    }
}
