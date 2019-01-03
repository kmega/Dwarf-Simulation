using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Calculator
    {
       public List<int> exception = new List<int>();
        public int Sum (string input)
        {
            int result = 0;

            //for (int i = 0; i < input.Length; i++)
            //{
            //    if (!(Char.IsDigit(input, i)))
            //    {
            //        if (input[i]=='-')
            //        {
            //            continue;
            //        }
            //       input =  input.Replace(input[i], ',');
            //    }

            //}

            List<string> delimeterlist= new List<string>();
            if (input.StartsWith("//"))
            {
               string[] parts = input.Split('\n');
               parts[0]= parts[0].Replace('[', ' ').Replace('/', ' ').Replace(']', ' ');
               

            }
            else
            {
                delimeterlist.Add(",");
                delimeterlist.Add("\n");
            }

           string[] delimeter= delimeterlist.ToArray();
            

            string [] numbers = input.Split(delimeter,StringSplitOptions.None);
            foreach (var item in numbers)
            {

                

                if (Int32.TryParse (item, out int n))
                {
                    if (n<0)
                    {
                        exception.Add(n);
                        continue;
                    }

                    else if (n > 1000)
                    {
                        continue;
                    }

                    else
                    {
                        result += n;
                    }
                }
            }

            if (exception.Count > 0)
            {
                throw new Exception("Nie wolno używać ujemnych " + String.Join(", ", exception));
            }
            return result;
        }
        
    }
}