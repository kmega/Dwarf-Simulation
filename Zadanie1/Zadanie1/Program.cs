using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            var readFile = File.ReadAllText("C:/Users/Lenovo/primary/20181218/cybermagic/karty-postaci/1807-fryderyk-komciur.md");
            string timePattern = @"\((\d\d) min.*\)";
            string titlepattern = @"(\w+ \w+)";
            Match timeMatch = Regex.Match(readFile, timePattern);
            Match titleMatch = Regex.Match(readFile, titlepattern);
            Console.WriteLine($"{titleMatch.ToString()} był budowany {timeMatch.ToString()}");
            Console.ReadLine();
        }
    }
}
