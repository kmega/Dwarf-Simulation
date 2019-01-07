using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableSorting
{
    public static class TableManager
    {
        public static List<string> Sort(List<string> given)
        {
            //Seperate numbers from letters
            var seperatedLettersAndNumbers = SeperateNumbersFromLetters(given);
            //SeperateEvenFromAllLetters
            EvenStringFactory seperatedLetters = SeperateEvenFromAllLetters(seperatedLettersAndNumbers.Letters);
            //Sort
            return SortAndJoin(seperatedLettersAndNumbers.Numbers, seperatedLetters);
        }

        private static List<string> SortAndJoin(List<int> numbers, EvenStringFactory sepLetters)
        {
            var result = new List<string>();
            numbers.Sort();
            sepLetters.NotEvenLetters.Sort();
            sepLetters.EvenLetters.Sort();
            result.AddRange(sepLetters.NotEvenLetters);
            foreach(var number in numbers)
            {
                result.Add(number.ToString());
            }
            result.AddRange(sepLetters.EvenLetters);
            return result;
        }

        private static EvenStringFactory SeperateEvenFromAllLetters(List<string> characters)
        {
            var seperatedLetters = new EvenStringFactory();
            foreach(var letter in characters)
            {
                if(letter[0] <65 || (letter[0] >90 && letter[0]<97) || letter[0]>122)
                {
                    seperatedLetters.WeirdChars.Add(letter);
                }
                if (letter[0] % 2 == 1)
                {
                    seperatedLetters.NotEvenLetters.Add(letter);
                }
                else
                {
                    seperatedLetters.EvenLetters.Add(letter);
                }
            }
            return seperatedLetters;
        }

        private static ListFactory SeperateNumbersFromLetters(List<string> given)
        {
            ListFactory resultLists = new ListFactory();

            foreach(var item in given)
            {
                int result;
                if(Int32.TryParse(item,out result))
                {
                    resultLists.Numbers.Add(result);
                }
                else
                {
                    resultLists.Letters.Add(item);
                }
            }

            return resultLists;
        }
    }
}
