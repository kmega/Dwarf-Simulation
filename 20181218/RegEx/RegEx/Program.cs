using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using VivaRegex;

namespace RegEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathFKomciur = @"C:\Code\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
            string pathAllPeople = @"C:\Code\primary\20181218\cybermagic\karty-postaci";
            string pathTask4 = @"C:\Code\primary\20181218\cybermagic\opowiesci";
            string result1 = @"C:\Code\primary\20181218\RegEx\RegEx\result1.txt";
            string result2 = @"C:\Code\primary\20181218\RegEx\RegEx\result2.txt";
            string result3 = @"C:\Code\primary\20181218\RegEx\RegEx\result3.txt";
            string result4 = @"C:\Code\primary\20181218\RegEx\RegEx\result4.txt";

            // task1
            //string ReadSingleFile(filePath) -> textFromFile
            //string GetTime(text) -> time
            //string GetName(text) -> name
            //CombineResults(name + time) -> result
            //WriteResultToFile()

            string textKomciur = ReadSingleFile(pathFKomciur);
            string nameKomciur = GetName(textKomciur);
            string timeKomciur = GetTime(textKomciur);
            string resultKomciur = CombineResults(nameKomciur, timeKomciur);
            WriteResultToFile(result1, resultKomciur);

            //task 2
            //List<string> ReadingAllPeopleTxt(string path) -> List<string> allPeopleText
            //list<int> GetTimeFromAll(List<string> allPeopleText) -> lista wszystkich czasow
            //int SumOfAllTimes(List<Int32> allPeopleTimes) -> int allTimesSum;
            //WriteResultToFile(result2, allTimesSum)

            List<string> allPeopleText =  ReadingAllPeopleText(pathAllPeople);
            List<Int32> allPeopleTimes = GetTimesFromAll(allPeopleText);
            WriteResultToFile(result2, AllTimeSumResult(allPeopleTimes));


            //task 3
            //AverageTime(int allPeopleTimes) -> int averageTime
            //CharactersWithoOutTime() -> list<string> peopleWithOutTime
            //string ProbableBuildTime(int averageTime, list<string> allPeopleWithoutTime) -> string probableBuildTime
            int averageTime = AverageTime(allPeopleTimes);
            List<string> allPeopleWithoutTime = CharactersWithoutTime(allPeopleText);
            string resultOfTask3 = ProbableBuildTime(averageTime, allPeopleWithoutTime, allPeopleTimes);
            WriteResultToFile(result3, resultOfTask3);

            //task 4 
            //ReadingAllPeopleText() -> lista Wszystkich odpowiesci
            //searchmagda -> lista opowiesci gdzie wystepuje magda
            //ResultMagda() -> string result4
            List<string> storiesText = ReadingAllPeopleText(pathTask4);
            List<string> storiesMagdaPatiril = SearchMagdaPatiril(storiesText);
            WriteResultToFile(result4, ResultMagda(storiesMagdaPatiril));



            
        }

        private static string ResultMagda(List<string> storiesMagdaPatiril)
        {
            string result = "Magda Patiril występowała w następujących Opowieściach:";
            foreach(string story in storiesMagdaPatiril)
            {
                result += Environment.NewLine + story;
            }
            return result;
        }

        private static List<string> SearchMagdaPatiril(List<string> storiesText)
        {
            List<string> storiesMagdaPatiril = new List<string>();
            TextParser tp = new TextParser();
            foreach(string person in storiesText)
            {
                if(tp.ExtractStuffWithMagda(person) != "")
                {
                    storiesMagdaPatiril.Add(tp.ExtractStoryName(person));
                }
            }

            return storiesMagdaPatiril;
        }

        public static string AllTimeSumResult(List<int> allPeopleTimes)
        {
            int sumTimes = SumOfAllTimes(allPeopleTimes);
            int hour = sumTimes / 60;
            int minutes = sumTimes % 60;
            string allTimesSum = $"Wszystkie postacie do tej pory byly budowane {hour} godzin i  {minutes} minut.";
            return allTimesSum;
        }

        public static string ProbableBuildTime(int averageTime, List<string> allPeopleWithoutTime, List<Int32> allPeopleTimes)
        {
            int probableTimeOfAllPeopleWithoutTime = averageTime * allPeopleWithoutTime.Count();
            int probableSum = SumOfAllTimes(allPeopleTimes) + probableTimeOfAllPeopleWithoutTime;
            string result = $"Uwzględniając powyższe, postacie do tej pory budowane były najpewniej " +
                $"{probableSum} minut"; 

            return result;
        }

        public static List<string> CharactersWithoutTime(List<string> allPeopleText)
        {
            TextParser tp = new TextParser();
            List<string> allPeopleWithoutTime = new List<string>();
            foreach(string person in allPeopleText)
            {
                if(tp.ExtractTimeToCreate(person) == "" && tp.ExtractProfileName(person) != "")
                {
                    allPeopleWithoutTime.Add(tp.ExtractProfileName(person));
                }
            }

            return allPeopleWithoutTime;
        }

        public static int AverageTime(List<Int32> allPeopleTimes)
        {
            int averageTime = allPeopleTimes.Sum() / allPeopleTimes.Count();
            return averageTime;
        }

        public static int SumOfAllTimes(List<Int32> allPeopleTimes)
        {
            int allTimesSum = allPeopleTimes.Sum();
            return allTimesSum;
        }

        public static List<Int32> GetTimesFromAll(List<string> allPeopleText)
        {
            List<Int32> allTimeList = new List<int>();

            foreach(var people in allPeopleText)
            {
                if(GetTime(people) != "")
                {
                    allTimeList.Add(Int32.Parse(GetTime(people)));
                }
            }
            return allTimeList;
        }

        public static List<string> ReadingAllPeopleText(string path)
        {
            List<string> allPeopleText = new List<string>();
            foreach(var file in Directory.EnumerateFiles(path, "*.md"))
            {
                allPeopleText.Add(ReadSingleFile(file));
            }
            return allPeopleText;
        }

        public static void WriteResultToFile(string fileResultPath, string result)
        {
            File.WriteAllText(fileResultPath, result);
        }

        public static string CombineResults(string name, string time)
        {
            string result = $"{name} byl budowany {time} minuty";
            return result;
        }

        public static string GetName(string text)
        {
            TextParser tp = new TextParser();
            string name = tp.ExtractProfileName(text);
            return name;
        }

        public static string GetTime(string text)
        {
            TextParser tp = new TextParser();
            string time = tp.ExtractTimeToCreate(text);
            return time;
        }

        public static string ReadSingleFile(string filePath)
        {
            string textFromFile = File.ReadAllText(filePath);
            return textFromFile;
        }
    }
}
