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
            Regex Name = new Regex(@"(\w+ \w+)");

            //1. Otworz plik -> uzyj sciezki
            StreamReader OpenedFile = new StreamReader(@"/Users/piotr/Desktop/Git/primary/20181218/cybermagic/karty-postaci/1807-fryderyk-komciur.md");
            //2. Na tekscie w pliku znajdz regexa dla czasu
            string time;
            string name;

            while((time = OpenedFile.ReadLine())!=null)
            {
                Match match = Time.Match(time);
                if(match.Success)
                {
                    Console.WriteLine("Czas: {0}", time);
                }

                Match match2 = Name.Match(time);
                if (match2.Success)
                {
                    Console.WriteLine("Imie: {0}", match2.Groups[1].Value);
                }
            }

            while ((name = OpenedFile.ReadLine()) != null)
            {

            }

            //3. Na tekscie w pliku znajdz regexa dla imienia
            //4. Stworz nowy plik results.txt i zapis oczekiwany wynik
        }
    }
}
