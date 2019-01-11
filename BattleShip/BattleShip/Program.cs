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
            Player player = new Player(1);
            PutShipOnTheBoard putShipOnTheBoard = new PutShipOnTheBoard();

            player.ShowBoard(player);

            putShipOnTheBoard.PutShip(player, "B2", true, 2);
            Console.WriteLine();
            player.ShowBoard(player);
            Console.ReadKey();


        }
    }
}
