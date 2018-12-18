using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CyberMagic
{
    class Program
    {
        static void Main(string[] args)
        {
            //given: poleceniaRegexaczas,polecenei Regexaimie, sciezka, 
            //1. Odczyt pliku (sciezka)
            //2.Przefiltorwanie pliku (poleceniaRegexaczas) -> czas
            //3. Przefiltrowaniepliku (polecenaRegexaimie) -> imie
            //imie, czas -> zapis do pliku - > result.txt

            string path = @"C:\Users\esmic\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
            string time;
            string name;
            
            Regex rxTime = new Regex( @"\((\d\d) min.*\)");


            string[] txt = File.ReadAllLines(path);
            MatchCollection matches = rxTime.Matches(txt.ToString());
           


            
            

            Console.ReadKey();




        }
    }
}
