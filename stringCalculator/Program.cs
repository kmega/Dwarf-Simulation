using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.ReadKey();


        }
    }

    public class StringCalc
    {
        public int Add(string numbers)
        {
            if (numbers == "")
            {
                return 0;
            }

            var temp = numbers.Split(',', '\n');
            var sumElements = temp.Sum(s => Int32.Parse(s));
            return sumElements;




            //to change a delimiter, the beginning of the string will contain a separate line
            //that looks like this:   “//[delimiter]\n[numbers…]” for example “//;\n1;2” should
            //return three where the default delimiter is ‘;’ .
            //the first line is optional.all existing scenarios should still be supported


        }
    }
}
