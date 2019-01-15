using BattleShips.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models
{
    public class Shipfactory
    {
        public IShip Create(string type, string startPosition, string direction)
        {
            ShipType shipType = GetShipType(type);
            int xStart, yStart;
            TextParser.ParseFieldToInt(startPosition,out xStart,out yStart);
            switch(shipType)
            {
                case ShipType.Carrier:
                    return new CarrierShip();
                case ShipType.Battleship:
                    return new BattleShip();
            }
        }

        private ShipType GetShipType(string type)
        {
            switch (type)
            {
                case "c":
                    return ShipType.Carrier;
                case "b":
                    return ShipType.Battleship;
                case "s":
                    return ShipType.Submarine;
                case "d":
                    return ShipType.Destroyer;
                case "p":
                    return ShipType.PatrolBoat;
                default:
                    return ShipType.None;
            }
        }
    }
}
