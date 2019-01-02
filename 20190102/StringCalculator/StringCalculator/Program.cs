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
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Sum(2, 2);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
