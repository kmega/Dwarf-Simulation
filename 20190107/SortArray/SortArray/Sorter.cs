using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SortArray
{
    public class Sorter
    {
        List<string> Letters = new List<string>();
        List<string> Num = new List<string>();
        List<string> EvenLett = new List<string>();
        List<string> OddLett = new List<string>();

        public string[] SortArray(string[] arrayToSort)
        {
            PreSorter(arrayToSort);
            SortedLetters(this.Letters.ToArray());

            string[] oddLetters = SortOddLetters(OddLett.ToArray());
            string[] evenLetters = SortEvenLetters(EvenLett.ToArray());
            string[] numbers = SortNumbers(Num.ToArray());

            string[] merge = oddLetters.Concat(numbers).ToArray();
            string[] mergedAll = merge.Concat(evenLetters).ToArray();

            return mergedAll;

        }

        public string[] SortNumbers(string[] numbers)
        {
            List<int> sortedNums = new List<int>();
            List<string> finalSort = new List<string>();
            foreach(string s in numbers)
            {
                int n = 0;
                Int32.TryParse(s, out n);
                sortedNums.Add(n);
            }

            int[] sorted = sortedNums.ToArray();
            Array.Sort(sorted);

            foreach(int n in sorted)
            {
                finalSort.Add(n.ToString());
            }

            return finalSort.ToArray();
        }

        public string[] SortEvenLetters(string[] evenLetters)
        {
             Array.Sort(evenLetters);

            return evenLetters;
        }

        public string[] SortOddLetters(string[] oddLetters)
        {
            Array.Sort(oddLetters);

            return oddLetters;
        }


        private void PreSorter(string[] arrayToSort)
        {
            int n = 0;
 
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                bool parsed = Int32.TryParse(arrayToSort[i], out n);

                if(parsed == true)
                {
                    this.Num.Add(n.ToString());
                }
                else
                {
                    this.Letters.Add(arrayToSort[i]);
                }

            }

        }

        private void SortedLetters(string[] arrayToSort)
        {
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                char[] lettersToSort = arrayToSort[i].ToCharArray();

                if (lettersToSort[0] % 2 == 0)
                    this.EvenLett.Add(arrayToSort[i]);
                else
                    this.OddLett.Add(arrayToSort[i]);
            }
        }

    }
}
