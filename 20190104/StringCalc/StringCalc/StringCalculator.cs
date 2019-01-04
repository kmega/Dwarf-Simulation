using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            int result = 0;
            if (numbers == "") return 0;
           
            List<string> seperatedIntoLines = numbers.Split(new string[] { "\n" }, StringSplitOptions.None).ToList();
            string delimeter = ",";
            if (seperatedIntoLines[0].StartsWith("//"))
            {
                delimeter = seperatedIntoLines.First();
                delimeter = delimeter.Replace("//[", "").Replace("]", "");
                seperatedIntoLines.RemoveAt(0);
            }           
            List<int> digits = ExtractNumbers(seperatedIntoLines, delimeter);
            CheckForNegatives(digits);
            foreach(var num in digits)
            {
                if(num > 1000)
                {
                    continue;
                }
                result += num;
            }
            return result;
        }
        private static void CheckForNegatives(List<int> numbers)
        {
            List<int> negativeNumbers = numbers.Where(x => x < 0).ToList();
            if (negativeNumbers.Any())
            {
                throw new Exception(MessageBuilder(negativeNumbers));
            }
        }
        private static List<int> ExtractNumbers(List<string> separatedLines, string delimeter)
        {
            List<int> numbers = new List<int>();

            foreach (var line in separatedLines)
            {
                var sepNumbers = line.Split(new string[] { delimeter }, StringSplitOptions.None).ToList();
                foreach(var num in sepNumbers)
                {
                    numbers.Add(Int32.Parse(num));
                }
            }
            return numbers;
        }
        private static string MessageBuilder(List<int> negativeNumbers )
        {
            StringBuilder message = new StringBuilder();
            message.Append("Negatives are not allowed ");
            foreach (var num in negativeNumbers)
            {
                message.Append($"{num} ");
            }
            return message.ToString();
        }
    }
}
