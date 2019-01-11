using System.Collections.Generic;

namespace BattleShips
{
    public class Player
    {
        public List<Ship> AvailableShips { get; private set; }
        public bool IsActive { get; set; }

        public Player()
        {
            AvailableShips = new List<Ship>();
        }
        public void DestroyShip(Ship ship)
        {
            AvailableShips.Remove(ship);
        }

        public void RegisterShip(Ship ship)
        {
            AvailableShips.Add(ship);
        }
    }
}