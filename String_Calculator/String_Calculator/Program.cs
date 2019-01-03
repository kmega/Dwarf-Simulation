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
            string[] delimiter;
            string[] values_almost;

            if (value != "")
            {
                delimiter = CheckForDelimeters(value);

                values_almost = value.Split(delimiter, StringSplitOptions.None);
                string[] values = values_almost.Except(new[] { string.Empty, ""}).ToArray();

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

        private string[] CheckForDelimeters(string value)
        {
            List<string> delimiter = new List<string>();
            delimiter.Add("");
            int counter = 0;
            if (value[0] == '/' && value[1] == '/')
            {
                if (value[2] == '[')
                {
                    for (int i = 3; i < value.Length; i++)
                    {
                        if (value[i] == ']')
                        {
                            if (value[i + 1] == '[')
                            {
                                i = i + 2;
                                counter++;
                                delimiter.Add("");
                            }
                            else { break; }
                        }
                        delimiter[counter] += value[i];
                    }
                }
                else
                {
                    delimiter.Add("");
                    delimiter[counter] = value[2].ToString();
                }

            }
            delimiter.Add(",");
            delimiter.Add("\n");
            delimiter.Add("/");
            delimiter.Add("[");
            delimiter.Add("]");
            return delimiter.ToArray(); 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}