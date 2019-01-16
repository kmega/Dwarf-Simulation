using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
         

                Game game = new Game();
                Player player1 = new Player(1);
                Player player2 = new Player(2);
                PutShipOnTheBoard putShipOnTheBoard = new PutShipOnTheBoard();
                int i = 1;
                string coordinates = "";
                bool horizontal;
                string horizontal_string = "";
                foreach (var ship in player1.ships)
                {
                    Console.WriteLine("Gracz 1");
                    player1.ShowShips(player1);
                    Console.WriteLine();
                    player1.ShowBoard(player1.Player_Board);
                    Console.WriteLine();
                    Console.WriteLine("Rozmieść " + i + " statek");
                    Console.WriteLine("Podaj koordynaty np. A1");
                    coordinates = Console.ReadLine();
                    Console.WriteLine("Rozmieścić statek poziomo: 1, pionowo: 2");
                    horizontal_string = Console.ReadLine();
                    if (horizontal_string == "1")
                    {
                        horizontal = true;
                    }
                    else { horizontal = false; };

                    putShipOnTheBoard.PutShip(player1, coordinates, horizontal, i);
                    Console.Clear();
                    i++;

                }
                Console.WriteLine("Rozmieszczone statki");
                player1.ShowBoard(player1.Player_Board);
                Console.WriteLine("Naciśnij enter");
                Console.ReadKey();
                Console.Clear();
                i = 1;


                foreach (var ship in player2.ships)
                {
                    Console.WriteLine("Gracz 2");
                    player1.ShowShips(player2);
                    Console.WriteLine();
                    player1.ShowBoard(player2.Player_Board);
                    Console.WriteLine();
                    Console.WriteLine("Rozmieść " + i + " statek");
                    Console.WriteLine("Podaj koordynaty np. A1");
                    coordinates = Console.ReadLine();
                    Console.WriteLine("Rozmieścić statek poziomo: 1, pionowo: 2");
                    horizontal_string = Console.ReadLine();
                    if (horizontal_string == "1")
                    {
                        horizontal = true;
                    }
                    else { horizontal = false; };

                    putShipOnTheBoard.PutShip(player2, coordinates, horizontal, i);
                    Console.Clear();
                    i++;
<<<<<<< HEAD

                }

            Console.WriteLine("Rozmieszczone statki");
            player1.ShowBoard(player2.Player_Board);
            Console.WriteLine("Naciśnij enter");
            Console.ReadKey();
            Console.Clear();

=======

                }

            Console.WriteLine("Rozmieszczone statki");
            player1.ShowBoard(player2.Player_Board);
            Console.WriteLine("Naciśnij enter");
            Console.ReadKey();
            Console.Clear();

>>>>>>> 04bf77e93525bbf5fdadb16d4fbf1fd644afd1fd
            do
            {
                string cordinatesShipPlaye = "a1";
                bool horitontal = true;
                int id_ship = 1;
                putShipOnTheBoard.PutShip(player2, cordinatesShipPlaye, horitontal, id_ship);
>>>>>>> 04bf77e93525bbf5fdadb16d4fbf1fd644afd1fd

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

<<<<<<< HEAD
<<<<<<< HEAD
            //    game.TryHitShip(player1, player2, coordinatePlayer1, coordinatePlayer2);
=======
=======
>>>>>>> 04bf77e93525bbf5fdadb16d4fbf1fd644afd1fd
                
                
>>>>>>> 04bf77e93525bbf5fdadb16d4fbf1fd644afd1fd

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
