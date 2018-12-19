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
            // GIVEN : filePath, outputPath, profileName, result pattern
            // getTimeToCreateFromFile(filePath) -> timeToCreate -int
            // prepareStringToSave(result pattern -> stringToSave - string
            // WriteFile(stringToSave,path) -> End
            string profileName = "Fryderyk Komciur";
            int timeToCreate = getTimeToCreateFromFile(inputPath);
            string stringToSave = profileName + " był budowany " + timeToCreate + " minuty.";
            WriteFile(stringToSave, outputPath);
        }
        public static void WriteFile(string content,string filePath)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                streamWriter.WriteLine(content);
            }
        }
        public static string[] getFileList(string directoryPath)
        {
            string[] filePaths = Directory.GetFiles(directoryPath);
            return filePaths;

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
        
        public static void Task2(string directoryPath,string outputPath)
        {
            // Zapisz do pliku, ile czasu zajęło budowanie WSZYSTKICH postaci z folderu
            // GIVEN: DirectoryPath, result pattern
            // getFileList(directorypath -> string[] filePaths - str array
            // for each file in filePaths:
            //      getTimeFromFile(file) 
            //                           -> ListOfEachTimeToCreate -list
            // Sum(listOfEachTimeToCreate) -> sumAllElements -int
            // Calculate hours and minutes from sumAllElements -> hours,minutes
            // CombineString(result pattern ,hour ,minutes) -> resultString -str
            // WriteFile(resultString,outputPath) -> End
            string[] filesInDirectory = getFileList(directoryPath);
            List<int> timeToCreateForEachFile = new List<int>();
            foreach(string filePath in filesInDirectory)
                timeToCreateForEachFile.Add(getTimeToCreateFromFile(filePath));
            int sumAllElements = timeToCreateForEachFile.Sum();
            int hours = sumAllElements / 60;
            int minutes = sumAllElements % 60;
            string resultString = "Wszystkie postacie do tej pory budowane były " + hours + " godzin " + minutes + " minut";
            WriteFile(resultString, outputPath);
        }
        static void Main(string[] args)
        {
            Task1(@"C:\Users\Lenovo\Desktop\Zajecia\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md", @"C:\Users\Lenovo\Desktop\Zajecia\primary\20181218\RegexTraining\RegexTraining\outputTask1.txt");
            Task2(@"C:\Users\Lenovo\Desktop\Zajecia\primary\20181218\cybermagic\karty-postaci\", @"C:\Users\Lenovo\Desktop\Zajecia\primary\20181218\RegexTraining\RegexTraining\outputTask2.txt");
            Console.ReadKey();
            
        }
    }
}
