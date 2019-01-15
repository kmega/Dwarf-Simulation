using BattleShips.Enums;
using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipsTests
{
    class FakeCarrier : IShip
    {
        public FakeCarrier()
        {
            OccupiedPositions = new List<string>()
            {
                "C2","C3","C4","C5","C6"
            };
            BlockedNeighbourhood = new List<string>()
            {

            };
            Type = ShipType.Carrier;
            DamagedPositions = new List<string>();
        }
        public ShipType Type { get; set; }
        public List<string> OccupiedPositions { get; set; }
        public List<string> DamagedPositions { get; set; }
        public List<string> BlockedNeighbourhood { get; set; }
    }
}
