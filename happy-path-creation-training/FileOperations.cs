using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace happy_path_creation_training
{
    class FileOperations
    {
        public static string[] ReturnStringArrayFromFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        public static string ReturnProfileNameAndBuildTime(string[] stringArrayFromFile)
        {
            string pattern1 = "\\((\\d\\d) min.*\\)";
            string pattern2 = "title: \"(\\w+ \\w+)\"";
            string profileName = "";
            string buildTime = "";

            foreach (var line in stringArrayFromFile)
            {
                if (!String.IsNullOrEmpty(ExtractRegExFromString(pattern1, line)))
                {
                    buildTime = ExtractRegExFromString(pattern1, line);
                }
                if (!String.IsNullOrEmpty(ExtractRegExFromString(pattern2, line)))
                {
                    profileName = ExtractRegExFromString(pattern2, line);
                }
               
            }


            return profileName + " był budowany " + buildTime + " minuty";
        }

        public static string ExtractRegExFromString(string pattern, string text)
        {
            MatchCollection matches = new Regex(pattern).Matches(text);

            List<string> allResults = new List<string>();
            foreach (Match match in matches)
            {
                allResults.Add(match.Groups[1].Value);
            }

            if (allResults.Count > 0) return allResults.First();
            else return string.Empty;
        }
    }
}
