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
            //Task1(@"karty-postaci\1807-fryderyk-komciur.md");
            
            //Task 2           
            Task2(@"karty-postaci");
           
            //Sum
            //WriteResults
            Console.ReadLine();
        }

        private static void Task2(string filesDirectory)
        {
            //Read all files(directory) -> [] files
            List<string> filesContents = TextFileManager.ReadAllFiles(filesDirectory);
            //GetAllTimes(files) -> [] times
            var allTimes = InformationExtractor.ExtractAllTimes(filesContents);
            //sum times
            var sumOfTimes = allTimes.Sum();
            //WriteToFile
           // TextFileManager.WriteResults(new string[])
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
            TextFileManager.WriteResults(new string[] { $"{ name} był budowany {time} minuty." });
        }

    }
}
