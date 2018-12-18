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

            //3. Na tekscie w pliku znajdz regexa dla imienia
            //4. Stworz nowy plik results.txt i zapis oczekiwany wynik
        }
    }
}
