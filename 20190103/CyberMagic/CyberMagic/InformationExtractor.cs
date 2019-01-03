using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaRegex;

namespace CyberMagic
{
    public static class InformationExtractor
    {
        public static string ExtractSingleName(string file)
        {
            var textParser = new TextParser();
            var name = textParser.ExtractProfileName(file);
            return name;
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

    }
}
