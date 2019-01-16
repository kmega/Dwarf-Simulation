using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class PutShipOnTheBoard
    {
        public void PutShip(Player player, string Coordinates, bool horizontal, int id_ship)
        {

            int[] coordinate = CoordinatesParser(Coordinates);
            coordinate[0]--; 
            coordinate[1]--;
            id_ship--;

            if (CheckIfShipIsOutOfBord(player, coordinate, horizontal, id_ship))
            {
                for (int i = 0; i < player.ships[id_ship].Lenght; i++)
                {
                    if (horizontal)
                    {
                        player.Player_Board.Fields[coordinate[0] + i, coordinate[1]] = Field.S;
                    }
                    else
                    {
                        player.Player_Board.Fields[coordinate[0], coordinate[1] + i] = Field.S;
                    }
                }
            }

        }

        public bool CheckIfShipIsOutOfBord(Player player, int[] coordinate, bool horizontal, int id_ship)
        {
            for (int i = 0; i < player.ships[id_ship].Lenght; i++)
            {
                if (horizontal)
                {
                      return (coordinate[0] + player.ships[id_ship].Lenght < 10);
                }
                else
                {
                    return (coordinate[0] + player.ships[id_ship].Lenght < 10);
                }
            }
            return false;
        }
       public int[] CoordinatesParser(string Coordinates)
        {
            Coordinates = Coordinates.ToLower();
            int[] result = new int[2];
            result[0] = (Coordinates[0] % 97) + 1;

            string second_coordinate= "";
            for (int i = 1; i < Coordinates.Count(); i++)
            {
                second_coordinate += Coordinates[i];
            }
            result[1] = Int32.Parse(second_coordinate);
            
            return result;

        }
    }
}
