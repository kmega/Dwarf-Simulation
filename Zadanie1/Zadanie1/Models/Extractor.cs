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
        public static List<string> ExtractAllMeritSections(List<string> talesWithHero)
        {
            List<string> resultMerits = new List<string>();
            TextParser textParser = new TextParser();
            foreach (var item in talesWithHero)
            {
                var merit = textParser.ExtractMeritSection(item);
                resultMerits.Add(merit);
            }
            return resultMerits;
        }
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
        public static string ExtractSingleStoryWithHero(string file, string heroName)
        {
            TextParser textParser = new TextParser();
            string taleWithHero = textParser.ExtractTaleWithHero(file, heroName);
            return taleWithHero;
        }
        public static List<string> ExtractAllStoriesWithHero(List<string> tales, string heroName)
        {
            List<string> talesWithHero = new List<string>();
            foreach(var item in tales)
            {
                var tale = ExtractSingleStoryWithHero(item, heroName);
                if(tale == "")
                {
                    continue;
                }
                else
                {
                    talesWithHero.Add(item);
                }               
            }
            return talesWithHero;
        }

        public static string ExtractSingleTaleName(string tale)
        {
            TextParser textParser = new TextParser();
            string taleName = textParser.ExtractTaleName(tale);
            return taleName;
        }
        public static List<string> ExtractAllTaleNames(List<string> tales)
        {
            List<string> taleNames = new List<string>();
            foreach(var item in tales)
            {
                taleNames.Add(ExtractSingleTaleName(item));
            }
            return taleNames;
        }
    }
}
