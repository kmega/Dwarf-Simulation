using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string value)
        {
            int sum = 0;
            if (value != "")
            {
                string[] delimiters = CheckDelimiters(value);
                string[] values_almost = value.Split(delimiters, StringSplitOptions.None);
                string[] values = values_almost.Except(new[] { string.Empty, "" }).ToArray();

                sum = CheckNegativeValues(values);
            }

            
            return sum;
        }

        public string[] CheckDelimiters(string value)
        {
            List<string> delimiters = new List<string>();
            delimiters.Add(",");
            delimiters.Add("\n");
            delimiters.Add("/");

            if (value[0]=='/' && value[1]=='/')
            {
                delimiters.Add(value[2].ToString());
            }

            return delimiters.ToArray();
        }

        public int CheckNegativeValues(string[] values)
        {
            int sum = 0;
            string negative_values = "";
            bool flag = false;

            foreach (var item in values)
            {

                if (item[0] == '-')
                {
                    negative_values = item + " ";
                    flag = true;
                }
                else
                {
                    sum += Int32.Parse(item);
                }
            }

            if (flag)
            {
                new  ArgumentException();
            }
            return sum;
        }
    }
}
