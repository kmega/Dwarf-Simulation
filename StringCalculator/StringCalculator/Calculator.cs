using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        public int Calculate(string value)
        {
            if (value == "") return 0;

            var result1 = int.TryParse(value, out int value_int);

            if(result1)
            {
                return value_int;
            }
            else
            {
                throw new Exception();
            }
          
        }

        public int Calculate(string value1, string value2)
        {
            if (value1 == "" && value2 == "") return 0;

            var result1 = int.TryParse(value1, out int value1_int);
            var result2 = int.TryParse(value2, out int value2_int);

            if((result1 == false || result2 == false))
            {
                if (value1 == "" && value2 != "") return int.Parse(value2);
                else if (value1 != "" && value2 == "") return int.Parse(value1);
            }

            if (result1 && result2)
            {               
                return value1_int + value2_int;
            }
            else
            {
                throw new Exception();
            }

        }
    }
   
}

