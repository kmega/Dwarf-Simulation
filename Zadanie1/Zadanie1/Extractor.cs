using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaRegex;

namespace Zadanie1
{
    public class Extractor
    {
        public static int ExtractSingleTime(string file)
        {
            TextParser textParser = new TextParser();
            var time = textParser.ExtractTimeToCreate(file);
            if (time == "")
            {
                return 0;
            }
            else
            {
                return Int32.Parse(time);
            }
        }
        public static List<int> ExtractAllTimes(List<string> filesContent)
        {
            List<int> timesToBuild = new List<int>();
            foreach (var content in filesContent)
            {
                timesToBuild.Add(ExtractSingleTime(content));
            }
            return timesToBuild;
        }
        public static string ExtractSingleName(string file)
        {
            TextParser textParser = new TextParser();
            string fullName = textParser.ExtractProfileName(file);
            return fullName;
        }
        public static List<string> ExtractAllNames(List<string> heroesWithoutTime)
        {
            List<string> namesWithoutTime = new List<string>();
            foreach (var content in heroesWithoutTime)
            {
                namesWithoutTime.Add(ExtractSingleName(content));
            }
            return namesWithoutTime;
        }
        public static string ExtractSingleStoryWithMagda(string file)
        {
            TextParser textParser = new TextParser();
            string taleWithMagda = textParser.ExtractStuffWithMagda(file);
            return taleWithMagda;
        }
        public static List<string> ExtractAllStoriesWithMagda(List<string> tales)
        {
            List<string> talesWithMagda = new List<string>();
            foreach(var item in tales)
            {
                var tale = ExtractSingleStoryWithMagda(item);
                if(tale == "")
                {
                    continue;
                }
                else
                {
                    talesWithMagda.Add(tale);
                }               
            }
            return talesWithMagda;
        }
    }
}
