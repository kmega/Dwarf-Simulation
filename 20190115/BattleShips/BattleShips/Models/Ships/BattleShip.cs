using System.Collections.Generic;
using BattleShips.Enums;

namespace BattleShips.Models
{
    public class BattleShip : IShip
    {
        public BattleShip(ShipType shipType, List<string> occupiedPositions, List<string> blockedNeighbourhood)
        {
            this.Type = shipType;
            this.OccupiedPositions = occupiedPositions;
            this.BlockedNeighbourhood = blockedNeighbourhood;
            DamagedPositions = new List<string>();
        }
        public ShipType Type { get; set; }
        public List<string> OccupiedPositions { get; set; }
        public List<string> DamagedPositions { get; set; }
        public List<string> BlockedNeighbourhood { get; set; }
    }
}