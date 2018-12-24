using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task5
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

        public string ExtractStuffWithMagda(string text)
        {
            return SafelyExtractSingleElement(
                @"# Zas.ugi.*?(Magda Patiril.*?)\*.*?#", text);
        }

        public string ExtractIntCommand(string text)
        {
            return SafelyExtractSingleElement(
                @"\d+ -> ""(\d+)"" -> groups[1].Value", text);
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
