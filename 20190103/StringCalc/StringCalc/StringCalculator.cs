using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            int result = 0;
            List<int> separatedNumbers = new List<int>();
            var separator = new string[] { "," };
            var separatedLines = numbers.Split(new string[] { "/n" }, StringSplitOptions.None);
            
            foreach(var line in separatedLines)
            {
                var separatedNumbersInLine = line.Split(separator, StringSplitOptions.None);
                foreach(var number in separatedNumbersInLine)
                {
                    separatedNumbers.Add(Int32.Parse(number));
                }
            }
            result = separatedNumbers.Sum();          
            return result;
        }
    }
}
