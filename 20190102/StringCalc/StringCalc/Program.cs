using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
   public class StringCalculator
    {
        public static int Sum(string number)
        {
            int num1;
            int num2;
            string[] splittedNumber = number.Split(',');

            Int32.TryParse(splittedNumber[0], out num1);
            Int32.TryParse(splittedNumber[1], out num2);

            int sum = num1 + num2;

            if (number == "")
            { return 0; }
            else
            { return sum; }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
