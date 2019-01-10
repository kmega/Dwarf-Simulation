using BattleShips.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    public class Ship
    {
        public Ship(ShipType type, List<string> positions, Player player)
        {
            Type = type;
            OccupiedPositions = positions;
            player.RegisterShip(this);
        }
        public ShipType Type { get; private set; }
        public List<string> OccupiedPositions { get; private set; }
        public List<string> DamagedPositions { get; set; }
    }
}
