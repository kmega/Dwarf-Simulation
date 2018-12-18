using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
namespace RegexTraining
{
    class Program
    {
        public static void Task1(string inputPath,string outputPath)
        {
            TextParser textParser = new TextParser();
            string profilName = "";
            string timeToCreate = "";
            StringBuilder stringBuilder = new StringBuilder();
            using (StreamReader streamReader = new StreamReader(inputPath))
            {
                string line = "";
                while ((line = streamReader.ReadLine()) != null)
                {
                    stringBuilder.AppendLine(line);
                }
            }
            profilName = textParser.ExtractProfileName(stringBuilder.ToString());
            timeToCreate = textParser.ExtractTimeToCreate(stringBuilder.ToString());
            using (StreamWriter streamWriter = new StreamWriter(outputPath))
            {
                streamWriter.WriteLine('"' + "{0} był budowany {1} minuty" + '"',profilName,timeToCreate);
            }





        }
        public static int getTimeToCreateFromFile(string inputPath)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (StreamReader streamReader = new StreamReader(inputPath))
            {
                string line = "";
                while((line = streamReader.ReadLine()) != null)
                {
                    stringBuilder.AppendLine(line);
                }         
            }
            TextParser textParser = new TextParser();
            string timeToCreateAsString = textParser.ExtractTimeToCreate(stringBuilder.ToString());
            int result = timeToCreateAsString.Equals(string.Empty) ? 0 : Int32.Parse(timeToCreateAsString);
            return result;
        }
        public static void Task2(string inputDirectoryPath,string outputPath)
        {
            // folder(lista plików) -> czas budowania wszystkich postaci (int)
            string[] fileArray = Directory.GetFiles(inputDirectoryPath);
            int counter = 0;
            foreach(string file in fileArray)
            {
                counter += getTimeToCreateFromFile(file);
            }
            int hours = counter / 60;
            int minutes = counter % 60;
            using (StreamWriter streamWriter = new StreamWriter(outputPath))
            {
                streamWriter.WriteLine("Wszystkie postacie do tej pory budowane były {0} godzin {1} minut",hours,minutes);
            }

        }
        static void Main(string[] args)
        {
            Task1(@"C:\Users\Lenovo\Desktop\Zajecia\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md", @"C:\Users\Lenovo\Desktop\Zajecia\primary\20181218\RegexTraining\RegexTraining\outputTask1.txt");
            Task2(@"C:\Users\Lenovo\Desktop\Zajecia\primary\20181218\cybermagic\karty-postaci\", @"C:\Users\Lenovo\Desktop\Zajecia\primary\20181218\RegexTraining\RegexTraining\outputTask2.txt");
            Console.ReadKey();
        }
    }
}
