using System;
using System.Collections.Generic;
using System.Text;

namespace SortNumbersAndChars
{
    public class NumbersAndLetters
    {
        //Return Sorted Numbers And Letters
        public List<string> GiveSortedNumbersAndLetters(List<string> NumbersAndLettersList)
        {
            List<string> SortedNumbersAndLettersList = new List<string>();

            //Extract all letters and return list letters
            List<string> AllLetters = ListsSupporter.ExtractLetters(NumbersAndLettersList);
            //Extract all numbers and return list numbers
            List<string> AllNumbers = ListsSupporter.ExtractNumbers(NumbersAndLettersList);
            //Extract only positive letters and return positive lists
            List<string> PositiveLetters = ListsSupporter.ExtractPositiveLetters(AllLetters);
            //Extract only negative letters and return negatives lists
            List<string> NegativeLetters = ListsSupporter.ExtractNegativeLetters(AllLetters);

            //Sort positive letters
            ListsSupporter.SortLetters(PositiveLetters);
            //Sort negative letters
            ListsSupporter.SortLetters(NegativeLetters);
            //Sort numbers
            List<string> AllNumbersString = new List<string>();
            AllNumbersString = ListsSupporter.SortNumbers(AllNumbers);

            SortedNumbersAndLettersList.AddRange(NegativeLetters);
            SortedNumbersAndLettersList.AddRange(AllNumbersString);
            SortedNumbersAndLettersList.AddRange(PositiveLetters);


            return SortedNumbersAndLettersList;
        }
       
        
    }
}
