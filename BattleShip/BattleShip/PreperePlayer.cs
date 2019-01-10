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
    }
}
