using System;
using System.Collections.Generic;
using System.Linq;

namespace SortNumbersAndChars
{
    public class ListsSupporter
    {
        public static List<string> ExtractLetters(List<string> numbersAndLettersList)
        {
            List<string> OnlyLetters = new List<string>();

            foreach (var item in numbersAndLettersList)
            {
                bool result = int.TryParse(item, out int number);

                if (!result)
                {
                    OnlyLetters.Add(item);
                }
            }
            return OnlyLetters;
        }

        public static List<string> ExtractNumbers(List<string> numbersAndLettersList)
        {
            List<string> OnlyNumbers = new List<string>();

            foreach (var item in numbersAndLettersList)
            {
                bool result = int.TryParse(item, out int number);

                if (result)
                {
                    OnlyNumbers.Add(item);
                }
            }
            return OnlyNumbers;
        }

        public static void SortLetters(List<string> Letters)
        {
            Letters.Sort();
        }

        public static List<string> ExtractNegativeLetters(List<string> allLetters)
        {
            List<char> alphabet = new List<char> {'a', 'b', 'c', 'd', 'e', 'f', 'g',
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' ,'r', 's', 't', 'u', 'w', 'x', 'y', 'z' };

            List<string> OnlyNegativeLetters = new List<string>();

            foreach (var item in allLetters)
            {
                int index = 0;
                index = alphabet.IndexOf(char.Parse(item));

                if (index % 2 == 0) OnlyNegativeLetters.Add(item);
            }

            return OnlyNegativeLetters;
        }

        public static List<string> SortNumbers(List<string> allNumbers)
        {
            List<int> allNumbersInt = new List<int>();
            allNumbersInt = allNumbers.Select(int.Parse).ToList();

            allNumbersInt.Sort();

            List<string> l2 = allNumbersInt.ConvertAll<string>(x => x.ToString());

            return l2;

        }

        public static List<string> ExtractPositiveLetters(List<string> allLetters)
        {
            List<char> alphabet = new List<char> {'a', 'b', 'c', 'd', 'e', 'f', 'g',
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' ,'r', 's', 't', 'u', 'w', 'x', 'y', 'z' };

            List<string> OnlyPositiveLetters = new List<string>();

            foreach (var item in allLetters)
            {
                int index = 0;
                index = alphabet.IndexOf(char.Parse(item));

                if (index % 2 != 0) OnlyPositiveLetters.Add(item);
            }

            return OnlyPositiveLetters;
        }
    }
}