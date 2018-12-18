using System;
using System.Collections.Generic;
using System.Linq;

namespace Task
{
    class CompareBooks
    {
        public BooksFile bf = new BooksFile();
        public List<Book> TempList = new List<Book>();

        private void FiltrUnreadFantasyBooks()
        {

            FiltrFantasyBooks();
            //IEnumerable<Book> czWspolna = (bf.AllBooks).Except(bf.ReadBooks);
            //var czWspolna = bf.AllBooks.Where(b => !bf.ReadBooks.Contains(b.tytul));
            //LINQ -> nie dziala
            //usuwanie z templist ksiazek, ktore zawieraja sie w ksiazkach przeczytanych
            FiltrOnlyUnreadFantasyBooks();
        }
        private void FiltrFantasyBooks()
        {
            //Dodawanie do templist ksiazek typu fantasy
            foreach (var item in bf.AllBooks)
            {
                if (item.tag == "fantasy")
                {
                    TempList.Add(item);
                }
            }
        }
        private void FiltrOnlyUnreadFantasyBooks()
        {
            foreach (var item in bf.AllBooks)
            {
                for (int i = 0; i < bf.ReadBooks.Count; i++)
                {
                    if (bf.ReadBooks[i].tytul == item.tytul)
                    {
                        //Console.WriteLine("Usunieto");
                        TempList.Remove(item);
                    }
                }
            }
        }
        public void DisplayUnRead()
        {
            FiltrUnreadFantasyBooks();
            Console.WriteLine("Ksiazki tyou fantasy nieprzeczytane");
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

            Console.WriteLine("Ksiazki przeczytane");
            foreach (var item in bf.ReadBooks)
            {
                Console.WriteLine("tag: {0}, tytul: {1}", item.tag, item.tytul);
            }
        }

    }


}
