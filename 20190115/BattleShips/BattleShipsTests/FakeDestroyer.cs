using BattleShips.Enums;
using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipsTests
{
    class FakeDestroyer : IShip
    {
        public FakeDestroyer(string direction)
        {
            if(direction == "u")
            {
                OccupiedPositions = new List<string>()
            {
                "G6", "G5", "G4"
            };
                BlockedNeighbourhood = new List<string>()
            {
                "F7","G7","H7","H6","H5","H4","H3","G3","F3","F4","F5","F6"
            };
            }
            if(direction == "d")
            {
                OccupiedPositions = new List<string>()
            {
                "G6", "G7", "G8"
            };
                BlockedNeighbourhood = new List<string>()
            {
                "F5","G5","H5","H6","H7","H8","H9","G9","F9","F8","F7","F6"
            };
            }
            if(direction == "r")
            {
                OccupiedPositions = new List<string>()
            {
                "G6","H6","I6"
            };
                BlockedNeighbourhood = new List<string>()
            {
                "F5","G5","H5","I5","J5","J6","J7","I7","H7","G7","F7","F6"
            };
            }
            if(direction == "l")
            {
                OccupiedPositions = new List<string>()
            {
                "G6", "F6", "E6"
            };
                BlockedNeighbourhood = new List<string>()
            {
                "D5","D6","D7","H5","H6","H7","E5","F5","G5","E7","F7","G7"
            };
            }
            Type = ShipType.Destroyer;
            
            DamagedPositions = new List<string>();
        }
        public ShipType Type { get; set; }
        public List<string> OccupiedPositions { get; set; }
        public List<string> DamagedPositions { get; set; }
        public List<string> BlockedNeighbourhood { get; set; }
    }
}
