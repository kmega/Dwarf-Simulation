using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySort
{
   public class StringSorter
    {
        public string[] Sort(string[] array)
        {
            List<char> OddLetters = ExtractLetters(array,false);
            OddLetters.Sort();
            List<int> Numbers = ExtractNumbers(array);
            Numbers.Sort();
            List<char> EvenLetters = ExtractLetters(array,true);
            EvenLetters.Sort();
            var OddCharArray = OddLetters.Select(s => s.ToString()).ToArray();
            var NumbersArray = Numbers.Select(s => s.ToString()).ToArray();
            var EvenCharArray = EvenLetters.Select(s => s.ToString()).ToArray();
            string[] result = OddCharArray.Concat(NumbersArray).Concat(EvenCharArray).ToArray();
            return result;
        } 
        public List<char> ExtractLetters(string[] array,bool even)
        {
            int modResult = even ? 0 : 1;
            List<char> ExtractedChars = new List<char>();
            foreach (string element in array)
            {
                foreach (char sign in element)
                {
                    if (char.IsLetter(sign) && (sign % 2 == modResult))
                        ExtractedChars.Add(sign);
                }
            }
            return ExtractedChars;
        }

        public List<int> ExtractNumbers(string[] array)
        {
            List<int> ExtractedNumbers = new List<int>();
            foreach(string element in array)
            {
               int result;
               if(int.TryParse(element,out result))
                {
                    ExtractedNumbers.Add(result);
                }     
            }
            return ExtractedNumbers;
        }

    }
}
