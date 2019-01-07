using System;
using NUnit.Framework;
using Sortowanie;

namespace SortowanieTest
{
    public class SortowanieTest
    {
        public string[] LetterInTable(string[] table, bool even)
        {
            Type_Letter sort = new Type_Letter();
            string[] letter_list = sort.letter_type(table, even);
            return letter_list;
        }

        public string[] NumberInTable(string[] table)
        {
            Type_Letter sort = new Type_Letter();
            string[] number_list = sort.sort_int_letter(table);
            return number_list;
        }

        public string[] Sort(string[] table)
        {
            Sort sort = new Sort();
            string[] sort_list = sort.sort_letter_list(table);
            return sort_list;
        }

        public string[] Merge(string[] a, string[] b, string[] c)
        {
            Marge marge = new Marge();
            string[] marge_list = marge.marge_list(a, b, c);
            return marge_list;
        }

        [Test]
        public void CheckTableForNotEvenLetter()
        {
            string[] table = { "a", "b", "1", "7", "4", "c", "9", "d", "14", "k", "a", "1", "2" };
            string[] expected_table = { "a", "c", "k", "a" };
            string[] result = LetterInTable(table, false);


            CollectionAssert.AreEqual(expected_table, result);
        }

        [Test]
        public void CheckTableEvenLetter()
        {
            string[] table = { "a", "b", "1", "7", "4", "c", "9", "d", "14", "k", "a", "1", "2" };
            string[] expected_table = { "b", "d"};
            string[] result = LetterInTable(table, true);


            CollectionAssert.AreEqual(expected_table, result);
        }


        [Test]
        public void CheckTableForNumber()
        {
            string[] table = { "a", "b", "1", "7", "4", "c", "9", "d", "14", "k", "a", "1", "2" };
            string[] expected_table = { "1", "1", "2", "4", "7", "9","14"};
            string[] result = NumberInTable(table);


            CollectionAssert.AreEqual(expected_table, result);
        }

        [Test]
        public void CheckSortForNotEvenLetter()
        {
            string[] table = { "a", "c", "k", "a" };
            string[] expected_table = {"a", "a", "c", "k" };
            string[] result = Sort(table);


            CollectionAssert.AreEqual(expected_table, result);
        }

        [Test]
        public void CheckSortForEvenLetter()
        {
            string[] table = {"d", "b"};
            string[] expected_table = { "b", "d" };
            string[] result = Sort(table);


            CollectionAssert.AreEqual(expected_table, result);
        }

        [Test]
        public void MargeThreeList()
        {
            string[] a = { "a", "c"};
            string[] b = { "1", "2"};
            string[] c = { "b", "d" };
            string[] expected_table = { "a", "c", "1", "2", "b", "d" };
            string[] result = Merge(a, b, c);


            CollectionAssert.AreEqual(expected_table, result);
        }


    }
}
