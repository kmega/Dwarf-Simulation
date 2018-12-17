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
            _books.Add(2, new List<string>() { "Tutul2", "Fantasy", "Unread"});
            _books.Add(3, new List<string>() { "Tutul3", "Novel", "Read" });
            _books.Add(4, new List<string>() { "Tutul4", "Fantasy", "Unread" });
            _books.Add(5, new List<string>() { "Tutul5", "Novel", "Unread" });

        }

        public void Put_down(int Id_reading_book)
        {
            _books[Id_reading_book][2] = "Read";
            Console.WriteLine("Odłożyłem na miejsce, zmieniłem status na " +_books[Id_reading_book][2]);
        }
    }
}
