using barcosFinal.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace barcosFinal
{
    class GameEngine
    {
        public void StartGame()
        {

            UI ui = new UI();
            Player pl1 = new Player();
            Player pl2 = new Player();
            PlayersInitiation(pl1,pl2);

            Thread.Sleep(2000);
            Console.Clear();


            IBattleField bf = new BattleField();
            IBattleField bfToDisplay = new BattleField();
            bf.DrawBoard();
            bfToDisplay.DrawBoard();
            pl1.BattleField = bf;
            pl1.BattleFieldToDisplay = bfToDisplay;
            ui.ShowBoard(bf.Board);
            pl1.AddShip();

            Console.Clear();

            IBattleField bf2 = new BattleField();
            IBattleField bfToDisplay2 = new BattleField();
            bf2.DrawBoard();
            bfToDisplay2.DrawBoard();
            pl2.BattleField = bf2;
            pl2.BattleFieldToDisplay = bfToDisplay2;
            ui.ShowBoard(bf2.Board);
            pl2.AddShip();


            do
            {
                PlayersTour(pl1, pl2, ui);

            } while (pl1.AllMasts > 0 || pl2.AllMasts > 0);


            if (pl1.AllMasts > pl2.AllMasts)
                Console.WriteLine("PLAYER {0} WIN", pl1.Name);
            else
            {
                Console.WriteLine("PLAYER {0} WIN", pl2.Name);
            }

            Console.ReadLine();
            Console.WriteLine("Hello Ship!");
        }

        private void PlayersInitiation(Player pl1, Player pl2)
        {
            pl1.Name = AskPlayerForName();
            pl2.Name = AskPlayerForName();
        }

        private string AskPlayerForName()
        {
            Console.WriteLine("What is Your name Player 1?");
            string name = Console.ReadLine();
            Console.WriteLine("Welcome in BattleShip Game {0}!", name);

            return name;
        }

        private void PlayersTour(Player pl1, Player pl2, UI ui)
        {
            

            do
            {
                Console.Clear();
                ui.ShowBoard(pl1.BattleFieldToDisplay.Board);
                Console.WriteLine("{0} write X,Y of enemy", pl1.Name);
                
                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());

                Console.Clear();
                ui.ShowBoard(pl1.Shoot(pl2, x, y, pl2.GetCurrentBattleField()));
                Console.WriteLine("Next tour is coming!");
                Thread.Sleep(2000);
            } while (pl1.OnRage == true);


            do
            {
                Console.Clear();
                ui.ShowBoard(pl2.BattleFieldToDisplay.Board);
                Console.WriteLine("{0} write X,Y of enemy", pl2.Name);

                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());

                Console.Clear();
                ui.ShowBoard(pl2.Shoot(pl1, x, y, pl1.GetCurrentBattleField()));
                Console.WriteLine("Next tour is coming!");
                Thread.Sleep(2000);
            } while (pl2.OnRage == true);
        }
    }
}
