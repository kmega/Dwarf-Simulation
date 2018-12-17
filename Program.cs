using System;
using System.Collections.Generic;
using System.Linq;

namespace _20181217
{
    enum Genre
    {
        fantasy, horror, scifi
    }

    class Library
    {
        public List<Book> bookList = new List<Book>();
    }

    class Book
    {
        public string title { get; set; }
        public Genre genre { get; set; }
        public int numberOfPages { get; set; }
        public int lastTimeStoppedReadingOnPage { get; set; }
        public bool readed { get; set; }

        public Book(string title, 
                    Genre genre, 
                    int numberOfPages, 
                    int lastTimeStoppedReadingOnPage = 0, 
                    bool readed = false)
        {
            this.title = title;
            this.genre = genre;
            this.numberOfPages = numberOfPages;
            this.lastTimeStoppedReadingOnPage = lastTimeStoppedReadingOnPage;
            this.readed = readed;
        }
    }
    class Person
    {
        public int pagePerHour = 80;

        public void readBook(Book book, int hours)
        {
            Console.WriteLine("I'm reading a book about the title of: " + 
                              book.title + 
                              " for " + hours.ToString() + 
                              " hours.");
            book.lastTimeStoppedReadingOnPage = pagePerHour * hours;
            if (pagePerHour * hours >= book.numberOfPages)
                book.lastTimeStoppedReadingOnPage = book.numberOfPages;

            if (book.lastTimeStoppedReadingOnPage >= book.numberOfPages)
                book.readed = true;
        }

        public Book takeChosenBook(List<Book> books)
        {
            int i = new Random().Next(books.Count());
            Book tmpBook = books.ElementAt(i);
            return tmpBook;
        }

        public void putBackChosenBook(List<Book> library, Book book)
        {
            library.Add(book);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Library myLibrary = new Library();
            myLibrary.bookList.Add(new Book("Hobbit, czyli tam i z powrotem", Genre.fantasy, new Random().Next(99,980)));
            myLibrary.bookList.Add(new Book("Manitou", Genre.horror, new Random().Next(99,980)));
            myLibrary.bookList.Add(new Book("Bajki robotów", Genre.scifi, new Random().Next(99,980)));
            myLibrary.bookList.Add(new Book("Pan Lodowego Ogrodu", Genre.fantasy, new Random().Next(99,980)));
            myLibrary.bookList.Add(new Book("It", Genre.horror, new Random().Next(99,980)));
            myLibrary.bookList.Add(new Book("Neuromancer", Genre.scifi, new Random().Next(99,980)));
            myLibrary.bookList.Add(new Book("Władcy czasu", Genre.scifi, new Random().Next(99,980)));
            myLibrary.bookList.Add(new Book("Wiedźmin", Genre.fantasy, new Random().Next(99,980)));
            myLibrary.bookList.Add(new Book("Mgła", Genre.horror, new Random().Next(99,980)));

            Person me = new Person();

            List<Book> filteredBooks = myLibrary.bookList.FindAll(x => x.genre.Equals(Genre.fantasy));

            Book chosenBook = me.takeChosenBook(filteredBooks);
            me.readBook(chosenBook, 3);
            me.putBackChosenBook(myLibrary.bookList, chosenBook);            
        }
    }
}
