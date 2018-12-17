using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task101
{
    class Read
    {

        public int Czytam(List<Fantasy_book> _list_of_fantasy_books)
        {
            Console.WriteLine("Czytam " + _list_of_fantasy_books[0].Title);
            Thread.Sleep(500);
            Console.WriteLine("Przeczytałem");
            return _list_of_fantasy_books[0].Id;
        }
    }
}
