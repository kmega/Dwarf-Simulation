using System;
using barcosFinal.Interfaces;

namespace barcosFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            
            UI ui = new UI();
            Player pl1 = new Player();
            IBattleField bf = new BattleField();
            bf.DrawBoard();
            pl1.BattleField = bf;

            pl1.AddShip();
            
            
            
            
            Player pl2 = new Player();
            IBattleField bf2 = new BattleField();
            bf2.DrawBoard();
            pl2.BattleField = bf2;
            pl2.AddShip();




            do
            {
                Console.WriteLine("PLAYER 1 podaj X wroga");

                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());

                pl1.Shoot(x,y,pl2.GetCurrentBattleField());
                
                ui.ShowBoard(pl2.GetCurrentBattleField());
                
                Console.WriteLine("PLAYER 2 podaj X wroga");
                
                x = int.Parse(Console.ReadLine());
                y = int.Parse(Console.ReadLine());
                
                pl2.Shoot(x,y,pl1.GetCurrentBattleField());

                ui.ShowBoard(pl1.GetCurrentBattleField());

            } while (pl1.AllMasts > 0 || pl2.AllMasts > 0);
                
            
            if (pl1.AllMasts>pl2.AllMasts)
                Console.WriteLine("PLAYER 1 WIN");
            else
            {
                Console.WriteLine("PLAYER 2 WIN");
            }

            Console.ReadLine();
            Console.WriteLine("Hello Ship!");
        }
    }
}
