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
            /* TaskOne(dictionaryPath);
             TaskTwo(dictionaryPath);
             TakThree(dictionaryPath);
             */
            string dicionaryPathStory = "C:/Users/Lenovo/code/primary/20181218/cybermagic/opowiesci";
            //TaskFour(dicionaryPathStory);

            string pathSelectCommand = "E:/Informacje/kalarepa.md";

            TaskFive(dictionaryPath, dicionaryPathStory, pathSelectCommand);


            foreach (string file in Directory.EnumerateFiles(dictionaryPath, "*.md"))
            {
                string contents = File.ReadAllText(file);
                TextParser textParser = new TextParser();
                string Magda = textParser.ExtractStuffWithKalina(contents);
                Console.WriteLine(Magda);
            }
            Console.ReadKey();

        }

        private static void TaskFive(string dictionaryPath, string dicionaryPathStory, string pathSelectCommand)
        {
            string contents = File.ReadAllText(pathSelectCommand);
            string[] result2 = Regex.Split(contents, @"[^\d]+");

            bool doneOrNot = ToDoTask(result2);
            if (doneOrNot)
            {
                DoTask(result2, dictionaryPath, dicionaryPathStory);
            }
        }

        private static void DoTask(string[] result2, string dictionaryPath, string dicionaryPathStory)
        {
            for (int i = 0; i < result2.Length; i++)
            {
                int numberTask = int.Parse(result2[i]);
                switch (numberTask)
                {
                    case 1:
                        TaskOne(dictionaryPath);
                        break;
                    case 2:
                        TaskTwo(dictionaryPath);
                        break;
                    case 3:
                        TakThree(dictionaryPath);
                        break;
                    case 4:
                        TaskFour(dicionaryPathStory);
                        break;
                    default:
                        break;
                }
            }
        }

        private static bool ToDoTask(string[] v)
        {
            int counter = 0;
            for (int i = 0; i < v.Length; i++)
            {
                if (int.Parse(v[i]) > 5)
                {
                    counter++;
                }
            }
            if (counter != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
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
                    lecture = lecture.Remove(lecture.Length - 4);
                    SaveFile(PathFileToSave, lecture);
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
                        string name = "Nazwa postaci to: "+textParser.ExtractProfileName(contents);
                        if (name != "Nazwa postaci to: ")
                        {
                            SaveFile(PathFileToSave, name);
                        }
                    }
                }
            }
            int Avg = fullTime / counter;
            string saveText = "Pełny czas tworzenia postaci wynosi: " + fullTime + " A średni " +
                "czas tworzenia to: " + Avg +" Poświęcono na to łącznie: " + fullTime/60 +
                " godzin oraz " + fullTime%60+ " minut";
            SaveFile(PathFileToSave, saveText);
        }

        private static void TaskTwo(string dictionaryPath)
        {
            string PathFileToSave = "E:/Informacje/result_task2.txt";

            foreach (string file in Directory.EnumerateFiles(dictionaryPath, "*.md"))
            {
                string contents = File.ReadAllText(file);
                TextParser textParser = new TextParser();
                string time = "Czas tworzenia postaci to: " + textParser.ExtractTimeToCreate(contents);
                if (time != "Czas tworzenia postaci to: ")
                    SaveFile(PathFileToSave, time);
            }
        }

        private static void TaskOne(string dictionaryPath)
        {
            string fileName = "/1807-fryderyk-komciur.md";
            string PathFileToSave = "E:/Informacje/result_task1.txt";
            string time = "Czas tworzenia postaci to: " + GetTime(dictionaryPath + fileName);
            SaveFile(PathFileToSave, time);
        }

        public static string GetTime(string path)
        {
            TextParser textParser = new TextParser();
            string information = File.ReadAllText(path);
            string time = textParser.ExtractTimeToCreate(information);
            return time;
        }
        
        public static void SaveFile(string whereSave, string toWrite)
        {
            StreamWriter SW = FastSave(whereSave);
            SW.WriteLine(toWrite);
            SW.Close();
        }

        private static StreamWriter FastSave(string whereSave)
        {
            return File.AppendText(whereSave);
        }

    }
}
