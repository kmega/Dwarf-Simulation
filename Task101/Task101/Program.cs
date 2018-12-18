using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task101
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            List<Book> fantasyBooks = library.FilterBooksByCategory(BookCategory.Fantasy);
            List<Book> notReadFantasyBooks = library.RemoveAllReadBooks(fantasyBooks);
            Book book = library.PickRandomBook(notReadFantasyBooks);
            book.Read(3);
            Console.ReadLine();
        }
    }
}
