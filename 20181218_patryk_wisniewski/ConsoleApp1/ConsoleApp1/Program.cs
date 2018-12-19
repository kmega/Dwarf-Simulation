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
            TakThree(dictionaryPath);

            string dicionaryPathStory = "C:/Users/Lenovo/code/primary/20181218/cybermagic/opowiesci";
            TaskFour(dicionaryPathStory);

            //Regex regex = new Regex(@"(\d\d) min.*"); aaaaaaaaaaaaaa
            //string[] digits = Regex.Split(sentence, @"\D+");
            //zadanie 2
            /*string[] digits = Regex.Split(information, @"\((\d\d) min.*\)");

            */
        }

        private static void TaskFour(string dicionaryPathStory)
        {
            string PathFileToSave = "E:/Informacje/result_task4.txt";
            foreach (string file in Directory.EnumerateFiles(dicionaryPathStory, "*.md"))
            {
                string lecture = "";
                string contents = File.ReadAllText(file);
                TextParser textParser = new TextParser();
                string Magda = textParser.ExtractStuffWithMagda(contents);
                if (Magda != "")
                {
                    string[] words = file.Split('-');
                    for (int i = 1; i < words.Length; i++)
                    {
                        lecture += words[i] + " ";
                    }
                    lecture = lecture.Remove(lecture.Length - 3);
                    SaveFileName(PathFileToSave, lecture);
                }

            }
        }

        private static void TakThree(string dictionaryPath)
        {
            string PathFileToSave = "E:/Informacje/result_task3.txt";

            int fullTime = 0;
            int counter = 0;
            foreach (string file in Directory.EnumerateFiles(dictionaryPath, "*.md"))
            {
                string[] words = file.Split('-');
                if (words[2] != "_template.md")
                {
                    string contents = File.ReadAllText(file);
                    TextParser textParser = new TextParser();
                    string time = textParser.ExtractTimeToCreate(contents);
                    if (time != "")
                    {
                        fullTime += int.Parse(time);
                        counter++;
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
            }
            int Avg = fullTime / counter;
            SaveFullTime(PathFileToSave, fullTime, Avg);
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
            StreamWriter SW = FastSave(whereSave);
            SW.WriteLine("Czas tworzenia pliku to: " + toWrite);
            SW.Close();

        }

        private static StreamWriter FastSave(string whereSave)
        {
            return File.AppendText(whereSave);
        }

        public static void SaveFileName(string whereSave, string toWrite)
        {
            StreamWriter SW = FastSave(whereSave);
            SW.WriteLine("Nazwa postaci: " + toWrite);
            SW.Close();
        }

        public static void SaveFullTime(string whereSave, int toWrite, int AVG)
        {
            StreamWriter SW = FastSave(whereSave);
            int hours = 0;
            int minutes = 0;
            hours = toWrite / 60;
            minutes = toWrite % 60;
            SW.WriteLine("Pełny czas tworzenia postaci wynosi: " + toWrite + ". A średni czas to: " + AVG
                + " Łączny czas na tworzenie postaci zajął " + hours+ " godzin i " + minutes+ " minut");
            SW.Close();
        }

        public static void SaveNameFile(string whereSave, string toWrite)
        {
            StreamWriter SW = FastSave(whereSave);
            SW.WriteLine("Magda wystąpiła tutaj " + toWrite);
            SW.Close();
        }
    }
}
