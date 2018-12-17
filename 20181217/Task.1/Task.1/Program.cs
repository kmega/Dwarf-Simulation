using System;
using System.Collections.Generic;

namespace Task
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            CompareBooks cb = new CompareBooks();
            foreach (var item in cb.Compare())
            {
                Console.WriteLine("{0}, {1}", item.Key, item.Value);
            }
        }
    }

    class BooksFile
    {
        public List<Book> ReadBooks = new List<Book>
        {
            {new Book("fantasy", "titel 1")},
            {new Book( "horror", "title 2")},
            {new Book("fantasy", "titel 4")}
        };

        public List<Book> AllBooks = new List<Book>
            {
                {new Book("fantasy", "titel 1")},
                {new Book( "horror", "title 2")},
                {new Book("fantasy", "titel 4")},
                {new Book("fantasy", "titel 3")},
                {new Book( "horror", "title 5")},
                {new Book("fantasy", "titel 6")}
            };
    }
    class Book
    {
        public string tag;
        public string tytul;
        public Book(string tag, string tytul)
        {
            this.tag = tag;
            this.tytul = tytul;
        }
    }
    class CompareBooks
    {
        BooksFile bf = new BooksFile();

        public List<Book> Compare()
        {
            List<Book> TempBooks = new List<Book>();

            foreach (Book AllBook in bf.AllBooks)
            {
                foreach(Book ReadBook in bf.ReadBooks)
                {
                    if(ReadBook.tag && ReadBook.tytul)
                }
            }
            return TempBooks;
        }
    }
    
     
}
