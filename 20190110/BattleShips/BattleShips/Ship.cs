using BattleShips.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    public class Ship
    {
        public ShipType Type { get; set; }
        public List<string> OccupiedPositions { get; set; }
    }
}
