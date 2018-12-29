using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using regExApp;
using System.IO;
using regExApp.TextMethods;

namespace regExApp.Domena
{
    class Tasks
    {
        public void Task_1()
        {
            //Read file from path
            string path = "1807-fryderyk-komciur.md";
            string file_Content = ReadFile(path);

            //Get Time From File
            string timeOfBuldingCharacter = GetTimeFromFileContent(file_Content);

            //Write time to result1.txt
            string pathToSaveTask_1 = "result1.txt";
            File.WriteAllText(pathToSaveTask_1, timeOfBuldingCharacter);
        }

        public void Task_2()
        {
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

        }

        public void Task_3()
        {
            //Read file names from main path
            string pathAllCharacters = @"cybermagic\karty-postaci";
            List<string> fileCharNames = Directory.GetFiles(pathAllCharacters).Select(Path.GetFileName).ToList();

            //Open all files from fileNames and get its content
            List<string> contentOFileNames = OpenMultiFiles(fileCharNames, pathAllCharacters);

            //Get time from each file
            List<string> timesOfCreatingCharacters = GetMultiTimes(contentOFileNames);

            //Get characters without given time and write to result3-1.txt (IGNORE 1807-_template.md)
            string pathToSaveTask_3_1 = "result3-1.txt";
            string[] charactersWithoutTime = CharactersWithoutGivenTime(timesOfCreatingCharacters, fileCharNames, contentOFileNames).ToArray();
            File.WriteAllLines(pathToSaveTask_3_1, charactersWithoutTime);

            //Get characters with given time
            int charactersWithTime = CharactersWithGivenTime(timesOfCreatingCharacters, fileCharNames);

            //Count average time from given characters
            string sumOfTimes = SumAllTimes(timesOfCreatingCharacters).ToString();
            int amountOfCharsWithoutTime = AmountOfCharactersWithoutTime(timesOfCreatingCharacters, fileCharNames);
            int avgTimeForCharsWithoutTime = AvgTime(Int32.Parse(sumOfTimes), charactersWithTime);

            //Count avarage time from all characters and write to result3-1.txt
            string pathToSaveTask_3_2 = "result3-2.txt";
            int avgTimeAllChars = AvgTime(avgTimeForCharsWithoutTime + Int32.Parse(sumOfTimes), charactersWithTime + amountOfCharsWithoutTime);
            File.WriteAllText(pathToSaveTask_3_2, avgTimeAllChars.ToString());
        }

        public void Task_4()
        {
            //Get files where exists Magda Patiril
            string pathAllStories = @"cybermagic\opowiesci";
            List<string> fileStoriesNames = Directory.GetFiles(pathAllStories).Select(Path.GetFileName).ToList();
            string[] magdaPatirilFiles = FindMagdaPatiril(OpenMultiFiles(fileStoriesNames, pathAllStories)).ToArray();

            //Write name of those file in result4.txt

            string pathToSaveTask_4 = "result4.txt";
            File.WriteAllLines(pathToSaveTask_4, magdaPatirilFiles);
        }

        public void UserDecisionReader()
        {
            TextParser reader = new TextParser();
            string userDecision = Console.ReadLine();
            int userDigit = Int32.Parse(reader.AnalyseUserImput(userDecision));

            switch (userDigit)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    Task4();
                    break;
            }
      
        }

        private List<string> FindMagdaPatiril(List<string> contentOFileNames)
        {
            List<string> storiesWithMagda = new List<string>();
            int i = 0;

            TextParser reader = new TextParser();
            foreach (string file in contentOFileNames)
            {
                if (reader.ExtractStuffWithMagda(file) != "")
                {
                    storiesWithMagda.Add(reader.ExtractProfileCharacterName(contentOFileNames[i]));
                }

                i++;
            }

            return storiesWithMagda;
        }

        private  int AvgTime(int sum, int amount)
        {
            int avg = sum / amount;
            return avg;
        }

        private int AmountOfCharactersWithoutTime(List<string> timesOfCreatingCharacters, List<string> fileNames)
        {
            int charsWithGivenTime;
            int emptyCounter = 0;
            int i = 0;
            List<string> emptyCharactersNames = new List<string>();

            foreach (string time in timesOfCreatingCharacters)
            {
                if (fileNames[i] == "1807-_template.md") { continue; }

                bool intOrString = Int32.TryParse(time, out charsWithGivenTime);

                if (intOrString == false) { emptyCounter++; }

                i++;
            }

            return emptyCounter;
        }

        private int CharactersWithGivenTime(List<string> timesOfCreatingCharacters, List<string> fileNames)
        {
            int chars = 0;
            int charsWithGivenTime = 0;
            List<string> emptyCharactersNames = new List<string>();

            foreach (string time in timesOfCreatingCharacters)
            {
                bool intOrString = Int32.TryParse(time, out chars);

                if (intOrString == true)
                {
                    charsWithGivenTime++;
                }

            }

            return charsWithGivenTime;
        }

        private List<string> CharactersWithoutGivenTime(List<string> timesOfCreatingCharacters, List<string> fileNames, List<string> contentOfFileNames)
        {
            int charsWithGivenTime;
            int emptyCounter = 0;
            int i = 0;
            List<string> emptyCharactersNames = new List<string>();

            TextParser reader = new TextParser();

            foreach (string time in timesOfCreatingCharacters)
            {
                if (fileNames[i] == "1807-_template.md") { continue; }

                bool intOrString = Int32.TryParse(time, out charsWithGivenTime);

                if (intOrString == false)
                {
                    emptyCounter++;
                    emptyCharactersNames.Add(reader.ExtractProfileCharacterName(contentOfFileNames[i]));
                }

                i++;
            }


            return emptyCharactersNames;
        }

        private int SumAllTimes(List<string> timesOfCreatingCharacters)
        {
            int sumOfTimes = 0;
            int intTime;
            foreach (string time in timesOfCreatingCharacters)
            {
                Int32.TryParse(time, out intTime);
                sumOfTimes += intTime;
            }

            return sumOfTimes;
        }

        private List<string> GetMultiTimes(List<string> contentOFileNames)
        {
            List<string> allTimes = new List<string>();
            foreach (string time in contentOFileNames)
            {
                if (time != "") { allTimes.Add(GetTimeFromFileContent(time)); };
            }

            return allTimes;
        }

        private List<string> OpenMultiFiles(List<string> fileNames, string path)
        {
            List<string> contentOfAllFiles = new List<string>();
            foreach (string file in fileNames)
            {
                contentOfAllFiles.Add(ReadFile(path + @"\" + file));
            }

            return contentOfAllFiles;
        }

        private string GetTimeFromFileContent(string fileContent)
        {
            TextParser reader = new TextParser();

            string time = reader.ExtractTimeToCreate(fileContent);
            return time;
        }

        private string ReadFile(string path)
        {
            string fileContent = File.ReadAllText(path);
            return fileContent;
        }
    }
}
