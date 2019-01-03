using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberMagic
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1(@"cybermagic\karty-postaci\1807-fryderyk-komciur.md");
        }

        private static void Task1(string fileFullPath)
        {
            //Task 1
            //Wczytaj plik
            string file = TextFileManager.ReadFile(fileFullPath);
            //Wyfiltruj imie
            string name = InformationExtractor.ExtractSingleName(file);
            //Wyfiltruj czas
            int time = InformationExtractor.ExtractSingleTime(file);
            // Wyswietl wyniki
            TextFileManager.WriteResults(new string[] { $"{name} był budowany {time} minuty." });
        }

    }
}
