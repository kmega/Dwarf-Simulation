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
            string result1 = @"C:\Code\primary\20181218\RegEx\RegEx\result1.txt";
            string result2 = @"C:\Code\primary\20181218\RegEx\RegEx\result2.txt";
            string result3 = @"C:\Code\primary\20181218\RegEx\RegEx\result3.txt";

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
            string allTimesSum = "Wszystkie postacie do tej pory byly budowane " +
                Convert.ToString(SumOfAllTimes(allPeopleTimes)) + " minuty";
            WriteResultToFile(result2, allTimesSum);


            //task 3
            //AverageTime(int allPeopleTimes) -> int averageTime
            int averageTime = AverageTime(allPeopleTimes);
            //CharactersWithoOutTime() -> list<string> peopleWithOutTime
            List<string> allPeopleWithoutTime = CharactersWithoutTime(allPeopleText);
            //
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
            throw new NotImplementedException();
        }

        public static int AverageTime(List<Int32> allPeopleTimes)
        {
            int averageTime = allPeopleTimes.Sum() / allPeopleTimes.Count();
            return averageTime;
            throw new NotImplementedException();
        }

        public static int SumOfAllTimes(List<Int32> allPeopleTimes)
        {
            int allTimesSum = allPeopleTimes.Sum();
            return allTimesSum;
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public static List<string> ReadingAllPeopleText(string path)
        {
            List<string> allPeopleText = new List<string>();
            foreach(var file in Directory.EnumerateFiles(path, "*.md"))
            {
                allPeopleText.Add(ReadSingleFile(file));
            }
            return allPeopleText;
            throw new NotImplementedException();
        }

        public static void WriteResultToFile(string fileResultPath, string result)
        {
            File.WriteAllText(fileResultPath, result);
        }

        public static string CombineResults(string name, string time)
        {
            string result = $"{name} byl budowany {time} minuty";
            return result;
            throw new NotImplementedException();
        }

        public static string GetName(string text)
        {
            TextParser tp = new TextParser();
            string name = tp.ExtractProfileName(text);
            return name;
            throw new NotImplementedException();
        }

        public static string GetTime(string text)
        {
            TextParser tp = new TextParser();
            string time = tp.ExtractTimeToCreate(text);
            return time;
            throw new NotImplementedException();
        }

        public static string ReadSingleFile(string filePath)
        {
            string textFromFile = File.ReadAllText(filePath);
            return textFromFile;
            throw new NotImplementedException();
        }
    }
}
