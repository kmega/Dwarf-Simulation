using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task101
{
    class Program
    {
        static void Main(string[] args)
        {
            //PULA KSIĄŻEK
            List<string> LibraryOfBooks = new List<String> {"Fantasy", "YA", "Horror"};
            Console.WriteLine("Jaki gatunek książki? Fantasy/YA");
            string typeofbook = Console.ReadLine();
            //GATUNKI KSIĄŻEK
            List<string> FantasyBooks = new List<string> { "book 1f", "book 2f", "book 3f", "book 4f"};
            List<string> YABooks = new List<string> { "book1ya", "book2ya" };
            //2.ksiazki[fantasy] => tylko ksiazki[fantasy], ktore sa nieprzeczytane
            //3.ksiazki, ktore sa nieprzeczytane[f] => wybierz ksiazke losowo
            //4.wybrana ksiazka,3h = czytam = produkuje ksiazke przeczytana
            string choosenbook;          
            List<string> NotReadYetBooksFantasy = new List<string> { "book 1f" };
            List<string> NotReadYetBooksYA = new List<string> { "book2ya" };
            if (typeofbook == "Fantasy")
            {
                choosenbook = NotReadYetBooksFantasy[0];
                Console.WriteLine("Czytam "+ choosenbook + " przez 3 h");
            }
            else
            {
                choosenbook = NotReadYetBooksYA[0];
                Console.WriteLine("Czytam " + choosenbook + " przez 3 h");
            }
            //5.ksiazka czytana, pula ksiazek fantasy =>
            Console.WriteLine("Książka odłożona na miejsce");
            Console.ReadKey();
        
        }
    }
}
