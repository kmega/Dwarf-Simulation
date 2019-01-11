using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BattleshipWarTest")]

namespace BattleshipsWar
{
    class StartGame
    {
        public CellProperty[,] PlayerOneBoard = MakeBoard();
        public CellProperty[,] PlayerTwoBoard = MakeBoard();

        private bool AllShipsPlaced = false;
        private int CounterOfShipsPlaced = 0;

        private int[] Coords = { -1, -1 };

        internal void PlaceShips()
        {
            string placement = "", direction;
            while (AllShipsPlaced == false)
            {
                Console.WriteLine("Choose where you want to place a ship:");
                placement = Console.ReadLine();
                Console.WriteLine("Choose ship direction (Up, right, Down, Left):");
                direction = Console.ReadLine();
                Console.Clear();
                if (CounterOfShipsPlaced <= 7)
                {
                    PlayerOneBoard = PlaceShipOnBoard(PlayerOneBoard, placement, direction);
                }
                else
                {
                    PlayerTwoBoard = PlaceShipOnBoard(PlayerTwoBoard, placement, direction);
                }
            }
        }

        internal static CellProperty[,] MakeBoard()
        {
            CellProperty[,] Board = new CellProperty[10, 10];

            for (int i = 0; i < Board.GetLength(i); i++)
            {
                for (int j = 0; j < Board.GetLength(j); j++)
                {
                    Board[i, j] = CellProperty.Empty;
                }
            }

            return Board;
        }

        private CellProperty[,] PlaceShipOnBoard(CellProperty[,] board, string placement, string direction)
        {
            InputParser check = new InputParser();
            Coords = check.ChangeCordsToIndexes(placement);

            if (Coords[0] == -1 && Coords[1] == -1)
            {
                Console.WriteLine("Wrong coordinates!\n\n");
                return board;
            }

            direction = direction.ToLower();

            Direction userChoice;

            switch (direction)
            {
                case "up":
                    userChoice = Direction.Up;
                    break;
                case "right":
                    userChoice = Direction.Right;
                    break;
                case "down":
                    userChoice = Direction.Down;
                    break;
                case "left":
                    userChoice = Direction.Left;
                    break;
                default:
                    Console.WriteLine("Wrong direction!\n\n");
                    return board;
            }

            KindOfShip lengthOfShip = KindOfShip.Six;

            Ship ship = new Ship(lengthOfShip, Coords, userChoice);
            int[] coordsToChange;

            for (int i = 0; i < ship.Coords.Count; i++)
            {
                coordsToChange = ship.Coords[i];
                for (int j = 0; j < board.GetLength(j); j++)
                {
                    for (int k = 0; k < board.GetLength(k); k++)
                    {
                        if (coordsToChange[0] == j && coordsToChange[1] == k)
                        {
                            board[j, k] = CellProperty.Occupied;
                        }
                    }
                }
            }

            CounterOfShipsPlaced++;

            if (CounterOfShipsPlaced == 14)
            {
                AllShipsPlaced = true;
            }

            return board;
        }

        
    }
}
