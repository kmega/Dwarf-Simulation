using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AllTasksInOne
{
    public class TextParser
    {
        public string ExtractTimeToCreate(string text)
        {
            return SafelyExtractSingleElement(@"\((\d\d) min.*\)", text);
        }

        public string ExtractProfileName(string text)
        {
            return SafelyExtractSingleElement(
                @"title: ""((\w+ *){2,4})""", text);
        }

        public string ExtractStoryName(string text)
        {
            return SafelyExtractSingleElement(
                @"title: +""([\w\s]+)""", text);
        }

        public List<string> ExtractCommands(string text)
        {
            return SafelyExtractCommands(
                @"\d+", text);
        }

        public string ExtractStuffWithMagda(string text)
        {
            return SafelyExtractSingleElement(
                @"# Zas.ugi.*?(Magda Patiril.*?)\*.*?#", text);
        }

        public string ExtractMerit(string text)
        {
            return SafelyExtractSingleElement(
                @"# Zas.ugi\s+(.+?)#", text);
        }

        public string ExtractCharactersOfMerits(string text)
        {
            return SafelyExtractSingleElement(
                @"^* (\w+ \w+):", text);
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

        private List<string> SafelyExtractCommands(string pattern, string text)
        {
            MatchCollection matches = new Regex(pattern, RegexOptions.Multiline | RegexOptions.Singleline)
                .Matches(text);

            List<string> allResults = new List<string>();
            foreach (Match match in matches)
            {
                allResults.Add(match.Value);
            }

            if (allResults.Count > 0) return allResults;
            else return null;
        }


    }
} 
