using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task101
{
    class Program
    {
        enum books
        {
            Harry_Potter,
            Wladca_Pierscieni,
            Igrzyska_Smierci
        }

        static void Main(string[] args)
        {
            List<books> notReadenBooks = new List<books>();
            notReadenBooks.Add(books.Harry_Potter);
            notReadenBooks.Add(books.Wladca_Pierscieni);

            List<books> readenBooks = new List<books>();


            //1. Lista nieprzeczytanych książek fantasy -- filtr weź książkę --> randomowa książka
            books book = TakeBook(notReadenBooks);
            //2. książka -- czytaj 3 godziny
            ReadBook(book);
            //3. książka -- odłóż(książka) --> lista nieprzeczytanych książek fantasy
            readenBooks.Add(book);

            Console.ReadKey();
        }

        private static void ReadBook(books book)
        {

            Console.WriteLine($"I am reading book: {book}");
        }

        private static books TakeBook(List<books> notReadenBook)
        {
            var random = new Random();

            int index = random.Next(notReadenBook.Count);
            return (notReadenBook[index]);
        }

    }
}
