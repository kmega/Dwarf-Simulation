using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Calculator
    {
       public List<int> exception = new List<int>();
        public int Sum(string input)
        {

            int result = 0;
            

            //string[] test = input.Split(new char[] { ' ', '/',',', '\n' });
            //string[] parts = Regex.Split(input, @"[^\d]");
            string[] parts = Regex.Split(input, @"[^\d-]");
            for (int i = 0; i < parts.Length; i++)
            {


                if (int.TryParse(parts[i], out int n))
                {
                    int temp = Int32.Parse(parts[i]);

                    if (temp < 0)
                    {
                        
                        exception.Add(temp);
                    }
                    else
                    {
                        result += temp;
                    }
            
                }
                else
                {
                    continue;
                }
;
            }
            if (exception.Count > 0)
            {
                throw new Exception(
                    "Nie wolno używać liczb ujemnych " + String.Join(", ", exception));
            }
            return result;

        }
        
    }
}