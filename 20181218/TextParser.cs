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

        public string ExtractMagdaPatiril(string text)
        {
            return SafelyExtractSingleElement(
                //@"# Zas.ugi.*?Magda Patiril.*?#", text);
                @"#Zas.ugi.*?(Magda Patiril.*?)\*.*?#", text);
            
        }
        public string ExtractStoryWithMagda(string text)
        {
            return SafelyExtractSingleElement(
                @"title: +""([\w\s]+)""", text);
        }

        private string SafelyExtractSingleElement(string pattern, string text)
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

