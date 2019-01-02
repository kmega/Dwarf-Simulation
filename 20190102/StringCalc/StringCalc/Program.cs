using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
   public class StringCalculator
    {
        public static int Add(string number)
        {
            int sum = 0;
            
            if (number == "") { sum = 0; }
            else
            {
                
                string[] splittedNumber = number.Split(new Char[] { ',', '.', '\n', '/' });
                List<int> numbersToAdd = new List<int>();

                foreach (string n in splittedNumber)
                {
                    numbersToAdd.Add(Int32.Parse(n));
                }

                numbersToAdd.ForEach(x => sum += x);

            }
            return sum;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            StringCalculator.Add("2/8/3");
        }
    }
}
