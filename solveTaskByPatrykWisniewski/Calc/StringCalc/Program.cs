using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            int sum = calc.add("//[*][%]\n1*2%3");
            Console.WriteLine("Hello World!");
            Console.ReadKey();

        }
    }
}
