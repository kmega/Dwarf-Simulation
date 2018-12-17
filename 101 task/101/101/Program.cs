using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _101
{
    class Program
    {
        class Books
        {
            public List<string> ListOfBooks()
            {
                List<string> books = new List<string>();
                books.Add("Hobbit");
                books.Add("Lord of Rings");

                return books;
            }

            public Dictionary<List<string>, List<string>> DictionaryOfBooks()
            {
                List<string> booksFantasy = new List<string>();
                List<string> booksHistorical = new List<string>();
                Dictionary<List<string>, List<string>> allBooks = new Dictionary<List<string>, List<string>>();

                booksFantasy.Add("Hobbit");
                booksFantasy.Add("Lord of Rings");

                booksHistorical.Add("Second World War");

                return allBooks;

            }

            public void Compare(string bookType, string bookName)
            {
                Dictionary<List<string>, List<string>> toCompare = new Dictionary<List<string>, List<string>>();

                toCompare = DictionaryOfBooks().Keys.ToList();
                string compareKeys = toCompare.Keys.ToList();

                foreach(Type in )
            }


            public List<string> ListOfBooksByTypes()
            {
                List<string> bookTypes = new List<string>();
                bookTypes.Add("fantasy");
                bookTypes.Add("historical");

                return bookTypes;
            }

            public void ReadBooksList(string chosenBook)
            {
                List<string> readBooks = new List<string>();
                readBooks.Add(chosenBook);
            }

            public void NotReadBooksList( string chosenBook)
            {
                List<string> notReadBooks = new List<string>();
            }
            
        }
        static void Main(string[] args)
        {
            //1. Stworzenie listy książek
            //2. Stworzenie przeczytanej i nieprzeczytanej listy
            //3. Dane od uzytkownika o ksiazce
            Console.WriteLine("Which type of book?");
            string bookTypeChosenByUser = Console.ReadLine();
            //4. Czytanie książki
            Console.WriteLine("reading the book for 3 hours");
            //5. Odłożenie książki (książka przeczytana)
            Books newBook = new Books();

            newBook.ReadBooksList(bookTypeChosenByUser);
            Console.WriteLine("after 3 hours You've read the book");
            Console.WriteLine("Book {0} was placed on right place", bookTypeChosenByUser);

            Console.ReadKey();


        }
    }
}
