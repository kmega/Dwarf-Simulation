using System;
using System.IO;

namespace HappyPathsWithTests
{
    class Program
    {
        static void Main(string[] args)
        {
            new Task1().Displayresults();

            Console.ReadKey();
        }
    }

    public class Task1
    {
        public void Displayresults()
        {
            string path = @"..\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
            string preForm = "{0} był budowany {1} minuty";

            Console.WriteLine("### Task 1");
            Console.WriteLine(preForm, new Methods().GetName(path), new Methods().GetTime(path));
            Console.WriteLine();

            new FileOps().SaveToFile(@"..\Results\Result1.txt", new Methods().GetName(path), new Methods().GetTime(path), preForm);
        }
    }


    
}
