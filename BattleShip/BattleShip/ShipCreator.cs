using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public static class ShipCreator
    {
        
        public static List<Ship> ReadShipsFromConfigFile()
        {
            List<Ship> ships = new List<Ship>();

            string[] file = File.ReadAllLines(@"..\..\..\ShipConfig.md");

            foreach (var line in file)
            {
                string[] lines = line.Split(',');
                lines[0] = lines[0].Replace("ID: ", "");
                lines[1] = lines[1].Replace(" Length: ", "");

                ships.Add(new Ship(int.Parse(lines[0]), int.Parse(lines[1])));
            }

            return ships;
        }
    }
}
