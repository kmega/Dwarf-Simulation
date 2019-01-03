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
            List<int> separatedNumbers = new List<int>();
            separatedLines = numbers.Split(new string[] { "\n" }, StringSplitOptions.None);
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
            var negativeNumbers = separatedNumbers.Where(x => x < 0).ToList();
            if(negativeNumbers.Any())
            {
                string message = MessageBuilder(negativeNumbers);
                throw new Exception(message);
            }
            else
            {
                result = separatedNumbers.Sum();
                return result;
            }        
        }
        private string MessageBuilder(List<int> negativeNumbers)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Negative numbers are not allowed: ");
            foreach (var num in negativeNumbers)
            {
                stringBuilder.Append($"{num.ToString()} ");
            }
            return stringBuilder.ToString();
        }

    }
}