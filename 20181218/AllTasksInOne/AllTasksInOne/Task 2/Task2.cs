using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AllTasksInOne
{
    public class Task2
    {
        public void Main()
        {
            string folderPath = @"C:\Users\Piotr\Desktop\GitLab\primary\20181218\cybermagic\karty-postaci";
            string[] allFiles = GetPaths(folderPath);
            //long ver
            //int totalTime = GetTotalTime(allFiles);
            //(int hours, int minutes) = GetFinalTime(totalTime);

            //short ver
            (int hours, int minutes) = GetFinalTime(GetTotalTime(allFiles));
            DisplayResult(hours, minutes);
            SaveToFile(hours, minutes);
        }

        private void DisplayResult(int hours, int minutes)
        {
            Console.WriteLine("### Task 2:");
            Console.WriteLine("Wszystkie postacie do tej pory budowane były {0} godzin {1} minut", hours, minutes);
            Console.WriteLine();
        }

        private void SaveToFile(int hours, int minutes)
        {
            StreamWriter streamWriter = new StreamWriter(@"C:\Users\Piotr\Desktop\GitLab\primary\20181218\AllTasksInOne\AllTasksInOne\Results\Result2.txt");
            streamWriter.Write("Wszystkie postacie do tej pory budowane były {0} godzin {1} minut", hours, minutes);
            streamWriter.Close();
        }

        private (int , int ) GetFinalTime(int totalTime)
        {
            return (totalTime/60, totalTime%60);
        }

        private int GetTotalTime(string[] allFiles)
        {
            List<string> allFilesList = allFiles.ToList();
            int returnTime = 0;

            foreach (string path in allFilesList)
            {
                string tempContent = File.ReadAllText(path);

                TextParser textParser = new TextParser();
                string tempTime = textParser.ExtractTimeToCreate(tempContent);

                if(!IsEmpty(tempTime))
                {
                    returnTime += Convert.ToInt32(textParser.ExtractTimeToCreate(tempContent));
                }
            }
            return returnTime;
        }

        private bool IsEmpty(string tempTime)
        {
            if (tempTime == string.Empty)
                return true;
            else return false;
        }

        private string[] GetPaths(string folderPath)
        {
            return Directory.GetFiles(folderPath);
        }

        
    }
}