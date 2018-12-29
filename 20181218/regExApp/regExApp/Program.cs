using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using regExApp.Domena;

namespace regExApp
{
    class Program
    {
        

        static void Main(string[] args)
        {/*
            // TASK ONE **********

            //Read file from path
            string path = "1807-fryderyk-komciur.md";
            string file_Content = ReadFile(path);

            //Get Time From File
            string timeOfBuldingCharacter = GetTimeFromFileContent(file_Content);

            //Write time to result1.txt
            string pathToSaveTask_1 = "result1.txt";
            File.WriteAllText(pathToSaveTask_1, timeOfBuldingCharacter);

            // TASK TWO**********

            //Read file names from main path
            string pathAllCharacters = @"cybermagic\karty-postaci";
            List<string> fileCharNames = Directory.GetFiles(pathAllCharacters).Select(Path.GetFileName).ToList();

            //Open all files from fileNames and get its content
            List<string> contentOFileNames = OpenMultiFiles(fileCharNames, pathAllCharacters);

            //Get time from each file
            List<string> timesOfCreatingCharacters = GetMultiTimes(contentOFileNames);

            //Sum the time and write to file result2.txt
            string sumOfTimes = SumAllTimes(timesOfCreatingCharacters).ToString();
            string pathToSaveTask_2 = "result2.txt";
            File.WriteAllText(pathToSaveTask_2, sumOfTimes);

            // TASK THREE**********

            //Get characters without given time and write to result3-1.txt (IGNORE 1807-_template.md)
            string pathToSaveTask_3_1 = "result3-1.txt";
            string[] charactersWithoutTime = CharactersWithoutGivenTime(timesOfCreatingCharacters, fileCharNames, contentOFileNames).ToArray();
            File.WriteAllLines(pathToSaveTask_3_1, charactersWithoutTime);

            //Get characters with given time
            int charactersWithTime = CharactersWithGivenTime(timesOfCreatingCharacters, fileCharNames);

            //Count average time from given characters
            int amountOfCharsWithoutTime = AmountOfCharactersWithoutTime(timesOfCreatingCharacters, fileCharNames);
            int avgTimeForCharsWithoutTime = AvgTime(Int32.Parse(sumOfTimes),charactersWithTime);
            
            //Count avarage time from all characters and write to result3-1.txt
            string pathToSaveTask_3_2 = "result3-2.txt";
            int avgTimeAllChars = AvgTime(avgTimeForCharsWithoutTime + Int32.Parse(sumOfTimes), charactersWithTime + amountOfCharsWithoutTime);
            File.WriteAllText(pathToSaveTask_3_2, avgTimeAllChars.ToString());

            // TASK FOUR**********

            //Get files where exists Magda Patiril
            string pathAllStories = @"cybermagic\opowiesci";
            List<string> fileStoriesNames = Directory.GetFiles(pathAllStories).Select(Path.GetFileName).ToList();
            string[] magdaPatirilFiles = FindMagdaPatiril(OpenMultiFiles(fileStoriesNames, pathAllStories)).ToArray();

            //Write name of those file in result4.txt
            
            string pathToSaveTask_4 = "result4.txt";
            File.WriteAllLines(pathToSaveTask_4, magdaPatirilFiles);
            */

            Tasks task = new Tasks();
            task.UserDecisionReader();
            task.Task_1();
            task.Task_2();
            task.Task_3();
            task.Task_4();

        }

        
    }
}
