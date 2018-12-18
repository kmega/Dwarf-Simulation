using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VivaRegex;

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

            string path2 = @"C:\Users\esmic\primary\20181218\cybermagic\karty-postaci\";
            string path = @"C:\Users\esmic\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
            string time;
            string name;
            StreamWriter sr = new StreamWriter("result.txt");
            StreamWriter sr2 = new StreamWriter("result2.txt");

            List<string> pliki = Directory.GetFiles(path2).ToList();
            
            

            //Zadanie 1
            string[] txt = File.ReadAllLines(path);
            TextParser tp = new TextParser();
            var xxx = string.Join("\n", txt);
            time = tp.ExtractTimeToCreate(xxx);
            name = tp.ExtractProfileName(xxx);
            Console.WriteLine("{0} był budowany {1} minuty", name, time );


            sr.Write("{0} był budowany {1} minuty", name, time);
            sr.Close();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //Zadanie 2
            int allTime=0;

            foreach (var item in Directory.EnumerateFiles(path2)) {
            
                txt = File.ReadAllLines(item);
                tp = new TextParser();
                xxx = string.Join("\n", txt);
                time = tp.ExtractTimeToCreate(xxx);
               
                name = tp.ExtractProfileName(xxx);
                if (time == "" || name=="")
                {
                    continue;
                }
                Console.WriteLine("{0} był budowany {1} minuty", name, time);
                sr2.WriteLine("{0} był budowany {1} minuty", name, time);
                


                allTime += Int32.Parse(time);

            }
            Console.WriteLine("Wszystkie postaci budowano {0} minut", allTime);

            sr2.WriteLine();
            sr2.Write("Wszystkie postaci budowano {0} minut", allTime);
            sr2.Close();
          


            
            

            Console.ReadKey();




        }
    }
}
