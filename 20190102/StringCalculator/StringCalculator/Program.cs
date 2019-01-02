using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {

            Calculator calc = new Calculator();
            
            Console.WriteLine(calc.Sum("a,-4,,,,,,,,\n7kkk-9"));
            Console.ReadKey();
        }
    }
}
