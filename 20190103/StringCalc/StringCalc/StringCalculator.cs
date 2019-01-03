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
            string[] separatedLines;
            string delimeter;
            List<string> separatedNumbersInLine = new List<string>();
            int index = 0;
            List<int> separatedNumbers = new List<int>();
            separatedLines = numbers.Split(new string[] { "/n" }, StringSplitOptions.None);
            if (numbers.StartsWith("//"))
            {               
                delimeter = separatedLines[0];
                delimeter = delimeter.Replace("//[", "").Replace("]", "");
                separatedNumbersInLine = separatedLines[1].Split(new string[] { delimeter }, StringSplitOptions.None).ToList();
            }
            else
            {
                foreach(var line in separatedLines)
                {
                    foreach(var number in line.Split(new string[] { "," }, StringSplitOptions.None))
                    {
                        separatedNumbersInLine.Add(number);
                    }               
                };
            }
            foreach (var number in separatedNumbersInLine)
            {
                separatedNumbers.Add(Int32.Parse(number));
            } 
            result = separatedNumbers.Sum();          
            return result;        
        }
    }
}