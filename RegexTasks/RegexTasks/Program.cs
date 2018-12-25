using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTasks
{
    class Program
    {
        public static List<string> personsWithoutBuildTime = new List<string>();

        static void Main(string[] args)
        {
            // MenagerTask tasks = new MenagerTask();
            //tasks.DoTasks(@"C:\Program Files\Git\primary\RegexTasks\RegexTasks\config\config.txt");
            Tasks task = new Tasks();
            task.TaskSeven();
        }
    }
}
