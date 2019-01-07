using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortStringTab
{
    public class SortMachine
    {

        public List<string> SortString (List<string> input)
        {
            List<string> oddletter = new List<string>();
            List<string> evenletter = new List<string>();
            List<int> number = new List<int>();
            List<string> other = new List<string>();

            foreach (var item in input)
            {
                if (Char.IsLetter(item, 0))
                {
                    int value = Encoding.ASCII.GetBytes(item.ToCharArray())[0];
                    if (value>122)
                        {
                        other.Add(item);

                    }


                 else  if((value % 2 == 1))
                    {
                        oddletter.Add(item);

                    }
                   else
                    {
                        evenletter.Add(item);
                    }

                }
                else if (Char.IsDigit(item,0))
                {
                    number.Add(Int32.Parse(item));
                }
                else
                {
                    other.Add(item);
                }


            }

            oddletter.Sort();
            evenletter.Sort();
            number.Sort();
            other.Sort();

            

            

            List<string> numberstring = number.Select(s => s.ToString()).ToList();
            int index = numberstring.Count() / 2;
            numberstring.InsertRange(index, other);


            List<string> result = new List<string>();
            result.AddRange(oddletter);
            result.AddRange(numberstring);
            result.AddRange(evenletter);

            return result;

        }

    }
}
