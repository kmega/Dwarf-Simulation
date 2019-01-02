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

                string[] values_almost = value.Split(',', '\n');
                string[] values = values_almost.Except(new[] { string.Empty, "" }).ToArray();
                foreach (var item in values)
                {
                    sum += Int32.Parse(item);
                }

            return sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            Console.WriteLine(calculator.Add("1\n"));
            Console.ReadKey();  
        }
    }
}
