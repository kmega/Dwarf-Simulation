using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace pkozlowski
{
    class CharacterCard
    {
        public string filePath { get; set; }
        public IEnumerable<string> content { get; set; }

        public CharacterCard(string filepath)
        {
            filePath = filepath;
            content = File.ReadLines(filepath);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Regex timeRegex = new Regex(@"((\d\d) min.*)");
            //CharacterCard charCard = new CharacterCard(@"/Users/tetrael/Projekty/corealate/git/primary/20181218/cybermagic/karty-postaci/1807-fryderyk-komciur.md");
            var file = File.ReadLines(@"/Users/tetrael/Projekty/corealate/git/primary/20181218/cybermagic/karty-postaci/1807-fryderyk-komciur.md");
            Match match;
            foreach (var item in file)
            {
                match = timeRegex.Match(item);
                if (match.Success)
                {
                    //Console.WriteLine(item.ToString());
                    File.WriteAllText("wynik.txt",item);
                }
            }
        }
    }
}
