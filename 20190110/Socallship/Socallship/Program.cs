using System;

namespace Socallship
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player();
            BoardGame board1 = p1.Board;
            board1.AddShip(p1.ship,true);
            board1.ShowBoard();
            Console.ReadKey();

        }
    }
}
