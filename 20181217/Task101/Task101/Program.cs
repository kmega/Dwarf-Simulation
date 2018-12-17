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
        static List<string> _list_of_fantasy_books = new List<string>();

        static void Main(string[] args)
        {
            Book _Pool_of_books = new Book();
            _books = _Pool_of_books._books;

            Filtr list_of_fantasy = new Filtr();
            _list_of_fantasy_books = list_of_fantasy._create_list_of_fantasy_books(_books);


            Read reader = new Read();
            reader.Czytam(_list_of_fantasy_books);



            Console.ReadKey();
        
        }
    }
}
