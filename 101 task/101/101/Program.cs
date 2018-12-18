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
            public List<string> ListOfNotReadBooks()
            {
                List<string> books = new List<string>();
                books.Add("Hobbit");
                books.Add("Lord of Rings");

                return books;
            }

            public Dictionary<string, List<string>> DictionaryOfBooks()
            {
                List<string> booksFantasy = new List<string>();
                List<string> booksHistorical = new List<string>();
                Dictionary<string, List<string>> allBooks = new Dictionary<string, List<string>>();

                booksFantasy.Add("Hobbit");
                booksFantasy.Add("Lord of Rings");

                booksHistorical.Add("Second World War");

                allBooks.Add("fantasy", booksFantasy);
                allBooks.Add("historical", booksHistorical);

                return allBooks;

            }

            public string Compare(string bookType)
            {
                Books bookList = new Books();

                Dictionary <string, List<string>> toCompare = bookList.DictionaryOfBooks();

                string searchedBook = toCompare[bookType][0];
                ReadBooksList(searchedBook);
                toCompare.Remove(searchedBook);

                return searchedBook;
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

            
        }
        static void Main(string[] args)
        {
            //1. Stworzenie listy książek
            //2. Stworzenie przeczytanej i nieprzeczytanej listy
            //3. Dane od uzytkownika o ksiazce
            Console.WriteLine("Which type of book?");
            string bookTypeChosenByUser = Console.ReadLine();
            //4. Czytanie książki
            Books newBook = new Books();
            string readBook = newBook.Compare(bookTypeChosenByUser);
            Console.WriteLine("{0} is read now", readBook);
            Console.WriteLine("Reading {0} for 3 hours", readBook);
            //5. Odłożenie książki (książka przeczytana)
            Console.WriteLine("After 3 hours You've read the book");
            Console.WriteLine("{0} was placed on right place", readBook);

            Console.ReadKey();


        }
    }
}
