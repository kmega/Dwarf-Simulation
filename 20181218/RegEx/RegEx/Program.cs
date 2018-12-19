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
            // task1
            //string ReadSingleFile(filePath) -> textFromFile
            //string GetTime(text) -> time
            //string GetName(text) -> name
            //CombineResults(name + time) -> result
            //WriteResultToFile()
           
            string pathFKomciur = @"C:\Code\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
            string pathWszyscy = @"C:\Code\primary\20181218\cybermagic\karty-postaci";
            string result1 = @"C:\Code\primary\20181218\RegEx\RegEx\result1.txt";
            string result2 = @"C:\Code\primary\20181218\RegEx\RegEx\result2.txt";

            string textKomciur = ReadSingleFile(pathFKomciur);
            string nameKomciur = GetName(textKomciur);
            string timeKomciur = GetTime(textKomciur);
            string resultKomciur = CombineResults(nameKomciur, timeKomciur);
            WriteResultToFile(result1, resultKomciur);
            
            //task 2
            /*
            StreamWriter result2File = new StreamWriter(result2);
            foreach (var element in Directory.EnumerateFiles(pathWszyscy, "*.md"))
            {
                string wszyscy = File.ReadAllText(element);
                TextParser tp2 = new TextParser();
                timeWszyscy = tp2.ExtractTimeToCreate(wszyscy);

                if (timeWszyscy != "")
                {
                    allTime += Int32.Parse(timeWszyscy);
                }
            }
            result2File.WriteLine("Czas tworzenia wszystkich bahaterów to: {0} minuty", allTime);
            result2File.Close();
            */
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
