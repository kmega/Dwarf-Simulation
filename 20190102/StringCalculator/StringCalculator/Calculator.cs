using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (numbers.Equals(string.Empty))
                return 0;

            string[] splittedNumbers = numbers.Split(new Char[] { ',', '\\', '\n' });
            if (splittedNumbers.Length == 1)
                return int.Parse(splittedNumbers[0]);
            else
            {
                int sum = 0;
                for(int i=0;i<splittedNumbers.Length;i++)
                {
                    Console.WriteLine(splittedNumbers[i]);
                    sum += int.Parse(splittedNumbers[i]);
                }
                return sum;
            }
            
            
        }
    }
}
