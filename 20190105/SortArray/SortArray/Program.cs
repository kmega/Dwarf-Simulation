using System;
using System.Collections.Generic;

namespace SortArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //tablica nieposrtowana -> podziel na kolekcje
            string[] notSortedArray = { "a", "b", "1", "7", "4", "c", "9", "d", "14", "k", "a", "1", "2", "%", "@" };
            //podzielone kolekcje -> zlacz i wysiwetl
            new StringLettersOps().DisplayResult(notSortedArray);
            new StringLettersOps().DisplayResultMod(notSortedArray);

        }
    }
}
