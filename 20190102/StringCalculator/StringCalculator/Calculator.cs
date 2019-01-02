using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VivaRegex;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string number)
        {
            int sum = 0;
            List<int> parsedNumbers = IntegerExtractor(number);
            var negativeNumbers = parsedNumbers.Where(x => x < 0)
                                            .ToList();
            if(negativeNumbers.Any())
            {
                var message = MessageBuilder(negativeNumbers);
                throw new Exception(message);
            }
            else
            {
                foreach (int num in parsedNumbers)
                {
                    if(num > 1000)
                    {
                        continue;
                    }
                    sum += num;
                }
            }           
            return sum;
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
        private List<int> IntegerExtractor(string number)
        {
            var textParser = new TextParser();
            List<string> extractNumbers = textParser.ExtractNumbers(number);
            List<int> parsedNumbers = new List<int>();
            foreach (var num in extractNumbers)
            {
                parsedNumbers.Add(Int32.Parse(num));
            }
            return parsedNumbers;
        }
    }
}
