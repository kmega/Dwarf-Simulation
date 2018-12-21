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
            //Zadania//

            Tasks task = new Tasks();
            task.TaskOne();
            task.TaskTwo();
            task.TaskThree();
            task.TaskFour();

        }
    }
}
