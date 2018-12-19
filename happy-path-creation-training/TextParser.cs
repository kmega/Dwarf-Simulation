using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace happy_path_creation_training
{
    public class TextParser
    {
        public static string ExtractTimeToCreate(string text)
        {
            return SafelyExtractSingleElement(
                @"\((\d\d) min.*\)", text);
        }

        public static string ExtractProfileName(string text)
        {
            return SafelyExtractSingleElement(
                @"title: ""(\w+ \w+)""", text);
        }

        public static string SafelyExtractSingleElement(string pattern, string text)
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
