using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWar
{
    class StartGame
    {
        internal void PlaceShips()
        {
            object[,] board = MakeBoard();

            List<int> ships = new List<int>
            {
                2, 2, 3, 3, 4, 4, 6
            };

            string userInput = "";
            while (true)
            {
                Console.WriteLine("Choose starting coordinates:");
                userInput = Console.ReadLine();
                board = PlaceShipsOnBoard(board, ships);
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

        private object[,] PlaceShipsOnBoard(object[,] board, List<int> ships)
        {
            bool allPlaces = false;
            while (allPlaces == false)
            {
                
                if (ships.Count == 0)
                {
                    allPlaces = true;
                }
            }
            return board;
        }
    }
}
