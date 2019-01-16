using BattleShips.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models
{
    public interface IShip
    {
        ShipType Type { get; set; }
        List<string> OccupiedPositions { get; set; }
        List<string> DamagedPositions { get; set; }
        List<string> BlockedNeighbourhood { get; set; }
        
    }
}
