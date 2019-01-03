using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            int sum = 0;

            int index = numbers.IndexOf("\n");
            int maxIndex = numbers.Length - index;

            string delimiter = "";
            delimiter = numbers.Remove(index, maxIndex);

            numbers = numbers.Replace(delimiter, "");
            string deli = delimiter.Split(new string[] { "//[", delimiter, "]" }, StringSplitOptions.None)[1];

                string[] numbersArray =
                numbers.Split(new string[] { "\n", ",", deli }, StringSplitOptions.None);

                string[] numbersArray =
                numbers.Split(new string[] { "\n", ","}, StringSplitOptions.None);

            

            string exceptions = "";

            if (numbers == "") return 0;
            else if(numbersArray != null)
            {
                foreach (var number in numbersArray)
                {

                    if (number != "" && (int.TryParse(number, out int value)) == false)
                    {
                        exceptions += number + Environment.NewLine;
                    }
                    else
                    {
                        if (number != "" && int.Parse(number) <= 1000)
                        {                           
                            sum += int.Parse(number);
                        }
                            
                    }
                    
                }
                if (exceptions != "") throw new Exception($"negatives not allowed: {exceptions}");
                return sum;
            }
            else if (int.TryParse(numbers, out int numbers_parse))
              {
                return numbers_parse;
            }
            return 0;
        }
    }
   
}

