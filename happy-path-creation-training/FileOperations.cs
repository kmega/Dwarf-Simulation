using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace happy_path_creation_training
{
    class FileOperations
    {
        public static string ConvertFileToString(string path)
        {
            return File.ReadAllText(path);
        }

        public static string CreateStringToSave(params string[] extractedParams)
        {
            StringBuilder resultString = new StringBuilder();
            resultString.Append(extractedParams[0] + " był budowany przez " + extractedParams[1] + " minuty");
            return resultString.ToString();
        }

        public static List<string> ExtractCharactersWithOutTimeBuild(string[] stringFiles)
        {
            List<string> stringFilesList = stringFiles.ToList();
            List<string> charactersWithOutBuildTime = new List<string>();
            foreach (var item in stringFilesList)
            {
                if (String.IsNullOrEmpty(item))
                {
                    charactersWithOutBuildTime.Add(TextParser.ExtractProfileName(item));
                }
                
            }
            return charactersWithOutBuildTime;
        }

        public static string[] ExtractBuildTimesFromFile(string[] stringFiles)
        {
            List<string> timeBuilds = new List<string>();
            foreach (var item in stringFiles)
            {
                timeBuilds.Add(TextParser.ExtractTimeToCreate(item));
            }

            return timeBuilds.ToArray();
        }

       

        public static string CreateStringToSave2(string[] buildTimes)
        {
            double buildTimeSum = 0;
            foreach (var item in buildTimes)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    buildTimeSum += double.Parse(item);
                }
            }
            TimeSpan ts = TimeSpan.FromMinutes(buildTimeSum);
            return "Wszystkie postacie do tej pory budowane były " + ts.Hours + " godzin " + ts.Minutes +" minut";
        }

        public static string[] ConvertAllFilesToString(string[] fileNames)
        {
            List<string> fileStrings = new List<string>();
            foreach (var item in fileNames)
            {
                fileStrings.Add(FileOperations.ConvertFileToString(item));
            }
            return fileStrings.ToArray();

        }

        public static string[] ReadAllFileNamesFromDirectory(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            List<string> listOfFileNames = new List<string>();
            foreach (var fi in di.GetFiles())
            {
                listOfFileNames.Add(path + fi.Name);
            }
            return listOfFileNames.ToArray();
        }

        public static void SaveToFile(string path, string stringOutput)
        {
            File.WriteAllText(path, stringOutput);
        }
    }
}
