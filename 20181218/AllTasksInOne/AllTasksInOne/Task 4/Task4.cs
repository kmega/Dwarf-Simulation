using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AllTasksInOne
{
    public class Task4
    {
        public void Main()
        {
            string folderPath = @"C:\Users\Piotr\Desktop\GitLab\primary\20181218\cybermagic\opowiesci";
            List<string> paths = GetPaths(folderPath);

            (List<string> MagdasStories, string name) = GetStories(paths);
            SaveToFile(MagdasStories, name);
            DisplayResult(MagdasStories, name);
        }

        private void DisplayResult(List<string> magdasStories, string name)
        {
            Console.WriteLine("### Task 4:");
            Console.WriteLine("{0} występowała w następujących Opowieściach:", name);
            Console.WriteLine("");
            foreach (string character in magdasStories)
            {
                Console.WriteLine("* {0}", character);
            }
            Console.WriteLine("");
            Console.WriteLine();
        }

        private void SaveToFile(List<string> magdasStories, string name)
        {
            StreamWriter streamWriter = new StreamWriter(@"C:\Users\Piotr\Desktop\GitLab\primary\20181218\AllTasksInOne\AllTasksInOne\Results\Result4.txt");


            streamWriter.WriteLine("### Task 4:");
            streamWriter.WriteLine("{0} występowała w następujących Opowieściach:", name);
            streamWriter.WriteLine("");
            foreach (string character in magdasStories)
            {
                streamWriter.WriteLine("* {0}", character);
            }
            streamWriter.WriteLine("");
            streamWriter.Close();
        }

        private (List<string> MagdasStories, string name) GetStories(List<string> paths)
        {
            List<string> returnList = new List<string>();
            string name = null;

            foreach (string path in paths)
            {
                string tempContent = File.ReadAllText(path);
                TextParser textParser = new TextParser();

                string tempName = textParser.ExtractStuffWithMagda(tempContent);
                string tempTitle = textParser.ExtractStoryName(tempContent);

                if(tempName!=string.Empty && tempTitle!=string.Empty)
                {
                    name = tempName.Substring(0, 13);
                    returnList.Add(tempTitle);
                }
            }

            return (returnList, name);
        }

        private List<string> GetPaths(string folderPath)
        {
            return Directory.GetFiles(folderPath).ToList();
        }
    }
}