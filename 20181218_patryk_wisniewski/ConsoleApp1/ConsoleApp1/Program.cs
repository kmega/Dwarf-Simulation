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
            //Regex regex = new Regex(@"(\d\d) min.*"); aaaaaaaaaaaaaa
            //string[] digits = Regex.Split(sentence, @"\D+");
            //zadanie 2
            /*string[] digits = Regex.Split(information, @"\((\d\d) min.*\)");
            string folderPath = @"C:\Users\Lenovo\code\primary\20181218\cybermagic\karty-postaci";
            foreach (string file in Directory.EnumerateFiles(folderPath, "*.md"))
            {
                string contents = File.ReadAllText(file);
                Console.WriteLine(contents);
            }*/
            TextParser textParser = new TextParser();
       
            string information = File.ReadAllText(@"C:\Users\Lenovo\code\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md");
            
            string time = textParser.ExtractTimeToCreate(information);
            
            string path = @"E:\Informacje\result_task1.txt";
            StreamWriter resulutTask1 = new StreamWriter(path);
            resulutTask1.Write("Czas tworzenia pliku to: " + time);
            resulutTask1.Close();
            Console.ReadKey();
        }
    }
}
