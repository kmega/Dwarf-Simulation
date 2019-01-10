using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    public class Player
    {
        public Player()
        {
            AvailableShips = new List<Ship>();
        }
        public List<Ship> AvailableShips { get; private set; }
        public void RegisterShip(Ship ship)
        {
            AvailableShips.Add(ship);
        }
        public void DestroyShip(Ship ship)
        {
            AvailableShips.Remove(ship);
        }
    }
}
