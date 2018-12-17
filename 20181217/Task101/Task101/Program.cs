using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task101
{
    class Program
    {
        static public IDictionary<int, List<string>> _books;
        static List<Fantasy_book> _list_of_fantasy_books = new List<Fantasy_book>();
        static int Id_reading_book;

        static void Main(string[] args)
        {
            //Create poll of books
            Book _Pool_of_books = new Book();
            _books = _Pool_of_books._books;

            //Create list of fantasy books
            Filter list_of_fantasy = new Filter();
            _list_of_fantasy_books = list_of_fantasy._create_list_of_fantasy_books(_books);


            //Read first fantasy book from list of fantasy books
            Read reader = new Read();
            Id_reading_book = reader.Czytam(_list_of_fantasy_books);

            //Put down the book(change status Unread)
            _Pool_of_books.Put_down(Id_reading_book);


            Console.ReadKey();
        
        }
    }
}
