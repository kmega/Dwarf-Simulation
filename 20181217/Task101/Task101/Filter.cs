using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task101
{
    class Filter
    {
        

        public List<Fantasy_book> _create_list_of_fantasy_books(IDictionary<int, List<string>> _books)
        {
            List<Fantasy_book> _list_of_fantasy_books = new List<Fantasy_book>();
            for (int i = 0; i < _books.Count-1; i++)
            {
                if ((_books[i+1][2] == "Unread") && (_books[i + 1][1] == "Fantasy"))
                {
                    _list_of_fantasy_books.Add(new Fantasy_book() { Id = i + 1, Title = _books[i + 1][0] });
                }
            }


            return _list_of_fantasy_books;
        }
    }
}
