using System;

namespace StringCalculatorKata
{
    class Program
    {
        static void Main(string[] args)
        {
            StrincCalculator calc = new StrincCalculator();
            
            Console.WriteLine(calc.Add("//[**][###]\n15###1000**2000###3000**1"));
            Console.ReadKey();
        }
    }
}
