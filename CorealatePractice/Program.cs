using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorealatePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book> { new Book("Potop", BookType.OTHER, false), new Book("Władca pierścieni", BookType.FANTASY, false)};

            Book.ShowBooks(books);

            Book.SearchBookAndRead(books);

            Book.ShowBooks(books);

            Console.ReadKey();

        }

        
    }
}
