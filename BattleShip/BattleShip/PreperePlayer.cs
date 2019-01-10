using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class PreperePlayer
    {

        public void ShowShips(Player player)
        {
            foreach (var ship in player.ships)
            {
                Console.WriteLine(ship.Id.ToString() + " " + ship.Lenght);
            }
        }

        public void ShowBoard(Player player)
        {
            for (int i = 0; i < 11; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("  ");
                }
                else
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < player.Player_Board.Fields.GetLength(0); i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < player.Player_Board.Fields.GetLength(1); j++)
                {
                   
                    Console.Write(player.Player_Board.Fields[i, j] + " ");
                }
                Console.WriteLine(); 
            }
        }
    }
}
