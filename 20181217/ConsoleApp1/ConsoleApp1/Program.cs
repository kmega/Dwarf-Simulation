using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static string[] task101(string[] bookList)
        {
            Console.Clear();
            bool first = false;
            while (first != true)
            {
                for (int i = 0; i < bookList.Length; i++)
                {
                    if (first == false)
                    {
                        if (bookList[i].Split(' ')[0] == "Fantasy")
                        {
                            bookList[i] = "Fantasy Przeczytana";
                            first = true;
                        }
                    }
                    Console.WriteLine(bookList[i]);
                }
            }
            return bookList;
        }
        static void Main(string[] args)
        {
            string[] bookList = { "Sci-Fi", "Fantasy", "Criminal", "Fantasy", "Fantasy", "Fantasy", "Fantasy" };
            string userInput = "";
            int choice = 0;
            for (int i = 0; i < bookList.Length; i++)
            {
                Console.WriteLine(bookList[i]);
            }
            Console.WriteLine("\n1 - Task101\n");
            userInput = Console.ReadLine();
            choice = Convert.ToInt32(userInput);
            switch (choice)
            {
                case 1:
                    bookList = task101(bookList);
                    break;
                default:
                    Console.WriteLine("Wrong input.");
                    break;
            }
            Console.ReadKey();
        }
    }
}
