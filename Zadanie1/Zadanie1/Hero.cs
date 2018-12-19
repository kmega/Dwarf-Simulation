using System;
using System.IO;
using VivaRegex;

namespace Zadanie1
{
    public class Hero
    {
        public static int TimeOfBuildingAllHeroes(string folderPath)
        {
            TextParser textParser = new TextParser();
            int sumOfBuildTimes = 0;
            foreach (string file in Directory.EnumerateFiles(folderPath, "*.md"))
            {
                string content = File.ReadAllText(file);
                string time = textParser.ExtractTimeToCreate(content);
                if (time == "") continue;
                sumOfBuildTimes += Int32.Parse(time);
            }
            return sumOfBuildTimes;
        }
        
    }
}
