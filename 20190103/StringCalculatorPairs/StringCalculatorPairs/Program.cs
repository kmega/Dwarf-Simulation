using System;
using System.Collections.Generic;

namespace StringCalculatorPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class StringCalculator
    {
        public int Add(string value, string[] separator)
        {
            List<string> temp = new List<string>();

            foreach (string s in value.Split(separator, StringSplitOptions.None))
            {
                temp.Add(s.Replace("Bardzo", "").Replace("Lubie", "").Replace("Jendka", "").Replace("//[*][%]\n", "").Replace("]\n", ""));
            }

            int result = 0;
            result += Extractor(temp);

            return result;
        }

        public int Add(string value, string secondValue, string[] separator)
        {
            List<string> temp = new List<string>();

            foreach (string s in value.Split(separator, StringSplitOptions.None))
            {
                temp.Add(s.Replace("Bardzo", "").Replace("Lubie", "").Replace("Jendka", "").Replace("//[*][%]\n", "").Replace("]\n", ""));
            }

            foreach (string s in secondValue.Split(separator, StringSplitOptions.None))
            {
                temp.Add(s.Replace("Make", "").Replace("DreamsComme", "").Replace("True", "").Replace("Day", ""));
            }

            int result = 0;
            result += Extractor(temp);

            return result;
        }

        private int Extractor(List<string> temp)
        {
            int returnValue = 0;

            foreach (string stringNumber in temp)
            {
                int.TryParse(stringNumber, out int intNumber);
                if (IsPositiveAndSmallerThan1000(intNumber))
                {
                    returnValue += intNumber;
                }
            }
            return returnValue;
        }

        private bool IsPositiveAndSmallerThan1000(int intNumber)
        {
            if (intNumber >= 0 && intNumber <= 1000)
                return true;
            else throw new ArgumentOutOfRangeException(String.Format("Only positves numbers and smaller than 1000: =" + intNumber));
        }
    }
}
