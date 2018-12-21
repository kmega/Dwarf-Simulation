using System;
using System.Collections.Generic;
using VivaRegex;

namespace Zadanie1
{
    static class ConfigManager
    {

        public static Queue<int> GetTasksToPerform(string config)
        {
            TextParser textParser = new TextParser();
            //Extract from file
            List<string> tasksToDo = textParser.ExtractNumbersOfTask(config);
            List<int> tasksToDoConverted = ConvertStringToInt(tasksToDo);
            //ValidateTasksNumbers
            return ValidateTasksNumbers(tasksToDoConverted);
        }

        public static Queue<int> ValidateTasksNumbers(List<int> tasksToDo)
        {
            Queue<int> correctTasks = new Queue<int>();
            foreach (var task in tasksToDo)
            {
                if (task > 0 && task < 5)
                {
                    correctTasks.Enqueue(task);
                }
                else
                {
                    continue;
                }
            }
            return correctTasks;
        }

        public static List<int> ConvertStringToInt(List<string> tasksToDo)
        {
            List<int> result = new List<int>();
            foreach (var task in tasksToDo)
            {
                result.Add(Int32.Parse(task));
            }
            return result;
        }

    }
}
