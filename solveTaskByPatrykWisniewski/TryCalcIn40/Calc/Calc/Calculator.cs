using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class Calculator
    {
        public int add(string values)
        {

            var text = values.Split('/');
            char split = text[2][0];

            var numbersFromDelimeter = values.Split(split);

            var numbers = values.Split(new[] { ",", "\n", "/", ";", "*", "%" }, StringSplitOptions.RemoveEmptyEntries);


            int result = 0;
            foreach (var col in numbers)
            {
                int.TryParse(col.Trim(), out int num);
                if (num < 1000)
                {
                    result += num;
                }
                else if (num > 0)
                {
                    result += num;
                }
                
            }
            return result;
        }
    }
}
