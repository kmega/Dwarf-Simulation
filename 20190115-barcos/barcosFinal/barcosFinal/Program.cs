using System;
using barcosFinal.Interfaces;

namespace barcosFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            Player pl1 = new Player();
            IBattleField bf = new BattleField();
            bf.DrawBoard();
            pl1.BattleField = bf;

            pl1.AddShip();

            Console.ReadLine();
            Console.WriteLine("Hello Ship!");
        }
    }
}
