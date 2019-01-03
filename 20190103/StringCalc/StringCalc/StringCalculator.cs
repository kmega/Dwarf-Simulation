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
            
            var separatedLines = numbers.Split(new string[] { "/n" }, StringSplitOptions.None);
            var delimeter = separatedLines[0];
            delimeter = delimeter.Replace("//[", "").Replace("]", "");
            var separatedNumbersInLine = separatedLines[1].Split(new string[] { delimeter }, StringSplitOptions.None);
            foreach (var number in separatedNumbersInLine)
            {
                separatedNumbers.Add(Int32.Parse(number));
            } 
            result = separatedNumbers.Sum();          
            return result;        
        }
    }
}