using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp
{
    public class StringCalculator
    {
        public int Calculate(string value)
        {
            if (value != "" && int.TryParse(value, out int value1) == false)
            {
                throw new Exception();
            }
            if (value == "")
                return 0;
            else
                return int.Parse(value);
        }

        public int Calculate(string value1, string value2)
        {
            if ((value1 != "" && int.TryParse(value1, out int value) == false)
                && (value2 != "" && int.TryParse(value1, out int value3) == false))
            {
                throw new Exception();
            }


            if (value1 == "" && value2 == "")
            {
                return 0;
            }
            else if (value1 == "")
            {
                return int.Parse(value2);
            }
            else if (value2 == "")
            {

                return int.Parse(value1);
            }
            else
            {
                int Sum(int a, int b) => a + b;
                return Sum(int.Parse(value1), int.Parse(value2));
            }
        }

    }
}
