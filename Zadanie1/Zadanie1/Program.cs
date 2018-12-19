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
            Task101();
            Task102();
            Task103();

            Console.ReadLine();
        }

        private static List<string> ExtractAllNames(List<string> heroesWithoutTime)
        {
            List<string> namesWithoutTime = new List<string>();
            foreach (var content in heroesWithoutTime)
            {
                namesWithoutTime.Add(ExtractSingleName(content));
            }
            return namesWithoutTime;
        }

        private static int AssessWholeBuildingTime(int averageTime, int numberOfHeroesWithoutTime, int allGivenTime)
        {
            return allGivenTime + averageTime * numberOfHeroesWithoutTime;
        }

        private static List<string> GetHeroesWithoutTime(List<string> fileContents)
        {
            List<string> heroesWithoutTime = new List<string>();
            foreach(var content in fileContents)
            {
                int time = ExtractSingleTime(content);
                if (time == 0)
                {
                    heroesWithoutTime.Add(content);
                }
            }
            return heroesWithoutTime;          
        }

        private static int CountAverage(int sumOfGivenTimes, int numberOfHeroesWithTime)
        {
            return sumOfGivenTimes / numberOfHeroesWithTime;
        }

        private static int SumAllTimes(List<int> timesOfBuilding)
        {
            int sum = 0;
            foreach(var time in timesOfBuilding)
            {
                sum += time;
            }
            return sum;
        }

        private static List<int> ExtractAllTimes(List<string> filesContent)
        {
            List<int> timesToBuild = new List<int>();
            foreach(var content in filesContent)
            {
                timesToBuild.Add(ExtractSingleTime(content));
            }
            return timesToBuild;
        }

        private static List<string> ReadAllFiles(List<string> fileNames)
        {
            List<string> fileContents = new List<string>();
            foreach(var fileName in fileNames)
            {
                if (fileName.Contains("template"))
                {
                    continue;
                }
                else
                {
                    fileContents.Add(ReadSingleFile(fileName));
                }                
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
            string[] toSave = StringBuilderToSave.BuildStringToSaveTask1(fullName, time);
            WriteResults(toSave);
        }
        private static void Task102()
        {
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
            TimeSpan totalTimeToBuildHeroes = TimeSpan.FromMinutes(sumOfTimes);
            //BuildStringToSave() -> toSave
            string[] toSave = StringBuilderToSave.BuildStringToSaveTask2(totalTimeToBuildHeroes);
            //WriteResults(minutes);
            WriteResults(toSave);
        }    
        private static void Task103()
        {
            //GetFileNames() - fileNames
            string directory = @"cybermagic\karty-postaci";
            //GetFileNames(directory) -> Lista fileNames
            List<string> fileNames = GetFileNames(directory);
            //ReadAllFiles(fileNames) -> Lista files
            List<string> fileContents = ReadAllFiles(fileNames);
            //GetAllHeroesWithoutTime(files) -> zbiór HeroesWithoutTime
            List<string> heroesWithoutTime = GetHeroesWithoutTime(fileContents);
            //ExtractAllNamesWithoutGivenTime -> list<string> names
            List<string> namesOfHeroesWithoutTime = ExtractAllNames(heroesWithoutTime);
            int numberOfHeroesWithTime = fileContents.Count - heroesWithoutTime.Count;
            //ExtractAllTimes
            List<int> times = ExtractAllTimes(fileContents);
            //SumAllGivenTimes
            int sumOfGivenTimes = SumAllTimes(times);
            //CountAverage(sumOfGivenTimes, numberOfHeroesWithTime) -> asses whole time;
            int averageTimeOfBuildingHero = CountAverage(sumOfGivenTimes, numberOfHeroesWithTime);
            //AssessWholeBuildingTime(averageTimeOfBuildingHero, ) -> wholeBuildingTime
            int wholeBuildingTime = AssessWholeBuildingTime(averageTimeOfBuildingHero,
                                                            heroesWithoutTime.Count,
                                                            sumOfGivenTimes);
            string[] toSave = StringBuilderToSave.BuildStringToSaveTask3(namesOfHeroesWithoutTime,
                                                                        wholeBuildingTime,
                                                                        averageTimeOfBuildingHero);
            WriteResults(toSave);
        }
        private static void WriteResults(string[] toSave)
        {
            File.AppendAllLines("result.txt", toSave);
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
