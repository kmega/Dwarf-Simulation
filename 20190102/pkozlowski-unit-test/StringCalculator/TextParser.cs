using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace StringCalculator
{
    class TextParser
    {
        public string ExtractNumber(string text)
        {
            return SafelyExtractSingleElement(
                @"\((\d+) min.*\)", text);
        }

        public string ExtractTimeToCreate(string text)
        {
            return SafelyExtractSingleElement(
                @"\((\d\d) min.*\)", text);
        }

        public string ExtractProfileName(string text)
        {
            return SafelyExtractSingleElement(
                @"title: ""(\w+ \w+)""", text);
        }

        public string ExtractStuffWithMagda(string text)
        {
            return SafelyExtractSingleElement(
                @"# Zas.ugi.*?(Magda Patiril.*?)\*.*?#", text);
        }

        public string ExtractStories(string text)
        {
            return SafelyExtractSingleElement(
                @"title: +""([\w\s]+)""", text);
        }

        private string SafelyExtractSingleElement(string pattern, string text)
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