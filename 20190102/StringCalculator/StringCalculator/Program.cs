using System;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Console.WriteLine(calculator.Add("1\n2,3"));
            Console.ReadKey();
        }
    }
}
