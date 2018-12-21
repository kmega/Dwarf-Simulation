using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            //given: configFilePath
            string configFilePath = "config.md";
            // ReadConfigFile(path) -> config
            string config = FileManager.ReadFile(configFilePath);
            // GetTaskToPerform(config) -> tasksToPerform zbiór zadań do wykonania
            Queue<int> tasksToPerform = ConfigManager.GetTasksToPerform(config);
            // PerformTasks(tasksToPerform)
            //PerformTasks(tasksToPerform);
            Task106();
            Console.ReadLine();
        }

        private static void PerformTasks(Queue<int> tasksToPerform)
        {
            while (tasksToPerform.Count != 0)
            {
                int task = tasksToPerform.Dequeue();
                Console.WriteLine($"Doing task: {task}");
                switch (task)
                {
                    case 1:                      
                        Task101();
                        break;
                    case 2:
                        Task102();
                        break;
                    case 3:
                        Task103();
                        break;
                    case 4:
                        Task104();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void Task101()
        {
            //ReadSingleFile(filename) -> fk
            var fileName = @"cybermagic\karty-postaci\1807-fryderyk-komciur.md";
            string file = FileManager.ReadFile(fileName);
            //ExtractName(fk) -> fullName
            string fullName = Extractor.ExtractSingleName(file);
            //ExtractTime(fk) -> time
            int time = Extractor.ExtractSingleTime(file);
            //WriteResults(fullName, time)
            string[] toSave = StringBuilderToSave.BuildStringToSaveTask(fullName, time);
            FileManager.WriteResults(toSave);
        }
        private static void Task102()
        {
            //given directory
            string directory = @"cybermagic\karty-postaci";
            //ReadAllFiles(fileNames) -> Lista files
            List<string> fileContents = FileManager.ReadAllFiles(directory);
            //ExtractAllTimes(fileNames) -> Lista times
            List<int> times = Extractor.ExtractAllTimes(fileContents);
            //SumTimes(times) -> minutes
            int sumOfTimes = Hero.SumAllTimes(times);
            //ChangeMinutesToHours() -> hours, minutes
            TimeSpan totalTimeToBuildHeroes = TimeSpan.FromMinutes(sumOfTimes);
            //BuildStringToSave() -> toSave
            string[] toSave = StringBuilderToSave.BuildStringToSaveTask(totalTimeToBuildHeroes);
            //WriteResults(minutes);
            FileManager.WriteResults(toSave);
        }
        private static void Task103()
        {
            //GetFileNames() - fileNames
            string directory = @"cybermagic\karty-postaci";
            //ReadAllFiles(fileNames) -> Lista files
            List<string> fileContents = FileManager.ReadAllFiles(directory);
            //GetAllHeroesWithoutTime(files) -> zbiór HeroesWithoutTime
            List<string> heroesWithoutTime = Hero.GetHeroesWithoutTime(fileContents);
            //ExtractAllNamesWithoutGivenTime -> list<string> names
            List<string> namesOfHeroesWithoutTime = Extractor.ExtractAllNames(heroesWithoutTime);
            int numberOfHeroesWithTime = fileContents.Count - heroesWithoutTime.Count;
            //ExtractAllTimes
            List<int> times = Extractor.ExtractAllTimes(fileContents);
            //SumAllGivenTimes
            int sumOfGivenTimes = Hero.SumAllTimes(times);
            //CountAverage(sumOfGivenTimes, numberOfHeroesWithTime) -> asses whole time;
            int averageTimeOfBuildingHero = Hero.CountAverage(sumOfGivenTimes, numberOfHeroesWithTime);
            //AssessWholeBuildingTime(averageTimeOfBuildingHero, ) -> wholeBuildingTime
            int wholeBuildingTime = Hero.AssessWholeBuildingTime(averageTimeOfBuildingHero,
                                                            heroesWithoutTime.Count,
                                                            sumOfGivenTimes);
            string[] toSave = StringBuilderToSave.BuildStringToSaveTask(namesOfHeroesWithoutTime,
                                                                        wholeBuildingTime,
                                                                        averageTimeOfBuildingHero);
            FileManager.WriteResults(toSave);
        }
        private static void Task104()
        {
            string talesDirectory = @"cybermagic\opowiesci";
            //ReadAllFiles()
            List<string> tales = FileManager.ReadAllFiles(talesDirectory);
            //ExtractStoriesWithMagdaName()
            List<string> talesWithMagda = Extractor.ExtractAllStoriesWithHero(tales,"Magda Patiril");
            //ExtractTaleNamesWithMagda
            List<string> taleNames = Extractor.ExtractAllTaleNames(talesWithMagda);
            //BuildStringToSaveTask4
            string[] toSave = StringBuilderToSave.BuildStringToSaveTask(taleNames);
            //WriteResults()
            FileManager.WriteResults(toSave);
        }
        private static void Task106()
        {
            //given directory
            string talesDirectory = @"cybermagic\opowiesci";
            //ReadAllStories() -> tales
            List<string> tales = FileManager.ReadAllFiles(talesDirectory);
            //GetStoriesWithKalina() -> talesWithKalina
            List<string> talesWithKalina = Extractor.ExtractAllStoriesWithHero(tales, "Kalina Rotmistrz");
            Console.ReadLine();
            //ExtractAllNamesInTalesWithKalina(talesWithKalina) -> namesConnectedWithKalina, numberOfEncounters

        }
    }
}

