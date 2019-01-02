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
            if (value!="")
            {
                string[] values = value.Split(',');
                foreach (var item in values)
                {
                    sum += Int32.Parse(item);
                }
            }
            return sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();

            int result = calculator.Add("0,1,2");
            Console.ReadKey();
        }
    }
}
