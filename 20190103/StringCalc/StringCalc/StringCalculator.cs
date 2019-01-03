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

            List<int> separatedNumbers = new List<int>();
            separatedLines = numbers.Split(new string[] { "\n" }, StringSplitOptions.None);
            List<string> separatedNumbersInLine = SeperateStringsToNumbers(separatedLines);
            foreach (var number in separatedNumbersInLine)
            {
                separatedNumbers.Add(Int32.Parse(number));
            }
            CheckForNegativeNumbers(separatedNumbers);
            var filterNumbers = separatedNumbers.Where(x => x < 1000).ToList();
            result = filterNumbers.Sum();
            return result;
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
        private List<string> SeperateStringsToNumbers(string[] separatedLines)
        {
            List<string> separatedNumbersInLine = new List<string>(); ////[*][%]\n1*2%3
            
            string delimeter;
            if (separatedLines[0].StartsWith("//"))
            {
                string[] delimeters = separatedLines[0].Split(new string[] { "][" }, StringSplitOptions.None);
                for(int i =0; i< delimeters.Length;i++)
                {
                    delimeters[i] = delimeters[i].Replace("//[", "").Replace("]", ""); ;
                }
               // delimeter = separatedLines[0];
               // delimeter = delimeter.Replace("//[", "").Replace("]", "");
                separatedNumbersInLine = separatedLines[1].Split(delimeters, StringSplitOptions.None).ToList();
            }
            else
            {
                foreach (var line in separatedLines)
                {
                    foreach (var number in line.Split(new string[] { "," }, StringSplitOptions.None))
                    {
                        separatedNumbersInLine.Add(number);
                    }
                };
            }
            return separatedNumbersInLine;
        }
        private void CheckForNegativeNumbers(List<int> separatedNumbers)
        {
            var negativeNumbers = separatedNumbers.Where(x => x < 0).ToList();
            if (negativeNumbers.Any())
            {
                string message = MessageBuilder(negativeNumbers);
                throw new Exception(message);
            }
        }
    }
}