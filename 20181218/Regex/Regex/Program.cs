using System;
using System.IO;
using System.Text.RegularExpressions;

namespace UseRegex
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //0. Import Regexow
            Regex Time = new Regex(@"\((\d\d) min.*\)");
            Regex Name = new Regex(@"""(\w+ \w+)""");

            //1. Otworz plik -> uzyj sciezki
            var OpenedFile = File.ReadLines(@"/Users/piotr/Desktop/Git/primary/20181218/cybermagic/karty-postaci/1807-fryderyk-komciur.md");

            //2. Na tekscie w pliku znajdz regexa dla czasu
            //3. Na tekscie w pliku znajdz regexa dla imienia
            Match match;
            foreach (var item in OpenedFile)
            {
                match = Time.Match(item);
                if(match.Success)
                {
                    Console.WriteLine("Time: {0}", item.Substring(1, item.Length-2));
                }
                match = Name.Match(item);
                if (match.Success)
                {
                    string temp = item.Replace('"', '\0');
                    Console.WriteLine("Name: {0}", temp.Substring(7));
                }
            }
            //4. Stworz nowy plik results.txt i zapis oczekiwany wynik
        }
    }
}
