using System;

namespace SortArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //given
            SortArray.Sorter sort = new SortArray.Sorter();
            string[] arrayToSort = { "a", "b", "1", "7", "4", "9", "d", "14", "k", "a", "1", "2" };

            //act
            string[] result = sort.SortArray(arrayToSort);
        }
    }
}
