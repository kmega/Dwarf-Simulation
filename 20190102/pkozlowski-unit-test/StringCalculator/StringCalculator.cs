using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers.Equals(""))
            {
                return 0;
            }
            
            List<int> _numbers = new List<int>();
            MatchCollection matches = Regex.Matches(numbers, @"\d+", RegexOptions.Multiline);

            foreach (var match in matches)
            {
                _numbers.Add(Convert.ToInt32(match.ToString()));
            }

            int result = _numbers.Sum();

            return result;
        }
    }
}
