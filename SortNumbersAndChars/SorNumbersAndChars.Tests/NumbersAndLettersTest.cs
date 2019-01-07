using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortNumbersAndChars;
using System.Collections.Generic;

namespace SorNumbersAndChars.Tests
{
    [TestClass]
    public class NumbersAndLettersTest
    {
        [TestMethod]
        public void ShouldReturnNewListSortedNumbersAndLetters()
        {
            //Given
            List<string> NumbersAndLettersList = new List<string> {"a", "b", "1", "7", "4", "c",
                                            "9", "d", "14", "k", "a", "1", "2"};
            List<string> expecrted = new List<string> {"a", "a", "c", "k", "1", "1",
                                            "2", "4", "7", "9", "14", "b", "d"};


            //When
            List<string> result = new List<string>();
            NumbersAndLetters Task = new NumbersAndLetters();
            result = Task.GiveSortedNumbersAndLetters(NumbersAndLettersList);

            //Then

            CollectionAssert.AreEqual(result, expecrted);

        }
    }
}
