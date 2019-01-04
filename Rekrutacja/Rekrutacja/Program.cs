using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekrutacja
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1 task1 = new Task1();
            task1.task();

            Task2 task2 = new Task2();
            task2.task();

            Console.ReadKey();

        }
    }
}
