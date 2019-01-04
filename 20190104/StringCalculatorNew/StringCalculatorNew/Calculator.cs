using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorNew
{
    public class Calculator
    {
        public int Sum(string input)
        {
            int result = 0;
            List<string> delimeterlist = new List<string>();
           public List<int> exception = new List<int>();

            if (input.StartsWith("//"))
            {
                string [] parts = input.Split('\n');
                delimeterlist.Add(parts[0].Remove(0, 2));
            }


            else
            {
                delimeterlist.Add(",");
                delimeterlist.Add("\n");
                

            }

            string[] delimeter = delimeterlist.ToArray();
            string[] numbers = input.Split(delimeter, StringSplitOptions.None);


            foreach (var item in numbers)
    {
                if (Int32.TryParse(item, out int n))
                {
                    if (n < 0)
                    {
                        exception.Add(n);


                    }
                    else
                    {
                        result += n;
                    }
                }
    }

            if (exception.Count>0)
            {
                throw new Exception("Nie wolno używac ujemnych" + String.Join(", ", exception));
            }
            return result;

        }
    }

