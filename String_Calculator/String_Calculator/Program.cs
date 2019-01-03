using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Calculator
{
    public class Calculator
    {


        public int Add(string value)
        {
            int sum = 0;
            string delimiter = "";
            string[] values_almost;

            if (value != "")
            {
                delimiter = CheckForDelimeters(value);

                values_almost = value.Split(new string[] {
     ",",
     "\n",
     "/",
     "[",
     "]",
     delimiter
    }, StringSplitOptions.None);
                string[] values = values_almost.Except(new[] {
     string.Empty, ""
    }).ToArray();

                sum = CheckForNegativesAndHigherThan1000(values);

            }

            return sum;
        }

        private int CheckForNegativesAndHigherThan1000(string[] values)
        {
            string negative_numbers = "";
            bool flag = false;
            int sum = 0;
            foreach (var item in values)
            {
                try
                {
                    if (item[0] == '-')
                    {
                        negative_numbers += item + " ";
                        flag = true;
                    }
                    int number = Int32.Parse(item);
                    if (number < 1000)
                    {
                        sum += number;
                    }
                }
                catch
                {
                    throw;
                }
            }

            if (flag)
            {
                throw new ArgumentException("Negatives not allowed: " + negative_numbers);
            }

            return sum;
        }

        private string CheckForDelimeters(string value)
        {
            string delimiter = "";

            if (value[0] == '/' && value[1] == '/')
            {
                if (value[2] == '[')
                {
                    for (int i = 3; i < value.Length; i++)
                    {
                        if (value[i] == ']')
                        {
                            break;
                        }
                        delimiter += value[i];
                    }
                }
                else
                {
                    delimiter = value[2].ToString();
                }

            }
            return delimiter;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}