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
            var separator = new string[] { "," };
            var separatedLines = numbers.Split(new string[] { "/n" }, StringSplitOptions.None);
            var seperatedNumbers = numbers.Split(separator, StringSplitOptions.None);
            foreach(var number in seperatedNumbers)
            {
                result += Int32.Parse(number);
            }
            return result;
        }
    }
}
