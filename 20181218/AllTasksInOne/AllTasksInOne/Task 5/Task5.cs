using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AllTasksInOne
{
    public class Task5
    {
        public void Main()
        {
            string configFile = @"C:\Users\Piotr\Desktop\GitLab\primary\20181218\AllTasksInOne\AllTasksInOne\configFile.txt";
            string commandString = GetCommands(configFile);

            List<string> commandInt = ConvertStringCommands(commandString);

            RunTasks(commandInt);
        }

        private void RunTasks(List<string> commandInt)
        {
            foreach (string command in commandInt)
            {
                switch (command)
                {
                    case "1":
                        new Task1().Main();
                        break;

                    case "2":
                        new Task2().Main();
                        break;

                    case "3":
                        new Task3().Main();
                        break;

                    case "4":
                        new Task4().Main();
                        break;

                    case "6":
                        new Task6().Main();
                        break;

                    default:
                        Console.WriteLine("Task {0} does not exsist yet", command);
                        Console.WriteLine();
                        break;
                }
            }
        }

        private List<string> ConvertStringCommands(string commandString)
        {
            TextParser textParser = new TextParser();
            List<string> temp = textParser.ExtractCommands(commandString);

            return temp;
        }

        private string GetCommands(string configFile)
        {
            return File.ReadAllText(configFile);
        }
    }
}