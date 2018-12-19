﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
namespace regExApp
{
    class Program
    {
        public class TextParser
        {
            public string ExtractTimeToCreate(string text)
            {
                return SafelyExtractSingleElement(
                    @"\((\d\d) min.*\)", text);
            }

            public string ExtractProfileName(string text)
            {
                return SafelyExtractSingleElement(
                    @"title: ""(\w+ \w+)""", text);
            }

            private string SafelyExtractSingleElement(string pattern, string text)
            {
                MatchCollection matches = new Regex(pattern).Matches(text);

                List<string> allResults = new List<string>();
                foreach (Match match in matches)
                {
                    allResults.Add(match.Groups[1].Value);
                }

                if (allResults.Count > 0) return allResults.First();
                else return string.Empty;
            }
        }

        static void Main(string[] args)
        {
            // TASK ONE **********

            //Read file from path
            string path = "1807-fryderyk-komciur.md";
            string file_Content = readFile(path);

            //Get Time From File
            string timeOfBuldingCharacter = getTimeFromFileContent(file_Content);

            //Write time to result1.txt
            string pathToSaveTask_1 = "result1.txt";
            File.WriteAllText(pathToSaveTask_1, timeOfBuldingCharacter);

            // TASK TWO**********

            //Read file names from main path
            string pathAllCharacters = @"cybermagic\karty-postaci";
            List<string> fileNames = Directory.GetFiles(pathAllCharacters).Select(Path.GetFileName).ToList();

            //Open all files from fileNames and get its content
            List<string> contentOFileNames = openMultiFiles(fileNames, pathAllCharacters);

            //Get time from each file
            List<string> timesOfCreatingCharacters = getMultiTimes(contentOFileNames);

            //Sum the time and write to file result2.txt
            string sumOfTimes = sumAllTimes(timesOfCreatingCharacters).ToString();
            string pathToSaveTask_2 = "result2.txt";
            File.WriteAllText(pathToSaveTask_2, sumOfTimes);

            // TASK THREE**********

            //Get characters without given time and write to result3-1.txt (IGNORE 1807-_template.md)
            string pathToSaveTask_3_1 = "result3-1.txt";
            string[] charactersWithoutTime = charactersWithoutGivenTime(timesOfCreatingCharacters, fileNames).ToArray();
            File.WriteAllLines(pathToSaveTask_3_1, charactersWithoutTime);

            //Get characters with given time
            int charactersWithTime = charactersWithGivenTime(timesOfCreatingCharacters, fileNames);

            //Count average time from given characters
            int amountOfCharsWithoutTime = amountOfCharactersWithoutTime(timesOfCreatingCharacters, fileNames);
            int avgTimeForCharsWithoutTime = avgTime(Int32.Parse(sumOfTimes),amountOfCharsWithoutTime);

            //Assign avarage time to empty time Characters
            int assignAvgTimeToEmptyCharTimes = avgTimeForCharsWithoutTime;

            //Count avarage time from all characters and write to txt file
            string pathToSaveTask_3_2 = "result3-2.txt";
            int avgTimeAllChars = avgTime(assignAvgTimeToEmptyCharTimes + Int32.Parse(sumOfTimes), charactersWithTime + amountOfCharsWithoutTime);
            File.WriteAllText(pathToSaveTask_3_2, avgTimeAllChars.ToString());



        }

        private static int avgTime(int sum, int amount)
        {
            int avg = sum / amount;
            return avg;
        }

        private static int amountOfCharactersWithoutTime(List<string> timesOfCreatingCharacters, List<string> fileNames)
        {
            int charsWithGivenTime;
            int emptyCounter = 0;
            int i = 0;
            List<string> emptyCharactersNames = new List<string>();

            foreach (string time in timesOfCreatingCharacters)
            {
                if (fileNames[i] == "1807-_template.md") { continue; }

                bool intOrString = Int32.TryParse(time, out charsWithGivenTime);

                if (intOrString == false){ emptyCounter++; }

                i++;
            }

            return emptyCounter;
        }

        private static int charactersWithGivenTime(List<string> timesOfCreatingCharacters, List<string> fileNames)
        {
            int charsWithGivenTime = 0;
            int i = 0;
            List<string> emptyCharactersNames = new List<string>();

            foreach (string time in timesOfCreatingCharacters)
            {
                bool intOrString = Int32.TryParse(time, out charsWithGivenTime);

                if (intOrString == true)
                {
                    charsWithGivenTime++;
                }

                i++;
            }

            return charsWithGivenTime;
        }

        private static List<string> charactersWithoutGivenTime(List<string> timesOfCreatingCharacters, List<string> fileNames)
        {
            int charsWithGivenTime;
            int emptyCounter = 0;
            int i = 0;
            List<string> emptyCharactersNames = new List<string>();

            foreach (string time in timesOfCreatingCharacters)
            {
                if (fileNames[i] == "1807-_template.md") { continue; }

                bool intOrString = Int32.TryParse(time, out charsWithGivenTime);

                if (intOrString == false)
                {
                    emptyCounter++;
                    emptyCharactersNames.Add(fileNames[i]);
                }

                i++;
            }


            return emptyCharactersNames;
        }

        private static int sumAllTimes(List<string> timesOfCreatingCharacters)
        {
            int sumOfTimes = 0;
            int intTime;
            foreach(string time in timesOfCreatingCharacters)
            {
               Int32.TryParse(time, out intTime);
               sumOfTimes += intTime;
            }

            return sumOfTimes;
        }

        private static List<string> getMultiTimes(List<string> contentOFileNames)
        {
            List<string> allTimes = new List<string>();
            foreach(string time in contentOFileNames)
            {
                if (time != "") { allTimes.Add(getTimeFromFileContent(time)); };
            }

            return allTimes;
        }

        private static List<string> openMultiFiles(List<string> fileNames, string path)
        {
            List<string> contentOfAllFiles = new List<string>();
            foreach(string file in fileNames)
            {
                contentOfAllFiles.Add(readFile(path + @"\" + file));
            }

            return contentOfAllFiles;
        }

        private static string getTimeFromFileContent(string fileContent)
        {
            TextParser reader = new TextParser();

            string time = reader.ExtractTimeToCreate(fileContent);
            return time;
        }

        private static string readFile(string path)
        {
            string fileContent = File.ReadAllText(path);
            return fileContent;
        }
    }
}
