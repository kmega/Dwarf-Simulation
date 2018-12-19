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

            string talesDirectory = @"cybermagic\opowiesci";
            //GetAllFiles()
            List<string> fileNames = GetFileNames(talesDirectory);
            //ReadAllFiles()
            List<string> tales = ReadAllFiles(fileNames);
            //ExtractStoriesWithMagdaName()
            List<string> talesWithMagda = Extractor.ExtractAllStoriesWithMagda(tales);
            //ExtractTaleNamesWithMagda
            List<string> taleNames = Extractor.ExtractAllTaleNames(talesWithMagda);
            //BuildStringToSaveTask4

            //WriteResults()
            Console.ReadLine();
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
                int time = Extractor.ExtractSingleTime(content);
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
            string fullName = Extractor.ExtractSingleName(file);
            //ExtractTime(fk) -> time
            int time = Extractor.ExtractSingleTime(file);
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
            List<int> times = Extractor.ExtractAllTimes(fileContents);
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
            List<string> namesOfHeroesWithoutTime = Extractor.ExtractAllNames(heroesWithoutTime);
            int numberOfHeroesWithTime = fileContents.Count - heroesWithoutTime.Count;
            //ExtractAllTimes
            List<int> times = Extractor.ExtractAllTimes(fileContents);
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

        private static string ReadSingleFile(string path)
        {
            string text = File.ReadAllText(path);
            return text;
        }
    }
}
