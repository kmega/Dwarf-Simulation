using System;

namespace Animals
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Bear bear = new Bear();
            Console.WriteLine(bear.Introduce());
            Console.ReadKey();
        }
    }
}