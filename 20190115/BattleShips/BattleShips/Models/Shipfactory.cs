using BattleShips.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models
{
    public class Shipfactory
    {
        public IShip Create(string type, string startPosition, string direction, Player player)
        {
            int xStart, yStart, shipLength;
            ShipType shipType = GetShipType(type, out shipLength);
            TextParser.ParseFieldToInt(startPosition, out xStart, out yStart);
            List<string> occupiedPositions = GetOccupiedPositions(xStart, yStart, shipLength, direction);
            List<string> blockedNeighbourhood = GetBlockedNieghbourhood(occupiedPositions);
            CheckForCollisionWithOtherShipsOnBoard(occupiedPositions, blockedNeighbourhood, player.Ships);
            switch (shipType)
            {
                case ShipType.Carrier:
                    return new CarrierShip(shipType, occupiedPositions, blockedNeighbourhood);
                case ShipType.Battleship:
                    return new BattleShip(shipType, occupiedPositions, blockedNeighbourhood);
                case ShipType.Destroyer:
                    return new Destroyer(shipType, occupiedPositions, blockedNeighbourhood);
                case ShipType.Submarine:
                    return new Submarine(shipType, occupiedPositions, blockedNeighbourhood);
                case ShipType.PatrolBoat:
                    return new PatroBoat(shipType, occupiedPositions, blockedNeighbourhood);
                default:
                    return null;
            }
        }

        public void CheckForCollisionWithOtherShipsOnBoard(
            List<string> occupiedPositions, List<string> blockedNeighbourhood, List<IShip> ships)
        {
            foreach(var ship in ships)
            {
                foreach(var position in ship.OccupiedPositions)
                {
                    if (occupiedPositions.Contains(position) || blockedNeighbourhood.Contains(position))
                    {
                        throw new Exception("Error! You cannot place ship so close to others!");
                    }
                }
            }
        }

        private List<string> GetBlockedNieghbourhood(List<string> occupiedPositions)
        {
            List<string> result = new List<string>();
            int[] x = new int[occupiedPositions.Count];
            int[] y = new int[occupiedPositions.Count];
            for (int i = 0; i < occupiedPositions.Count; i++)
            {
                TextParser.ParseFieldToInt(occupiedPositions[i], out x[i], out y[i]);
            }
            if(x[0] == x[1])
            {
                if (y[1] - y[0] > 0)
                {
                    result.AddRange(FieldBlocker.BlockDownOrientedShipArea(x, y));
                }
                else
                {                 
                    result.AddRange(FieldBlocker.BlockUpOrientedShipArea(x, y));
                }
            }                
            else
            {
                if(x[1] - x[0]>0)
                {
                    result.AddRange(FieldBlocker.BlockRightOrientedShipArea(x, y));
                }
                else
                {
                    result.AddRange(FieldBlocker.BlockLeftOrientedShipArea(x, y));
                }
            }
            return result;
        }

        private List<string> GetOccupiedPositions(int xStart, int yStart, int shipLength, string direction)
        {
            List<string> result = new List<string>();
            switch (direction)
            {
                case "u":
                    for (int i = 0; i < shipLength; i++)
                    {
                        result.Add(BuildPosition(xStart, yStart - i));
                    }
                    break;
                case "d":
                    for (int i = 0; i < shipLength; i++)
                    {
                        result.Add(BuildPosition(xStart, yStart + i));
                    }
                    break;
                case "r":
                    for (int i = 0; i < shipLength; i++)
                    {
                        result.Add(BuildPosition(xStart + i, yStart));
                    }
                    break;
                case "l":
                    for (int i = 0; i < shipLength; i++)
                    {
                        result.Add(BuildPosition(xStart - i, yStart));
                    }
                    break;
                default:
                    break;
            }
            return result;
        }

        public string BuildPosition(int x, int y)
        {
            if (x >= 0 && x <= 9 && y >= 0 && y <= 9)
            {
                return TextParser.ParseIntToString(x, y);
            }
            else
            {
                throw new ArgumentException("Incorrect input, ship cannot be outside the board!");
            }
        }

        public ShipType GetShipType(string type, out int length)
        {
            switch (type)
            {
                case "c":
                    length = 5;
                    return ShipType.Carrier;
                case "b":
                    length = 4;
                    return ShipType.Battleship;
                case "s":
                    length = 3;
                    return ShipType.Submarine;
                case "d":
                    length = 3;
                    return ShipType.Destroyer;
                case "p":
                    length = 2;
                    return ShipType.PatrolBoat;
                default:
                    length = 0;
                    return ShipType.None;
            }
        }
    }
}
