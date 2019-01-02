using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace VivaRegex
{
    public class TextParser
    {
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
