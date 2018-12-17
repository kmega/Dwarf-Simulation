using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task101
{
    class Filtr
    {
        public IDictionary<int, List<string>> _books;

        public List<string> _create_list_of_fantasy_books(IDictionary<int, List<string>> _books)
        {
            List<string> _list_of_fantasy_books = new List<string>();
            for (int i = 0; i < _books.Count-1; i++)
            {
                if ((_books[i+1][2] == "No Read") && (_books[i + 1][1] == "Fantasy"))
                {
                    _list_of_fantasy_books.Add(_books[i+1][0]);
                }
                
            }


            return _list_of_fantasy_books;
        }
    }
}
