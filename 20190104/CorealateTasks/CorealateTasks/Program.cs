using System;
using CorealateTasks.Tasks;

namespace CorealateTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //Run task 1
            Task1 task1 = new Task1();
            task1.RunTask1();

            //Run task2
            Task2 task2 = new Task2();
            task2.RunTask2();

        }
    }
}
