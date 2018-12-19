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

        public static string getProfileNameFromFile(string inputPath)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (StreamReader streamReader = new StreamReader(inputPath))
            {
                string line = "";
                while ((line = streamReader.ReadLine()) != null)
                {
                    stringBuilder.AppendLine(line);
                }
            }
            TextParser textParser = new TextParser();
            string profileName = textParser.ExtractProfileName(stringBuilder.ToString());
            return profileName;
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
        public static void Task3(string directoryPath,string outputPath)
        {
            // GIVEN : Directory,file to ignore, result pattern, outputPath
            // getFilesFromDir(direcory) -> filesList
            // Remove _template.md files from fileList -> fileList
            // for each file in filesList:
            //      getTimeFromFile(file) -> timesToCreateForEachElement -list
            // getFilesWithoutTimeToCreate(List timesToCreateForEachElement) -> FilesWithoutTimeToCreate
            // getFilesWithTimeToCreate(timesToCreateForEachElement - FilesWithoutTimeToCreate) -> FilesWithTimeToCreate-list
            // getAvgTimeToCreate(FilesWithTimeToCreate) -> AvgTimeToCreate-int
            // getHypotheticalTime(AvgTimeToCreate,FilesWithoutTimeToCreate) -> HypotheticalTime
            // getStrigResult(result pattern,FilesWithoutTimeToCreate,AvgTimeToCreate,HypotheticalTime) -> stringResult
            // WriteFile(stringResult,outputPath) -> End
            //
            List<string> fileList = getFileList(directoryPath).ToList();
            fileList.RemoveAll(x => x.Contains("_template.md"));
            List<int> timesToCreate = new List<int>();
            List<string> profileNamesWithoutTimesToCreate = new List<string>();
            foreach (string file in fileList)
            {
                int timeToCreate = getTimeToCreateFromFile(file);
                if (timeToCreate != 0)
                    timesToCreate.Add(timeToCreate);
                else
                    profileNamesWithoutTimesToCreate.Add(getProfileNameFromFile(file));
            }
            int averageTimeToCreate = (int)timesToCreate.Average();
            int hypotheticalTime = averageTimeToCreate * profileNamesWithoutTimesToCreate.Count;
            string resultString = "Postacie, które nie mają podanego czasu to: \n";
            foreach (string profileName in profileNamesWithoutTimesToCreate)
                resultString += profileName + "\n";
            resultString += "Średni czas budowania postaci to: " + averageTimeToCreate + " minut.\n";
            resultString += "Uwzględniając powyższe, postacie do tej pory budowane były najpewniej " + hypotheticalTime/60 + " godzin " + hypotheticalTime % 60 +" minut.";
            WriteFile(resultString, outputPath);
        }
        static void Main(string[] args)
        {
            Task1(@"C:\Users\Lenovo\Desktop\Zajecia\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md", @"C:\Users\Lenovo\Desktop\Zajecia\primary\20181218\RegexTraining\RegexTraining\outputTask1.txt");
            Task2(@"C:\Users\Lenovo\Desktop\Zajecia\primary\20181218\cybermagic\karty-postaci\", @"C:\Users\Lenovo\Desktop\Zajecia\primary\20181218\RegexTraining\RegexTraining\outputTask2.txt");
            Task3(@"C:\Users\Lenovo\Desktop\Zajecia\primary\20181218\cybermagic\karty-postaci\", @"C:\Users\Lenovo\Desktop\Zajecia\primary\20181218\RegexTraining\RegexTraining\outputTask3.txt");
            Console.ReadKey();
            
        }
    }
}
