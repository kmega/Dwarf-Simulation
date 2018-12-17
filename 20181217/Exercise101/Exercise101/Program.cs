using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise101
{
    class Program
    {
        public static List<Book> getFantasyBooks(List<Book> allBooks)
        {
            List<Book> result = new List<Book>();
            foreach (Book book in allBooks)
                if (book.bookType == BookType.Fantasy)
                    result.Add(book);
            return result;
        }
        public static List<Book> getLibrary()
        {
            List<Book> library = new List<Book>()
            {
                new Book(BookType.Fantasy,true),
                new Book(BookType.Other,false),
                new Book(BookType.Fantasy,false),
                new Book(BookType.Fantasy,false),
            };
            return library;
        }
        public static Book getUnreadFantasyBook(List<Book> bookList)
        {
            foreach (Book book in bookList)
            {
                if (book.read == false)
                    return book;
            }
            return null;
        }

        static void Main(string[] args)
        {
            List<Book> library = getLibrary();
            Console.WriteLine("Pobieram wszystkie książki fantasy z biblioteki");
            List<Book> fantasyBooks = getFantasyBooks(library);
            Console.WriteLine("Wybieram nieprzeczytaną książkę fantasy");
            Book selectedBook = getUnreadFantasyBook(fantasyBooks);
            int indexOfSelectedBook = selectedBook.id;
            library.Remove(selectedBook);
            Console.WriteLine("Biore książkę i czytam 3h");
            Console.WriteLine("Nadaje książce status przeczytane");
            selectedBook.read = true;
            Console.WriteLine("Odkładam książke na swoje miejsce");
            library.Insert(indexOfSelectedBook, selectedBook);
            Console.ReadKey();
        }
    }
}
