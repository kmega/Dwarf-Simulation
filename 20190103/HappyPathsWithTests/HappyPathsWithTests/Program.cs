using System;
using System.IO;

namespace HappyPathsWithTests
{
    class Program
    {
        static void Main(string[] args)
        {
            new Task1().Displayresults();

            Console.ReadKey();
        }
    }

    public class Task1
    {
        public void Displayresults()
        {
            string path = @"..\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
            string preForm = "{0} był budowany {1} minuty";

            Console.WriteLine("### Task 1");
            Console.WriteLine(preForm, GetName(path), GetTime(path));
            Console.WriteLine();

            new Methods().SaveToFile(@"..\Results\Result1.txt", GetName(path), GetTime(path), preForm);
        }

        public int GetTime(string path)
        {
            string openedFile = new Methods().ReadFile(path);
            return Convert.ToInt32(new TextParser().ExtractTimeToCreate(openedFile));
        }

        public string GetName(string path)
        {
            string openedFile = new Methods().ReadFile(path);
            return new TextParser().ExtractProfileName(openedFile);
        }
    }

    public class Task2
    {

    }



    class Methods
    {
        public void SaveToFile(string resultPath, string name, int time, string preForm)
        {
            StreamWriter streamWriter = new StreamWriter(resultPath);
            streamWriter.WriteLine(preForm, name, time);
            streamWriter.Close();
        }

        public string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
    
}
