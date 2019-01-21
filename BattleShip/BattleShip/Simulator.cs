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

            bool player1_loose = false;
            bool player2_loose = false;
            do
            {
                PlayTurn(player1, player2);
                player1_loose = GameOver.ShipsAreDestroyed(player2.Player_Board);
                PlayTurn(player2, player1);
                player2_loose = GameOver.ShipsAreDestroyed(player1.Player_Board);

            } while (player1_loose && player2_loose);

            Console.Clear();
            DisplayWinner(player1_loose, player2_loose);
         

        }

        private void DisplayWinner(bool player1_loose, bool player2_loose)
        {
            if (!(player1_loose) && !(player2_loose))
            {
                Console.WriteLine("Remis");
            }
            else if (!player1_loose)
            {
                Console.WriteLine("Wygrał gracz 1");
            }
            else if (!player2_loose)
            {
                Console.WriteLine("Wygrał gracz 2");
            }
        }

        public void PlayTurn(Player shooter, Player victim)
        {
            Arena arena = new Arena();

            Console.WriteLine($@"Graczu {shooter.Id}  Twoja tablica strzałów");
            shooter.ShowBoard(shooter.ShootBoard);
            Console.WriteLine("Podaj koordynaty strzału");
            string coordinates = Console.ReadLine();

            arena.Fight(shooter, victim, coordinates);
            Console.Clear();
            Console.WriteLine($"Gracz {shooter.Id} Tablica po strzale");
            shooter.ShowBoard(shooter.ShootBoard);
            Console.ReadKey();
            Console.Clear();
        }
        public void InitializePlayerBoard(Player player)
        {
            PutShipOnTheBoard PutShipOnTheBoard = new PutShipOnTheBoard();
            int j = 1;
            string coordinates = "";
            bool horizontal;
            string horizontal_string = "";
            bool flag;

            for (int i = 0; i < player.ships.Count; i++)
            {
                Console.WriteLine($"Gracz {player.Id}");
                player.ShowShips(player);
                Console.WriteLine();
                player.ShowBoard(player.Player_Board);
                Console.WriteLine();
                Console.WriteLine($"Rozmieść " + j + " statek");
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

                flag = PutShipOnTheBoard.PutShip(player, coordinates, horizontal, j);
                if (flag)
                {
                    Console.Clear();
                    j++;
                }
                else
                {
                    Console.WriteLine("Nie udało się dodać statku. Błędne koordynaty");
                    i--;
                    Console.ReadKey();
                    Console.Clear();
                }

            }

            Console.WriteLine("Rozmieszczone statki");
            player.ShowBoard(player.Player_Board);
            Console.WriteLine("Naciśnij enter");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
