using BattleShips.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BattleShips
{
    public class ShipFactory
    {
        private List<string> UnavailablePositions;
        public ShipFactory()
        {
            UnavailablePositions = new List<string>();
        }
        public void PlaceSingleShip(string shipType, string startingPoint, string direction, Player player)
        {
            ShipType type = GetShipType(shipType);
            int length = GetShipLength(type);
            Direction direct = GetDirection(direction);
            List<string> positions = BuildShipPositions(startingPoint, direct, length, player);
            player.FieldWithShips.AddRange(positions);    
        }

        public List<string> BuildShipPositions(string startingPoint, Direction direct, int length, Player player)
        {
            List<string> positions = new List<string>();
            positions.Add(startingPoint);
            var temporaryString = startingPoint.Insert(1, ",");
            var splitted = temporaryString.Split(",");
            for(int i = 0; i<length - 1; i++)
            {
                if(direct == Direction.Down)
                {
                    int verticalPosition = Int32.Parse(splitted[1]) + (i+1);
                    CheckVerticalPosition(verticalPosition);
                    positions.Add(splitted[0] + verticalPosition.ToString());
                }
                if(direct == Direction.Up)
                {
                    int verticalPosition = Int32.Parse(splitted[1]) - (i+1);
                    CheckVerticalPosition(verticalPosition);
                    positions.Add(splitted[0] + verticalPosition.ToString());
                }
                if(direct == Direction.Right)
                {
                    char letter = splitted[0].ToCharArray().First();
                    var horizontalPosition = letter + (i + 1);
                    CheckHorizontalPosition(horizontalPosition);
                    positions.Add(Convert.ToChar(horizontalPosition) + splitted[1]);
                }
                if(direct == Direction.Left)
                {
                    char letter = splitted[0].ToCharArray().First();
                    var horizontalPosition = letter - (i + 1);
                    CheckHorizontalPosition(horizontalPosition);
                    positions.Add(Convert.ToChar(horizontalPosition) + splitted[1]);
                }             
            }
            return positions;
        }

        public void CheckHorizontalPosition(int horizontalPosition)
        {
            if(horizontalPosition <65 || horizontalPosition > 74)
            {
                throw new ArgumentException("Ship placed inproperly, try again: ");
            }
        }

        public void CheckVerticalPosition(int verticalPosition)
        {
            if(verticalPosition > 10 || verticalPosition < 1)
            {
                throw new ArgumentException("Ship placed inproperly, try again: ");
            }
        }

        private ShipType GetShipType(string shipType)
        {
            switch (shipType)
            {
                case "c":
                case "C":
                    return ShipType.Carrier;
                case "s":
                case "S":
                    return ShipType.Submarine;
                case "b":
                case "B":
                    return ShipType.BattleShip;
                case "d":
                case "D":
                    return ShipType.Destroyer;
                case "p":
                case "P":
                    return ShipType.PatrolBoat;
                default:
                    return ShipType.None;
            }
        }

        private Direction GetDirection(string direction)
        {
            switch(direction)
            {
                case "l":
                case "L":
                    return Direction.Left;
                case "r":
                case "R":
                    return Direction.Right;
                case "u":
                case "U":
                    return Direction.Up;
                case "d":
                case "D":
                    return Direction.Down;
                default:
                    return Direction.None;
            }
        }

        private int GetShipLength(ShipType shipType)
        {
            switch(shipType)
            {
                case ShipType.Carrier:
                    return 5;
                case ShipType.BattleShip:
                    return 4;
                case ShipType.Destroyer:
                case ShipType.Submarine:
                    return 3;
                case ShipType.PatrolBoat:
                    return 2;
                default:
                    return 0;
            }
        }

    }
}
