using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
namespace regExApp
{
    class Program
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

        static void Main(string[] args)
        {
            
            string path = "1807-fryderyk-komciur.md";

            string[] fryderyk = File.ReadAllLines(path);
            string timeResult;

            TextParser findText = new TextParser();

            string helper;

            for (int i = 0; i<fryderyk.Length; i++)
            {
                helper = findText.ExtractTimeToCreate(fryderyk[i]);
                if (helper != null)
                {
                    timeResult = findText.ExtractTimeToCreate(fryderyk[i]);
                    Console.WriteLine(timeResult);
                }
                
            }
            
            Console.ReadKey();

        }
    }
}
