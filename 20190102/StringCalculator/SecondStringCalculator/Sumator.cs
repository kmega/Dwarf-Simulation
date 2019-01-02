using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SecondStringCalculator
{
    public class Sumator
    {
        private List<int> GetNumbersFromString(string numberString)
        {
            List<int> numbers = new List<int>();

            MatchCollection matches = Regex.Matches(numberString, @"\d+", RegexOptions.Multiline);

            foreach (object match in matches)
            {
                numbers.Add(Convert.ToInt16(match.ToString()));
            }

            return numbers;
        }

        public int GetSum(string numberString)
        {
            if(numberString == "")
            {
                return 0;
            }
            var numbers = GetNumbersFromString(numberString);

            return numbers.Sum();
        }

        public int GetSum(string numberString, string secondString)
        {
            if(numberString == "" && secondString == "")
            {
                return 0;
            }
            if (numberString != "" && secondString == "")
            {
                return GetNumbersFromString(numberString).Sum();
            }
            if (numberString == "" && secondString != "")
            {
                return GetNumbersFromString(secondString).Sum();
            }
            return GetNumbersFromString(numberString).Sum() + GetNumbersFromString(secondString).Sum();
        }
    }
}
