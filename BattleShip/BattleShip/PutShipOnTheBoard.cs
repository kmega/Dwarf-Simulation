using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class PutShipOnTheBoard
    {
        public void PutShip(Player player, string Coordinates)
        {
            int[] coordinate = CoordinatesParser(string Coordinates);


        }

        int[] CoordinatesParser(string Coordinates)
        {
            int[] result = new int[1];
            string first = Coordinates[1].ToString();
            result[0] = Int32.Parse(first);

            return result;

        }
    }
}
