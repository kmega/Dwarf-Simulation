using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorNS
{
    public class StringCalculator
    {
        // Given 
        // String that has "", 1 or 1,2
        public string _numbers;

        // Then
        // Parse numbers from string
        

        // Expected
        // sum of numbers from string
        public int Add(string numbers)
        {
            if (numbers.Equals(""))
            {
                return 0;
            }

            List<int> _numbers = new List<int>();
            MatchCollection _matches = Regex.Matches(numbers, @"\d+", RegexOptions.Multiline);

            foreach(var match in _matches)
            {
                Int32 tmpInt = Convert.ToInt32(match.ToString());
                if (tmpInt < 0){
                    throw new ArgumentException("negatives not allowed", tmpInt.ToString());
                }
                
                _numbers.Add(tmpInt);            
            }
            return _numbers.Sum();
        }

        static void Main(string[] args)
        {
            
        }
    }
}
