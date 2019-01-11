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
            for (int i = 0; i < length - 1; i++)
            {
                if (direct == Direction.Down)
                {
                    int verticalPosition = Int32.Parse(splitted[1]) + (i + 1);
                    CheckVerticalPosition(verticalPosition);
                    positions.Add(splitted[0] + verticalPosition.ToString());
                }
                if (direct == Direction.Up)
                {
                    int verticalPosition = Int32.Parse(splitted[1]) - (i + 1);
                    CheckVerticalPosition(verticalPosition);
                    positions.Add(splitted[0] + verticalPosition.ToString());
                }
                if (direct == Direction.Right)
                {
                    char letter = splitted[0].ToCharArray().First();
                    var horizontalPosition = letter + (i + 1);
                    CheckHorizontalPosition(horizontalPosition);
                    positions.Add(Convert.ToChar(horizontalPosition) + splitted[1]);
                }
                if (direct == Direction.Left)
                {
                    char letter = splitted[0].ToCharArray().First();
                    var horizontalPosition = letter - (i + 1);
                    CheckHorizontalPosition(horizontalPosition);
                    positions.Add(Convert.ToChar(horizontalPosition) + splitted[1]);           
                }
                CheckCollisionPositions(positions, player);
                BuildUnavailablePositions(positions, direct);
            }
            return positions;
        }
        private void CheckCollisionPositions(List<string> positions, Player player)
        {
            foreach (var position in positions)
            {
                var result = player.FieldWithShips.Where(x => x == position).FirstOrDefault();
                if (result != null)
                {
                    throw new ArgumentException("Ship placed inproperly, try again: ");
                }
            }
        }
        public void BuildUnavailablePositions(List<string> positions, Direction direction)
        {
            foreach (var position in positions)
            {
                var temporaryString = position.Insert(1, ",");
                var splitted = temporaryString.Split(",");
                if (direction == Direction.Left || direction == Direction.Right)
                {
                    UnavailablePositions.Add(splitted[0] + (Int32.Parse(splitted[1]) + 1));
                    UnavailablePositions.Add(splitted[0] + (Int32.Parse(splitted[1]) - 1));
                }
            }
            if (direction == Direction.Left || direction == Direction.Right)
            {
                var leftPos = positions.First();
                var rightPos = positions.Last();
                var temporaryStringLeft = leftPos.Insert(1, ",");
                var splittedLeft = temporaryStringLeft.Split(",");
                char letter = splittedLeft[0].ToCharArray().First();
                var horizontalPosition = letter -1;
                UnavailablePositions.Add(Convert.ToChar(horizontalPosition) + (Int32.Parse(splittedLeft[1]) +1).ToString());
                UnavailablePositions.Add(Convert.ToChar(horizontalPosition) + (Int32.Parse(splittedLeft[1]) -1).ToString());
                UnavailablePositions.Add(Convert.ToChar(horizontalPosition) + (splittedLeft[1]));

                var temporaryStringRight = rightPos.Insert(1, ",");
                var splittedRight = temporaryStringRight.Split(",");
                char letter2 = splittedRight[0].ToCharArray().First();
                var horizontalPosition2 = letter2 + 1;
                UnavailablePositions.Add(Convert.ToChar(horizontalPosition2) + (Int32.Parse(splittedLeft[1]) + 1).ToString());
                UnavailablePositions.Add(Convert.ToChar(horizontalPosition2) + (Int32.Parse(splittedLeft[1]) - 1).ToString());
                UnavailablePositions.Add(Convert.ToChar(horizontalPosition2) + (splittedLeft[1]));
            
}
            if (direction == Direction.Up || direction == Direction.Down)
            {

            }

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
