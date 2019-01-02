using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AllTasksInOne
{
    public class Task3
    {
        public void Main()
        {
            //List<string> paths = GetPaths(folderPath);
            string folderPath = @"C:\Users\Piotr\Desktop\GitLab\primary\20181218\cybermagic\karty-postaci";
            List<string> pathsInFolder = GetPaths(folderPath);

            //List<string> ignoretemplate = IgnoreTemplate(paths)
            List<string> finalPaths = IgnoreTemplate(pathsInFolder);

            //List<string> noTimeList -> GetCharWithoutTime(finalPaths)
            (List<string> noTimeList, double avgTime) = GetCharWithoutTime(finalPaths);

            //noTimeList, avgTime -> SaveToFile
            SaveToFile(noTimeList, avgTime);
            DisplayResult(noTimeList, avgTime);
        }

        private void DisplayResult(List<string> noTimeList, double avgTime)
        {
            Console.WriteLine("### Task 3:");
            Console.WriteLine("Postacie, które nie mają podanego czasu to:");
            Console.WriteLine("");
            foreach (string character in noTimeList)
            {
                Console.WriteLine("* {0}", character);
            }
            Console.WriteLine("");
            Console.WriteLine("Średni czas budowania postaci to: {0} minut.", avgTime);
            Console.WriteLine();
        }

        private void SaveToFile(List<string> noTimeList, double avgTime)
        {
            StreamWriter streamWriter = new StreamWriter(@"C:\Users\Piotr\Desktop\GitLab\primary\20181218\AllTasksInOne\AllTasksInOne\Results\Result3.txt");

            streamWriter.WriteLine("Postacie, które nie mają podanego czasu to:");
            streamWriter.WriteLine("");
            foreach (string character in noTimeList)
            {
                streamWriter.WriteLine("* {0}", character);
            }
            streamWriter.WriteLine("");
            streamWriter.WriteLine("Średni czas budowania postaci to: {0} minut.", avgTime);
            streamWriter.Close();
        }

        private (List<string> noTimeList, double avgTime) GetCharWithoutTime(List<string> finalPaths)
        {
            List<string> returnListWithoutTime = new List<string>();
            TextParser textParser = new TextParser();
            double returnAVGtime = 0;
            int iterator = 0;

            foreach (string path in finalPaths)
            {
                string tempContent = File.ReadAllText(path);
                string tempTime = textParser.ExtractTimeToCreate(tempContent);
                if(tempTime == string.Empty)
                {
                    string tempName = textParser.ExtractProfileName(tempContent);
                    returnListWithoutTime.Add(tempName);
                }
                else
                {
                    returnAVGtime += Convert.ToInt32(tempTime);
                    iterator++;
                }
            }
            return (returnListWithoutTime, returnAVGtime / iterator);
        }

        private List<string> IgnoreTemplate(List<string> pathsInFolder)
        {
            List<string> returnList = new List<string>();

            foreach (string path in pathsInFolder)
            {
                if(!path.Contains("template"))
                {
                    returnList.Add(path);
                }
            }
             
            return returnList;
        }

        private List<string> GetPaths(string folderPath)
        {
            return Directory.GetFiles(folderPath).ToList();
        }
    }
}
