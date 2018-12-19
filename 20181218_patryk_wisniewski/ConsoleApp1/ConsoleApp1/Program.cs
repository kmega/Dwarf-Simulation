using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using VivaRegex;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string dictionaryPath = "C:/Users/Lenovo/code/primary/20181218/cybermagic/karty-postaci";
            TaskOne(dictionaryPath);
            TaskTwo(dictionaryPath);

            string PathFileToSave = "E:/Informacje/result_task3.txt";

            int fullTime = 0;
            foreach (string file in Directory.EnumerateFiles(dictionaryPath, "*.md"))
            {
                string contents = File.ReadAllText(file);
                TextParser textParser = new TextParser();
                string time = textParser.ExtractTimeToCreate(contents);
                if (time != "")
                {
                    fullTime += int.Parse(time);
                }
                else
                {
                    string name = textParser.ExtractProfileName(contents);
                    if (name != "")
                    {
                        SaveFileName(PathFileToSave, name);
                    }                    
                }                    
            }
            //Regex regex = new Regex(@"(\d\d) min.*"); aaaaaaaaaaaaaa
            //string[] digits = Regex.Split(sentence, @"\D+");
            //zadanie 2
            /*string[] digits = Regex.Split(information, @"\((\d\d) min.*\)");

            */
        }

        private static void TaskTwo(string dictionaryPath)
        {
            string PathFileToSave = "E:/Informacje/result_task2.txt";

            foreach (string file in Directory.EnumerateFiles(dictionaryPath, "*.md"))
            {
                string contents = File.ReadAllText(file);
                TextParser textParser = new TextParser();
                string time = textParser.ExtractTimeToCreate(contents);
                if (time != "")
                    SaveFile(PathFileToSave, time);
            }
        }

        private static void TaskOne(string dictionaryPath)
        {
            string fileName = "/1807-fryderyk-komciur.md";
            string PathFileToSave = "E:/Informacje/result_task1.txt";
            string time = GetTime(dictionaryPath + fileName);
            SaveFile(PathFileToSave, time);
        }

        public static string GetTime(string path)
        {
            TextParser textParser = new TextParser();
            string information = File.ReadAllText(path);
            Console.WriteLine("Static void method");
            string time = textParser.ExtractTimeToCreate(information);
            return time;
        }
        
        public static void SaveFile(string whereSave, string toWrite)
        {
            StreamWriter SW;
            SW = File.AppendText(whereSave);
            SW.WriteLine("Czas tworzenia pliku to: " + toWrite);
            SW.Close();

        }

        public static void SaveFileName(string whereSave, string toWrite)
        {
            StreamWriter SW;
            SW = File.AppendText(whereSave);
            SW.WriteLine("Nazwa postaci: " + toWrite);
            SW.Close();
        }
    }
}
