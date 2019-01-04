using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace HappyPath
{
    class Program
    {
        public static void Task1(string inputPath,string outputPath)
        {
            // GIVEN: inputPath,outputPath,TextParser
            // ReadFile(inputPath) -> fileContent
            // TextParser.ExtractName(fileContent) -> profileName
            // TextParser.ExtractTimeToCreate(fileContent) -> timeToCreate
            // PrepareStringResult(profilName,timeToCreate) -> stringResult
            // WriteFile(stringResult,outputPath)
            string fileContent = File.ReadAllText(inputPath);
            TextParser textParser = new TextParser();
            string profileName = textParser.ExtractProfileName(fileContent);
            string timeToCreate = textParser.ExtractTimeToCreate(fileContent);
            string stringResult = $"{profileName} był budowany {timeToCreate} minut";
            File.WriteAllText(outputPath, stringResult);
        }
        public static void Task2(string directoryPath,string outputPath)
        {
            // ReadAllFiles(path) -> List<string> filesContent
            // for each fileContent: TextParser.ExtractTimeToCreate(fileContent) -> timesToCreate
            // sum(timesToCreate) -> totalTimeToCreate
            // prepareResult string(timesToCreate) -> resultString
            // WriteFile(stringResult,path)
            string[] files = Directory.GetFiles(directoryPath);
            TextParser textParser = new TextParser();
            int totalTimeToCreate = 0;
            foreach (string file in files)
            {
                string fileContent = File.ReadAllText(file);
                string timeToCreate = textParser.ExtractTimeToCreate(fileContent);
                totalTimeToCreate += int.Parse(timeToCreate);
            }
            int totalTimeToCreateInHours = totalTimeToCreate / 60;
            string resultString = $"Wszystkie postacie do tej pory budowane były {totalTimeToCreateInHours} godzin {totalTimeToCreate % 60} minut";
            File.WriteAllText(outputPath, resultString);

        }
        static void Main(string[] args)
        {
            //Task1(@"C:\Users\Jan\source\repos\HappyPath\cybermagic\karty-postaci\1807-fryderyk-komciur.md", "task1.txt");

        }
    }
}
