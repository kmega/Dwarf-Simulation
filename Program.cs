using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class DataLibrary
    {
        private string _nazwa;
        public string NazwaKsiazki
        {
            get
            {
                return _nazwa;
            }
            set
            {
                _nazwa = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DataLibrary books = new DataLibrary();
            books.NazwaKsiazki = "Blabla";

            string[,] book = new string[5, 5];
            List<string> ReadBooks = new List<string>();
            int counter = 0;

            book[0, 0] = "Harry Potter";
            book[0, 1] = "Fantasy";
            book[1, 0] = "Garry";
            book[1, 1] = "Horror";
            book[2, 0] = "Hermion";
            book[2, 1] = "Fantasy";
            ReadBooks.Add("Harry Potter");
            for (int i = 0; i < book.GetLength(0); i++)
            {
                if (book[i, 1] == "Fantasy")
                {
                    for (int j = 0; j < ReadBooks.Count; j++)
                    {
                        if (ReadBooks[j] == book[i,0])
                            counter++;

                    }
                    if (counter == 0)
                    {
                        ReadBooks.Add(book[i, 0]);
                    }
                    counter = 0;
                }
            }
            Console.ReadKey();
        }
    }
}
