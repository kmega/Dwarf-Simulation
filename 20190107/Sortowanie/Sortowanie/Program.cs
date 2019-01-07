using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortowanie
{
    class Program
    {
        static void Main(string[] args)
        {
            SortingMachine sortmach = new SortingMachine();
            string[] given = new string[] { "a", "b", "1", "7", "4", "c", "9", "d", "14", "k", "a", "1", "2" };
            sortmach.Sort(given);
            Console.ReadKey();
        }
    }
}
