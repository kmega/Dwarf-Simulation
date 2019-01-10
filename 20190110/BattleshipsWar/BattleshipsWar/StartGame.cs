using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWar
{
    class StartGame
    {
        private bool AllPlaced = false;

        private List<int> Ships = new List<int>
        {
            2, 2, 3, 3, 4, 4, 6
        };

        internal void PlaceShips()
        {
            object[,] board = MakeBoard();

            
            string placement = "", direction;
            while (AllPlaced == false)
            {
                Console.WriteLine("Choose where you want to place a ship:");
                placement = Console.ReadLine();
                Console.WriteLine("Choose ship direction:");
                direction = Console.ReadLine();
                board = PlaceShipOnBoard(board, placement, direction);
            }
        }

        private object[,] MakeBoard()
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
            if (Ships.Count == 0)
            {
                AllPlaced = true;
            }
            return board;
        }
    }
}
