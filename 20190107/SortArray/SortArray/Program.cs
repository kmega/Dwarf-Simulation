using System;

namespace SortArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Sorter sort = new Sorter();
            string[] arrayToSort = { "a", "b", "1", "7", "4", "9", "d", "14", "k", "a", "1", "2" };

            //act
            string[] result = sort.SortArray(arrayToSort);
            string[] result1 = sort.SortArray(arrayToSort);
        }
    }
}
