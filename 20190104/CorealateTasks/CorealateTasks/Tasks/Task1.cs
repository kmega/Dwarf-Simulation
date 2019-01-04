using System;
using System.Collections.Generic;
using System.Text;

namespace CorealateTasks.Tasks
{
    class Task1
    {
        public void RunTask1()
        {
            TextReverser task1 = new TextReverser();
            string pathToOpen = "tea-data.txt";
            string pathToSave = "result1.txt";
            string[] teaData = FileOpenerAndSaver.GetContentFromFile(pathToOpen);
            string[] resultOfTask1 = task1.ReverseInput(teaData);
            FileOpenerAndSaver.SaveToPath(resultOfTask1, pathToSave);

        }
    }
}
