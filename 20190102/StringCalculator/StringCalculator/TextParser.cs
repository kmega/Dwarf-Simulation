using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace VivaRegex
{
    public class TextParser
    {
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

        public string ExtractTaleWithHero(string text, string heroName)
        {
            return SafelyExtractSingleElement(
                $@"# Zas.ugi.*?({heroName}.*?)\*.*?#", text);
        }
        public string ExtractTaleName(string text)
        {
            return SafelyExtractSingleElement(
                @"title: +""([\w\s]+)""", text);
        }
        public string ExtractMeritSection(string text)
        {
            return SafelyExtractSingleElement(
                @"# Zas.ugi\s+(.+?)#  ", text);
        }
        public List<string> ExtractNumbersOfTask(string text)
        {
            return SafelyExtractAllElements(
                @"(\d+)", text);
        }
        public List<string> ExtractNumbers(string text)
        {
            return SafelyExtractAllElements(
                @"(\d+)", text);
        }
        private string SafelyExtractSingleElement(string pattern, string text)
        {
            List<string> allResults = SafelyExtractAllElements(pattern, text);

            if (allResults.Count > 0) return allResults.First();
            else return string.Empty;
        }
        private List<string> SafelyExtractAllElements(string pattern, string text)
        {
            MatchCollection matches = new Regex(pattern, RegexOptions.Multiline | RegexOptions.Singleline)
                .Matches(text);

            List<string> allResults = new List<string>();
            foreach (Match match in matches)
            {
                allResults.Add(match.Groups[1].Value);
            }
            return allResults;
        }
    }
} 
