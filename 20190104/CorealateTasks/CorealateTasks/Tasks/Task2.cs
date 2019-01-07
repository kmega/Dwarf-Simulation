using System;
using System.Collections.Generic;
using System.Text;

namespace CorealateTasks
{
    public class Task2
    {
        public void RunTask2()
        {
            Sorter task2 = new Sorter();
            string pathToOpen = "tea-data.txt";
            string pathToSave = "result2.txt";
            string[] teaDataFull = FileOpenerAndSaver.GetContentFromFile(pathToOpen);
            string[] teaData = new string[teaDataFull.Length - 2];

            for (int i = 0; i < teaData.Length; i++)
            {
                teaData[i] = teaDataFull[i + 2];
            }
            string[] result = task2.SortTeasByType(teaData);

            string[] resultOfTask1 = new string[teaDataFull.Length];

            for (int i = 0; i < teaDataFull.Length; i++)
            {
                if (i==0 || i==1)
                {
                    resultOfTask1[i] = teaDataFull[i];
                    continue;
                }
                else
                {
                    resultOfTask1[i] = result[i-2];
                }
            }

            FileOpenerAndSaver.SaveToPath(resultOfTask1, pathToSave);

        }
    }
}
