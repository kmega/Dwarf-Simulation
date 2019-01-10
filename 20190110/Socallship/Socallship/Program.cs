using System;

namespace Socallship
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player();
            Player p2 = new Player();
            p1.TryToHit(p2.Board);
            Console.ReadKey();

        }
    }
}
