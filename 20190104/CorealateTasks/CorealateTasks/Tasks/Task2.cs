using System;
using System.Collections.Generic;
using System.Text;

namespace CorealateTasks
{
    public class Task2
    {
        public void SortTeas()
        {
            string path = "tea-data.txt";
            string[] teaData = FileOpenerAndSaver.GetContentFromFile(path);

            string[] sorted = SorterHelp(teaData);
        }

        public string[] SorterHelp(string[] teaData)
        {
            List<string> sortedTeas = new List<string>();
 
            for (int i = 2; i < teaData.Length; i++)
            {
                foreach(string s in teaData)
                {
                    string[] splittedLine = s.Split(new string[] { "," }, StringSplitOptions.None);

                    Array.Sort(splittedLine);

                }
            }

            return null;
        }
    }
}
