using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortStringTab
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome. Write below chars you want to sort. " +
                "Separate chars by using ',', for example: a,b,1,2");
            string input = Console.ReadLine();
            TextParser textparser = new TextParser();
            SortMachine sortmachine = new SortMachine();
            string output = String.Join(",",sortmachine.SortString(textparser.ParseInput(input)));
            Console.WriteLine(output);
            
            Console.ReadKey();

        }
    }
}
