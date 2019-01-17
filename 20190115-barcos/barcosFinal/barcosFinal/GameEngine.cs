using barcosFinal.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace barcosFinal
{
    class  GameEngine
    {
        public void StartGame()
        {
            UI ui = new UI();
            Player pl1 = new Player();
            IBattleField bf = new BattleField();
            IBattleField bfToDisplay = new BattleField();
            bf.DrawBoard();
            bfToDisplay.DrawBoard();
            pl1.BattleField = bf;
            pl1.AddShip();


            Player pl2 = new Player();
            IBattleField bf2 = new BattleField();
            IBattleField bfToDisplay2 = new BattleField();
            bf2.DrawBoard();
            bfToDisplay2.DrawBoard();
            pl2.BattleField = bf2;
            ui.ShowBoard(bf2.Board);
            pl2.AddShip();

            do
            {
                PlayersTour(pl1, pl2,ui);

            } while (pl1.AllMasts > 0 || pl2.AllMasts > 0);


            if (pl1.AllMasts > pl2.AllMasts)
                Console.WriteLine("PLAYER 1 WIN");
            else
            {
                Console.WriteLine("PLAYER 2 WIN");
            }

            Console.ReadLine();
            Console.WriteLine("Hello Ship!");
        }

        private void PlayersTour(Player pl1, Player pl2, UI ui)
        {
            do
            {
                Console.WriteLine("PLAYER 1 write X,Y of enemy");

                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());

                ui.ShowBoard(pl1.Shoot(pl2, x, y, pl2.GetCurrentBattleField()));
            } while (pl1.OnRage == true);


            do
            {
                Console.WriteLine("PLAYER 2 write X,Y of enemy");

                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());

                ui.ShowBoard(pl2.Shoot(pl1, x, y, pl1.GetCurrentBattleField()));
            } while (pl2.OnRage == true);
        }
    }
}
