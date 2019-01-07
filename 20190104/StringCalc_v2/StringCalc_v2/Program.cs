using System;

namespace StringCalc_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            StringCalculator calc = new StringCalculator();

            string number = "//[***]\n2***5";

            //result

            int result = calc.Add(number);
        }
    }
}
