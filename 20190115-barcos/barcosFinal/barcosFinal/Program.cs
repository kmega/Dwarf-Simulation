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
            
            
            
            
            Player pl2 = new Player();
            IBattleField bf2 = new BattleField();
            bf2.DrawBoard();
            pl2.BattleField = bf;


            Console.WriteLine("Player 1 podaj X wroga");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            
          
            pl1.Shoot(x,y,pl2.GetCurrentBattleField());
            pl1.AddShip();

            Console.ReadLine();
            Console.WriteLine("Hello Ship!");
        }
    }
}
