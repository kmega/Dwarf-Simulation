using BattleShips.Enums;
using System.Collections.Generic;

namespace BattleShips
{
    public class Ship
    {
        public List<string> DamagedPositions { get; set; }

        public List<string> OccupiedPositions { get; private set; }

        public ShipType Type { get; private set; }

        public Ship(ShipType type, List<string> positions, Player player)
        {
            Type = type;
            OccupiedPositions = positions;
        }
    }
}