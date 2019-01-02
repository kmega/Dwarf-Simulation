using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    public class Calculator
    {
        public int add(string values)
        {

            var numbers = values.Split(new[] { ",", "\n", "//;\n", ";"}, StringSplitOptions.None);
            
            int result = 0;
            foreach (var col in numbers)
            {
                int.TryParse(col.Trim(), out int num);

                if (num < 0)
                    throw new ArgumentException("negatives not allowed");

                result += num;
            }
            return result;

        }
    }
}
