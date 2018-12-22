using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RegexTasks
{
    //
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

        public string ExtractStuffWithMagda(string text)
        {
            return SafelyExtractSingleElement(
                @"# Zas.ugi.*?(Magda Patiril.*?)\*.*?#", text); 
        }
        public string ExtractTitleOfStory(string text)
        {
            return SafelyExtractSingleElement(
                @"title: +""([\w\s]+)""", text);
        }
        public string CheckingExistOfKalina(string text)
        {
            return (SafelyExtractSingleElement(
                @"(Kalina Rotmistrz.)", text));
        }
        public void ExtractPersonsActingWithKalina(string text, List<string> personsWhoActWithKalina)
        {
            MatchCollection matches = new Regex(@"^\* (\w+ \w+):", RegexOptions.Multiline | RegexOptions.Singleline)
                .Matches(text);

            foreach (Match match in matches)
            {
                personsWhoActWithKalina.Add(match.Groups[1].Value);
            }
        }
        public string ExtractStuffFromZaslugi(string text)
        {
            return SafelyExtractSingleElement(
                @"# Zas.ugi\s+(.+?)#", text);
        }
        public void ExtractTasksFromConfig(string text, List<int> choosenTasks)
        {

            MatchCollection matches = new Regex(@"(\d+)", RegexOptions.Multiline | RegexOptions.Singleline)
               .Matches(text);

            foreach (Match match in matches)
            {
                choosenTasks.Add(int.Parse(match.Groups[1].Value));
            }

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
