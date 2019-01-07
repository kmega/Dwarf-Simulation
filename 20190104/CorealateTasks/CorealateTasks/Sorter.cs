using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CorealateTasks
{
   public class Sorter
    {
        public string[] SortTeasByType(string[] teaData)
        {
            string[] sortedTeas = new string[teaData.Length];
            int correctCounter = 0;
            do
            {
                for (int i = 0; i < teaData.Length; i++)
                {
                    string[] firstLine = teaData[i].Split(',');

                    for (int j = 0; j < teaData.Length; j++)
                    {
                        if (i == j)
                            continue;

                        string[] secondLine = teaData[j].Split(',');
                        string lineToBeHigher = CompareStrings(firstLine[1], secondLine[1], i, j);

                        if (lineToBeHigher == "second")
                        {
                            string tmp = teaData[i];
                            teaData[i] = teaData[j];
                            teaData[j] = tmp;
                            break;
                        }
                        else
                            correctCounter++;

                    }
                }
            } while (correctCounter < teaData.Length);


            return teaData;
        }

        private string CompareStrings(string firstWord, string secondWord, int i, int j)
        {
            StringComparer comparer = StringComparer.CurrentCulture;
            List<string> wordsToCompare = new List<string>() { firstWord, secondWord };

            wordsToCompare.Sort(comparer);
            string lineToBeHigher;
            if ( j > i)
            {
                if (wordsToCompare[0] == firstWord)
                    lineToBeHigher = "first";
                else
                    lineToBeHigher = "second";

            }

            else
            {
                if (wordsToCompare[0] == firstWord)
                    lineToBeHigher = "second";
                else
                    lineToBeHigher = "first";

            }


            return lineToBeHigher;

        }

        public void SortTeas()
        {
            string path = "tea-data.txt";
            string[] teaData = FileOpenerAndSaver.GetContentFromFile(path);

            string[] sorted = SorterHelp(teaData);
        }


        public string[] SorterHelp(string[] teaData)
        {
            
            string[] tempPocket = new string[teaData.Length - 2];

            for (int i = 2; i < teaData.Length; i++)
            {
                string[] splittedLine = teaData[i].Split(new string[] { "," }, StringSplitOptions.None);
                tempPocket[i - 2] = teaData[i];

                
                   string[] sortedTeas =  tempPocket.OrderBy(s => splittedLine[1]).ToArray();
            }

            
            /*for (int i = 1; i < sortedTeas.Count; i++)
            {
                string[] splittedLine = sortedTeas[i].Split(new string[] { "," }, StringSplitOptions.None);
                char[] singleLetter = splittedLine[2].ToCharArray();

                if (TeaAlphabet.typeOf(singleLetter[0]))
                {

                }
                
            }*/

            

            return null;
        }
    }
}
