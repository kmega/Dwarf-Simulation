using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWar
{
    class StartGame
    {
        public object[,] PlayerOneBoard = MakeBoard();
        private bool PlayerOnePlacedAllShips = false;

        public object[,] PlayerTwoBoard = MakeBoard();
        private bool PlayerTwoPlacedAllShips = false;

        private List<int> Ships = new List<int>
        {
            2, 2, 3, 3, 4, 4, 6
        };

        internal void PlaceShips()
        {
            string placement = "", direction;
            while (PlayerOnePlacedAllShips == false && PlayerTwoPlacedAllShips == false)
            {
                Console.WriteLine("Choose where you want to place a ship:");
                placement = Console.ReadLine();
                Console.WriteLine("Choose ship direction:");
                direction = Console.ReadLine();
                if (PlayerOnePlacedAllShips == false)
                {
                    PlayerOneBoard = PlaceShipOnBoard(PlayerOneBoard, placement, direction);
                }
                PlayerTwoBoard = PlaceShipOnBoard(PlayerTwoBoard, placement, direction);
            }
        }

        private static object[,] MakeBoard()
        {
            object[,] Board = new object[10, 10];

            for (int i = 0; i < Board.GetLength(i); i++)
            {
                for (int j = 0; j < Board.GetLength(j); j++)
                {
                    Board[i, j] = CellProperty.Empty;
                }
            }

            return Board;
        }

        private object[,] PlaceShipOnBoard(object[,] board, string placement, string direction)
        {
            InputParser check = new InputParser();
            

            if (Ships.Count == 0)
            {
                PlayerOnePlacedAllShips = true;
            }
            return board;
        }
    }
}
