using System;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Console.WriteLine(calculator.Add(""));
            Console.ReadKey();
        }
    }
}
