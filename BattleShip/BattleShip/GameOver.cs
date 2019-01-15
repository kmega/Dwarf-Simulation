using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public static class GameOver
    {
        static public bool ShipsAreDestroyed(Board board, int counter)
        {
            bool result = false;

            int count = 0;

            foreach (var field in board.Fields)
            {
                if (field == Field.H)
                {
                    count++;
                }
            }

            if (count == counter)
            {
                result = true;
            }

            return result;
        }

        static public void DisplayPlayerPutsShipsOnBoard(Player player)
        {
            if (player.ships.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("    Welcome in BattleShips \n");
                Console.WriteLine($"\t PLAYER {player.Id}\n");
                Console.WriteLine("Availible ships: \n");

                foreach (var ship in player.ships)
                {
                    Console.WriteLine($"Ship: {ship.Id} Length {ship.Lenght}");
                }
                Console.WriteLine("\nPut your ships on the board\n");

                player.ShowBoard(player.Player_Board);
            }
        }

        

       
    }
}
