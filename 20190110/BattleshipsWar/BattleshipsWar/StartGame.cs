using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWar
{
    class StartGame
    {
        public CellProperty[,] PlayerOneBoard = MakeBoard();
        private bool PlayerOnePlacedAllShips = false;

        public CellProperty[,] PlayerTwoBoard = MakeBoard();
        private bool PlayerTwoPlacedAllShips = false;

        private List<KindOfShip> Ships = new List<KindOfShip>
        {
            
        };

        private int[] Coords = { -1, -1 };

        internal void PlaceShips()
        {
            string placement = "", direction;
            while (PlayerOnePlacedAllShips == false && PlayerTwoPlacedAllShips == false)
            {
                Console.WriteLine("Choose where you want to place a ship:");
                placement = Console.ReadLine();
                Console.WriteLine("Choose ship direction (Up, right, Down, Left):");
                direction = Console.ReadLine();
                Console.Clear();
                if (PlayerOnePlacedAllShips == false)
                {
                    PlayerOneBoard = PlaceShipOnBoard(PlayerOneBoard, placement, direction);
                }
                PlayerTwoBoard = PlaceShipOnBoard(PlayerTwoBoard, placement, direction);
            }
        }

        private static CellProperty[,] MakeBoard()
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

            Ship build = new Ship(KindOfShip.Six, Coords, userChoice);

            if (Ships.Count == 0)
            {
                PlayerOnePlacedAllShips = true;
            }
            return board;
        }
    }
}
