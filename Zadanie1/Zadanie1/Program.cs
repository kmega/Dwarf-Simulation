using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using VivaRegex;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task101();

            //given directory
            string directory = @"cybermagic\karty-postaci";
            //GetFileNames(directory) -> Lista fileNames
            List<string> fileNames = GetFileNames(directory);
            //ReadAllFiles(fileNames) -> Lista files
            List<string> fileContents = ReadAllFiles(fileNames);
            //ExtractAllTimes(fileNames) -> Lista times
            List<int> times = ExtractAllTimes(fileContents);
            //SumTimes(times) -> minutes
            int sumOfTimes = SumAllTimes(times);
            //ChangeMinutesToHours() -> hours, minutes
            //WriteResults(minutes);


            
            //TextFileCreator.CreateOrAppend("result1.txt",$"{profileName} był budowany {timeToBuild} min");
            //TimeSpan totalTimeToBuildHeroes = TimeSpan.FromMinutes(Hero.TimeOfBuildingAllHeroes(folderPath));
            //TextFileCreator.CreateOrAppend("result2.txt", $"Wszystkie postacie do tej pory budowane były " +
            //    $"{totalTimeToBuildHeroes.Hours} godzin i {totalTimeToBuildHeroes.Minutes} minut.");
         

            Console.ReadLine();
        }

        private static int SumAllTimes(List<int> times)
        {
            throw new NotImplementedException();
        }

        private static List<int> ExtractAllTimes(List<string> fileContents)
        {
            throw new NotImplementedException();
        }

        private static List<string> ReadAllFiles(List<string> fileNames)
        {
            List<string> fileContents = new List<string>();
            foreach(var fileName in fileNames)
            {
                fileContents.Add(ReadSingleFile(fileName));
            }
            return fileContents;
        }

        private static List<string> GetFileNames(string directory)
        {          
            return Directory.GetFiles(directory).ToList(); ;
        }

        private static void Task101()
        {
            //ReadSingleFile(filename) -> fk
            var fileName = @"cybermagic\karty-postaci\1807-fryderyk-komciur.md";
            string file = ReadSingleFile(fileName);
            //ExtractName(fk) -> fullName
            string fullName = ExtractSingleName(file);
            //ExtractTime(fk) -> time
            int time = ExtractSingleTime(file);
            //WriteResults(fullName, time)
            WriteResults(fullName, time);
        }

        private static void WriteResults(string fullName, int time)
        {
            var contents = new string[]
            {
                $"{fullName} był budowany {time.ToString()} minuty"
            };
            File.WriteAllLines("result.txt", contents);
        }

        private static int ExtractSingleTime(string file)
        {
            TextParser textParser = new TextParser();
            var time = textParser.ExtractTimeToCreate(file);
            if (time == "")
            {
                return 0;
            }
            else
            {
                return Int32.Parse(time);
            }            
        }

        private static string ExtractSingleName(string file)
        {
            TextParser textParser = new TextParser();
            string fullName = textParser.ExtractProfileName(file);
            return fullName;
        }

        private static string ReadSingleFile(string path)
        {
            string text = File.ReadAllText(path);
            return text;
        }
    }
}
