using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace pkozlowski
{
    class CharacterVault
    {
        public List<Character> Characters { get; set; }

        public CharacterVault()
        {
            Characters = new List<Character>();
        }
    }

    class Character
    {
        public string Name { get; set; }
        public string BuildTime { get; set; }
        public string filePath { get; set; }

        public Character(string filepath)
        {
            filePath = filepath;
            takeProfileName();
            takeTimeToCreate();
        }

        private void takeProfileName()
        {
            var content = File.ReadAllText(filePath);
            TextParser textParser = new TextParser();
            Name = textParser.ExtractProfileName(content);
        }

        private void takeTimeToCreate()
        {
            var content = File.ReadAllText(filePath);
            TextParser textParser = new TextParser();
            BuildTime = textParser.ExtractTimeToCreate(content);
        }
    }

    class Story
    {
        public String title { get; set; }
    }

    class TextParser
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

    class Program
    {
        static void Main(string[] args)
        {
            CharacterVault characterVault = new CharacterVault();
            characterVault.Characters.Add(new Character(@"cybermagic/karty-postaci/1807-fryderyk-komciur.md"));

            var result = characterVault.Characters.Where(x => x.Name == "Fryderyk Komciur").Single();
            var resultText = result.Name + " był budowny " + result.BuildTime + " minuty.";
            File.WriteAllText("wynik.txt", resultText);
        }
    }
}
