using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTable
{
    public class Filters
    {
        public List<string> FilterNumbers(List<string> list)
        {
            List<string> result = new List<string>();
            
            foreach(string s in list)
            {
                if(Int32.TryParse(s, out int integer))
                {
                    result.Add(Convert.ToString(integer));
                } 
            }
           
           return result;
        }

        public List<string> FilterOddLetters(List<string> list)
        {
            List<string> result = new List<string>();

            foreach (string s in list)
            {
                bool checkIsLetter = s.Any(x => char.IsLetter(x));
                if (checkIsLetter)
                {
                    result.Add(s);
                } else { continue; }
            }

            return result;
        }


        public List<string> GetOddLetters(List<string> list)
        {
            List<string> result = list.Where((c, i) => i % 2 != 0).ToList();

            return result;
        }

        public List<string> SortListOfNumbers(List<string> list)
        {
            List<string> result = FilterNumbers(list);
            return result.Sort();
        }
    }
}
