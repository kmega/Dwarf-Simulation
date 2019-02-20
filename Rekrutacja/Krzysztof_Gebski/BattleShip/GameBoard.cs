using System;

namespace BattleshipGame
{
    public class GameBoard
    {
        public GameBoard(int boardSize)
        {
            BoardSize = boardSize;
        }

        private int BoardSize { get; set; }

        private string[,] CreateEmptyBoardGame()
        {
            string[,] array = new string[BoardSize, BoardSize];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = "-";
                }
            }
            return array;
        }

        private void FillBoardGameWithPlayerCheckedFields(string[,] array, Player player)
        {
            {
                foreach (var field in player.CheckedFields)
                {
                    var x = field[0] - 65;
                    var y = Convert.ToInt32(field[1]) - 49;
                    array[x, y] = "*";
                }
            }
        }

        private void FillBoardGameWithPlayerDestroyedShips(string[,] array, Player player)
        {
            {
                foreach (var field in player.DestroyedShips)
                {
                    var x = field[0] - 65;
                    var y = Convert.ToInt32(field[1]) - 49;
                    array[x, y] = "X";
                }
            }
        }
    }
}