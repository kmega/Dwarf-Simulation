using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace happy_path_creation_training_ver2
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
                @"title: ""((\w+ *){2,4})""", text);
        }

        public static string ExtractTitle(string text)
        {
            return SafelyExtractSingleElement(
                @"title: +""([\w\s]+)""", text);
        }

        public static string ExtractStuffWithMagda(string text)
        {
            var x = SafelyExtractSingleElement(
                @"# Zas.ugi.*?(Magda Patiril.*?)\*.*?#", text);
           return x;
        }

        public static string SafelyExtractSingleElement(string pattern, string text)
        {
            MatchCollection matches = new Regex(pattern, RegexOptions.Multiline | RegexOptions.Singleline)
                .Matches(text);

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
