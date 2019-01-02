using System;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            StringCalculator calculator = new StringCalculator();
            string result = calculator.Add("0");
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
