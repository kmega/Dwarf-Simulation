using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaRegex;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string number)
        {
            var textParser = new TextParser();
            var extractNumbers = textParser.ExtractNumbers(number);
            int sum = 0;
            int bondaryCondition;
            if (extractNumbers.Count >3)
            {
                bondaryCondition = 3;
            }
            else
            {
                bondaryCondition = extractNumbers.Count;
            }
            for(int i =0; i<bondaryCondition; i++)
            {
                int digit = Int32.Parse(extractNumbers[i]);
                sum += digit;
            }
            return sum;
        }
    }
}
