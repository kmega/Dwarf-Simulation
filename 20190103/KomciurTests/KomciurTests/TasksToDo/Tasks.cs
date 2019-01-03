using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using KomciurTests;

namespace KomciurTests.TasksToDo
{
    public class Tasks
    {
        TextParser parser = new TextParser();
        public string task1ForTest;

        public void Task_1()
        {
            string path = @"C:\Code\primary\20190103\KomciurTests\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
            string file = File.ReadAllText(path);
            string pathToSave = "result1.txt";

            string time = parser.ExtractTimeToCreate(file);
            this.task1ForTest = time;
            File.AppendAllText(pathToSave, time);
        }

    }
}
