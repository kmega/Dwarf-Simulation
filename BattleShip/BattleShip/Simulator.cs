using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Simulator
    {
        public void Simulate()
        {


            Fight fight = new Fight();
            Player player1 = new Player(1);
            Player player2 = new Player(2);
            
            InitializePlayerBoard(player1);
            InitializePlayerBoard(player2);

        }

        public void InitializePlayerBoard(Player player)
        {
            PutShipOnTheBoard PutShipOnTheBoard = new PutShipOnTheBoard();
            int i = 1;
            string coordinates = "";
            bool horizontal;
            string horizontal_string = "";

            foreach (var item in player.ships)
            {
                Console.WriteLine($"Gracz {player.Id}");
                player.ShowShips(player);
                Console.WriteLine();
                player.ShowBoard(player.Player_Board);
                Console.WriteLine();
                Console.WriteLine($"Rozmieść " + i + " statek");
                Console.WriteLine("Podaj koordynaty ,np. A1");
                coordinates = Console.ReadLine();
                Console.WriteLine("Rozmiesć statek poziomo: 1, pionowo 2");
                horizontal_string = Console.ReadLine();
                if (horizontal_string == "1")
                {
                    horizontal = true;
                }
                else
                {
                    horizontal = false;
                };

                PutShipOnTheBoard.PutShip(player, coordinates, horizontal, i);
                Console.Clear();
                i++;
                
            }

            Console.WriteLine("Rozmieszczone statki");
            player.ShowBoard(player.Player_Board);
            Console.WriteLine("Naciśnij enter");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
