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
            List<int> numbersToAdd = new List<int>();
            List<int> negativeNumbers = new List<int>();



            if (number == "") { sum = 0; }
            else
            {
                //string firstLineFull = number.Substring(0, number.IndexOf(Environment.NewLine));
                //string firstLine = firstLineFull.Split(new string[] { "//" }, StringSplitOptions.None); 
                //string[] splitter = number.Split(new string[] { firstLine }, StringSplitOptions.None);
                string[] splittedNumber = number.Split(new Char[] { ',', '.', '\n', '/',';' });
                

                foreach (string num in splittedNumber)
                {
                    int n = Int32.Parse(num);

                    if (n > 1000) { continue; }

                    if (n < 0)
                     negativeNumbers.Add(n); 
                    else
                    numbersToAdd.Add(n);

                }

                if (negativeNumbers.Count == 1)
                {
                    numbersToAdd.ForEach(x => sum += x);
                    throw new Exception(String.Format("negatives not allowed: {0}", negativeNumbers[0]));
                }

                else if (negativeNumbers.Count > 1)
                {
                    string negativeNumbersAsString = NegativeException(negativeNumbers);
                    throw new Exception(String.Format("stop here if you are a beginner. Continue if you can finish the steps so far in less than 30 minutes. {0}",negativeNumbersAsString));


                }
                else
                    numbersToAdd.ForEach(x => sum += x);
            }
            return sum;
        }

        private static string NegativeException(List<int> negativeNumbers)
        {
            string negativesAsString = negativeNumbers.ToString();
            return negativesAsString;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            StringCalculator.Add("5,-1");
        }
    }
}
