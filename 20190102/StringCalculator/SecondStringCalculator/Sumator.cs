using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SecondStringCalculator
{
    public class Sumator
    {
        public int GetSum(string numberString, string delimiter)
        {
            if(numberString == null)
            {
                return 0;
            }
            var numbers = GetNumbersFromString(numberString, delimiter);

            return numbers.Sum();
        }

        public int GetSum(string numberString, string secondString, string delimiter)
        {
            if (numberString == "" && secondString == "")
            {
                return 0;
            }
            if (numberString != "" && secondString == "")
            {
                return GetNumbersFromString(numberString, delimiter).Sum();
            }
            if (numberString == "" && secondString != "")
            {
                return GetNumbersFromString(secondString, delimiter).Sum();
            }
            return GetNumbersFromString(numberString, delimiter).Sum() + GetNumbersFromString(secondString, delimiter).Sum();
        }

        public int GetSum(string numberString, List<string> delimiter)
        {
            if (numberString == null)
            {
                return 0;
            }
            return GetNumbersFromString(numberString, delimiter).Sum();
        }

        private List<int> GetNumbersFromString(string numberString, string delimiter)
        {
            List<int> numbers = new List<int>();
            //string[] splitedNumberString = numberString.Split(delimiter);
            string[] splitedNumberString = numberString.Split(delimiter);

            foreach (string split in splitedNumberString)
            {
                MatchCollection matches = Regex.Matches(split, @"-?\d+", RegexOptions.Multiline);

                foreach (object match in matches)
                {
                    if (!IsGreaterThan1000(match) && IsPositive(match))
                    {
                        numbers.Add(Convert.ToInt16(match.ToString()));
                    }
                    else new Exception(String.Format("Negatives are not allowed: " + IsPositive(match)));
                }
            }
            
            return numbers;
        }

        private List<int> GetNumbersFromString(string numberString, List<string> delimiter)
        {
            List<int> numbers = new List<int>();
            //string[] splitedNumberString = numberString.Split(delimiter);

            List<string> splitedNumberString = MulitDelimiterSpliter(numberString, delimiter); //numberString.Split(delimiter);

            foreach (string split in splitedNumberString)
            {
                MatchCollection matches = Regex.Matches(split, @"-?\d+", RegexOptions.Multiline);

                foreach (object match in matches)
                {
                    if (!IsGreaterThan1000(match) && IsPositive(match))
                    {
                        numbers.Add(Convert.ToInt16(match.ToString()));
                    }
                    else new Exception(String.Format("Negatives are not allowed: " + IsPositive(match)));
                }
            }

            return numbers;
        }

        private List<string> MulitDelimiterSpliter(string numberString, List<string> delimiter)
        {
            //for chars
            //return numberString.Split(delimiter.ToArray()).ToList();
            return numberString.Split(delimiter.Aggregate(string.Concat)).ToList();
        }

        private bool IsGreaterThan1000(object match)
        {
            if(Convert.ToInt16(match.ToString())>1000)
            {
                return true;
            }
            return false;
        }

        private bool IsPositive(object match)
        {
            if (Convert.ToInt16(match.ToString()) >= 0)
            {
                return true;
            }
            return false;
        }
    }
}
