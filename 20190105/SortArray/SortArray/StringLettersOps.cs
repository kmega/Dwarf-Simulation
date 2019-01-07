using System;
using System.Collections.Generic;
using System.Linq;

namespace SortArray
{
    public class StringLettersOps
    {
        private string[] proper = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "v", "x", "y", "z" };

        public List<string> GetEvenLetters(string[] notSortedArray)
        {
            List<string> evenLettersList = new List<string>();

            foreach (string letter in notSortedArray)
            {
                int positon = Array.IndexOf(proper, letter);
                if(positon % 2 == 0)
                {
                    evenLettersList.Add(letter);
                }
            }
            evenLettersList.Sort();
            return evenLettersList;
        }

        public List<string> GetNotEvenLetters(string[] notSortedArray)
        {
            List<string> notEvenLettersList = new List<string>();

            foreach (string letter in notSortedArray)
            {
                int positon = Array.IndexOf(proper, letter);
                if (positon % 2 != 0 && proper.Contains(letter))
                {
                    notEvenLettersList.Add(letter);
                }
            }

            notEvenLettersList.Sort();
            return notEvenLettersList;
        }

        public List<string> GetNumbers(string[] notSortedArray)
        {
            List<int> numberList = new List<int>();

            foreach (string stringNumber in notSortedArray)
            {
                Int32.TryParse(stringNumber, out int number);
                if (number != 0)
                {
                    numberList.Add(number);
                }
            }

            numberList.Sort();
            List<string> stringNumberList = numberList.ConvertAll<string>(x => x.ToString());
            return stringNumberList;
        }

        public List<string> GetSpecialCharacter(string[] notSortedArray)
        {
            List<string> specialCharactersList = new List<string>();

            foreach (string letter in notSortedArray)
            {
                int positon = Array.IndexOf(proper, letter);
                if (positon == -1 &&  !Int32.TryParse(letter, out int number))
                {
                    specialCharactersList.Add(letter);
                }
            }

            return specialCharactersList;
        }

        public void DisplayResult(string[] notSortedArray)
        {
            List<string> evenLetters = GetEvenLetters(notSortedArray);
            List<string> notEvenLetters = GetNotEvenLetters(notSortedArray);
            List<string> numbers = GetNumbers(notSortedArray);

            var summaryList = evenLetters.Concat(numbers).Concat(notEvenLetters);

            foreach (string letter in summaryList)
            {
                Console.Write("{0}, ", letter);
            }
        }

        public void DisplayResultMod(string[] notSortedArray)
        {
            List<string> evenLetters = GetEvenLetters(notSortedArray);
            List<string> notEvenLetters = GetNotEvenLetters(notSortedArray);
            List<string> numbers = GetNumbers(notSortedArray);
            List<string> specialCharacters = GetSpecialCharacter(notSortedArray);

            var summaryList = evenLetters.Concat(numbers).Concat(notEvenLetters);

            foreach (string letter in summaryList)
            {
                Console.Write("{0}, ", letter);
            }
        }
    }
}