using System;
using System.Collections.Generic;
using System.Linq;

namespace Task
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            CompareBooks cb = new CompareBooks();
            cb.DisplayUnRead();
            cb.ReadAndPutIntoReadBooks();
        }
    }

    class BooksFile
    {
        public List<Book> ReadBooks = new List<Book>
        {
            {new Book("fantasy", "title 1")},
            {new Book( "horror", "title 2")},
            {new Book("fantasy", "title 4")}
        };

        public List<Book> AllBooks = new List<Book>
        {
            {new Book("fantasy", "title 1")},
            {new Book( "horror", "title 2")},
            {new Book("fantasy", "title 4")},
            {new Book("fantasy", "title 31")},
            {new Book( "romans", "title 51")},
            {new Book("fantasy", "title 61")}
        };
    }
    class CompareBooks
    {
        public BooksFile bf = new BooksFile();
        List<Book> TempList = new List<Book>();
         
        public void SetTag()
        {
            foreach(var item in bf.AllBooks)
            {
                if(item.tag == "fantasy")
                {
                    TempList.Add(item);
                }
            }
        }
        public void SetOnlyNotRead()
        {
            //IEnumerable<Book> czWspolna = (bf.AllBooks).Except(bf.ReadBooks);
            //var czWspolna = bf.AllBooks.Where(b => !bf.ReadBooks.Contains(b.tytul));
            foreach (var item in bf.AllBooks)
            {
                for (int i = 0; i < bf.ReadBooks.Count;i++)
                {
                    if (bf.ReadBooks[i].tytul==(item.tytul))
                    {
                        Console.WriteLine("Usunieto");
                        TempList.Remove(item);
                    }
                }

            }
        }
        public void DisplayUnRead()
        {
            SetTag();
            SetOnlyNotRead();
            foreach (var item in TempList)
            {
                 Console.WriteLine("tag: {0}, tytul: {1}", item.tag, item.tytul);
            }
        }
        public void ReadAndPutIntoReadBooks()
        {
            Console.WriteLine("Wybierz pozycje do czytania");
            int pickBook = int.Parse(Console.ReadLine());
            bf.ReadBooks.Add(TempList[pickBook]);

            Console.WriteLine("Ksiazki rpzeczytane");
            foreach (var item in bf.ReadBooks)
            {
                Console.WriteLine("tag: {0}, tytul: {1}", item.tag, item.tytul);
            }
        }

    }
    
     
}
