using System;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();
            Console.WriteLine(calc.Add("2,4hsa7"));
            Console.ReadLine();
        }
    }
}
