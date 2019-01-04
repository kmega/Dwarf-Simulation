using System;
using System.Collections.Generic;
using System.Text;

namespace CorealateTasks
{
    class Sorter
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
                sortedTeas.Add(teaData[i]);
            }

            for (int i = 1; i < sortedTeas.Count; i++)
            {
                string[] splittedLine = sortedTeas[i].Split(new string[] { "," }, StringSplitOptions.None);
                char[] singleLetter = splittedLine[2].ToCharArray();

                if (TeaAlphabet.c)
                {

                }
                
            }

            

            return null;
        }
    }
}
