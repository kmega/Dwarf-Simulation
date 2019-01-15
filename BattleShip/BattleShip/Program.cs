using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player(1);

            GameOver.DisplayPlayerPutsShipsOnBoard(player1);

          
         
            Console.ReadKey();

            //bool result;
            //do
            //{
            //    Game game = new Game();
            //    Player player1 = new Player(1);
            //    Player player2 = new Player(2);
            //    PutShipOnTheBoard putShipOnTheBoard = new PutShipOnTheBoard();

            //    string cordinatesShipPlaye = "a1";
            //    bool horitontal = true;
            //    int id_ship = 1;
            //    putShipOnTheBoard.PutShip(player2, cordinatesShipPlaye, horitontal, id_ship);

            //    cordinatesShipPlaye = "b3";

            //    putShipOnTheBoard.PutShip(player2, cordinatesShipPlaye, horitontal, id_ship);
            //    string coordinatePlayer1 = "a1";
            //    string coordinatePlayer2 = "a1";

            //    game.TryHitShip(player1, player2, coordinatePlayer1, coordinatePlayer2);

            //    result = GameOver.ShipsAreDestroyed(player1.Opponent_Board,1);

            //    player1.ShowBoard(player1.Opponent_Board);


            //    if (result == true)
            //    {
            //        Console.WriteLine("Gra skończona");
            //    }



            //} while ( result==false);

            //Console.ReadKey();

        }
    }
}
