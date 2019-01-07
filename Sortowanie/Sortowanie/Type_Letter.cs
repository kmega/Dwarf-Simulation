using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortowanie
{
    public class Type_Letter
    {

        public string[] letter_type(string[] table, bool even)
        {
            List<string> letter_type = new List<string>();
            string[] not_even_list = { "a", "c", "e", "g", "i", "k", "m", "o", "r" };
            string[] even_list = { "b", "d", "f", "h", "j", "l", "n", "p", "s" };
            string[] check_list;
            if (even)
            {
                check_list = even_list;
            }
            else
            {
                check_list = not_even_list;
            }


            foreach (var letter in table)
            {
                foreach (var check_letter in check_list)
                {
                    if (letter== check_letter)
                    {
                        letter_type.Add(letter);
                    }
                }
            }

            return letter_type.ToArray();
        }

        public string[] sort_int_letter(string[] table)
        {
            List<int> number_list = new List<int>();
            List<string> letter_type = new List<string>();
            int number;
            foreach (var letter in table)
            {
                    if (Int32.TryParse(letter, out number))
                    {
                        number_list.Add(number);
                    }
            }

            number_list.Sort();
            foreach (var item in number_list)
            {
                letter_type.Add(item.ToString());
            }
            return letter_type.ToArray();
        }
    }
}
