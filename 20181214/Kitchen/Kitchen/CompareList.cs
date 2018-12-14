using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen
{
    class CompareList
    {
        public static void Result(string Bad_list, string Indigriends_list)
        {
            if (Bad_list == Indigriends_list)
            {
                Console.WriteLine("Źle");
            }
            else {
                Console.WriteLine("Dobrze");
            }
        }

    }
}
