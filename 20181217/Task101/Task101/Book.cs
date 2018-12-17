using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task101
{
    class Book
    {

        public IDictionary<int, List<string> > _books;

        public Book()
        {
            _books = new Dictionary<int,List<string>>();

            _books.Add(1, new List<string>() { "Tutul1", "Fantasy", "Read"});
            _books.Add(2, new List<string>() { "Tutul2", "Fantasy", "No Read"});
            _books.Add(3, new List<string>() { "Tutul3", "Novel", "Read" });

        }
    }
}
