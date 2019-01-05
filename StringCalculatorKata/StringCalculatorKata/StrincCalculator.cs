using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorKata
{
    public class StrincCalculator
    {
        string delimiters = ",";
        List<string> delimiter = new List<string>();
        int sum = 0;
        List<int> negativeNumbers = new List<int>();

        public int Add(string numbers)
        {
            if (numbers == string.Empty) return 0;
            else
            {
                if (numbers.Contains("//"))
                {
                    numbers = GenerateDelimiterFromNumbers(numbers);
                    GiveResultat(numbers);
                    return ThrowExceptionOrReturnSum();
                }

                GiveResultat(numbers);
                return ThrowExceptionOrReturnSum();
            }
        }

        private void GiveResultat(string numbers)
        {
            if(delimiter.Count == 0)
            {
                string[] splittedNumbers = numbers.Split(new string[] { delimiters, "\n" }, StringSplitOptions.None);
                sum = GenerateSumOrNegativeNumbers(splittedNumbers, negativeNumbers, sum);
            }
            else if(delimiter.Count > 0)
            {
                string[] splittedNumbers = numbers.Split(new string[] { delimiter[0], delimiter[1], "\n" }, StringSplitOptions.None);
                sum = GenerateSumOrNegativeNumbers(splittedNumbers, negativeNumbers, sum);
            }
            
        }

        private string GenerateDelimiterFromNumbers(string numbers)
        {
            numbers = numbers.Replace("//", "");
            int startIndex = numbers.IndexOf("\n");
            int endIndex = numbers.Length - (startIndex);
            delimiters = numbers.Remove(startIndex, endIndex);

            int count = delimiters.Count(f => f == '[');

            if(count >= 1)
            {
                delimiters = delimiters.Replace("[", "");
                string[] delimitersArray = delimiters.Split(']');

                foreach (var deli in delimitersArray)
                {
                    delimiter.Add(deli);
                }
            }

            numbers = numbers.Remove(0, startIndex);
            numbers = numbers.Replace("\n", "");
            return numbers;
        }

        private int ThrowExceptionOrReturnSum()
        {
            if (negativeNumbers.Count > 0)
            {
                string negativeNumbersStr = negativeNumbers.ToString();
                throw new Exception("Negative numbers: " + negativeNumbersStr);
            }
            else
            {
                return sum;
            }
        }

        private static int GenerateSumOrNegativeNumbers(string[] splittedNumbersDel, List<int> negativeNumbers1, int sum2)
        {
            foreach (var number in splittedNumbersDel)
            {
                if (int.Parse(number) > 1000) continue;

                if (int.Parse(number) >= 0) sum2 += int.Parse(number);
                else 
                {
                    negativeNumbers1.Add(int.Parse(number));
                }
            }

            return sum2;
        }
    }
}
