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
            var result = calc.Calculate("0");
           // Console.WriteLine(result);
           // Console.ReadKey();

        }
    }
}
