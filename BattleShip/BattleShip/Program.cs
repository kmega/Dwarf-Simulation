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
           
            player1.ShowShips(player1);

           
            player1.ShowBoard(player1);
           

            Console.ReadKey();


        }
    }
}
