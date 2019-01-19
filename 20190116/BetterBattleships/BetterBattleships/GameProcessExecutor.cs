using System;

namespace BetterBattleships
{
    public class GameProcessExecutor : IShootingExecutor
    {
        public bool PlayerHasDeckCells(CellStatus[,] Board)
        {
            bool boardHasDeckCells = false;
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if(Board[i, j] == CellStatus.DECK)
                        boardHasDeckCells = true;
                }
            }
            return boardHasDeckCells;
        }

        public bool Shoot(CellStatus[,] Board, int[] coords, CellStatus[,] TemporaryBoardWithMarkedShoots)
        {
            if (Board[coords[0], coords[1]] == CellStatus.MISS)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Board[coords[0], coords[1]] == CellStatus.HIT)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Board[coords[0], coords[1]] == CellStatus.EMPTY)
            {
                Board[coords[0], coords[1]] = CellStatus.MISS;
                TemporaryBoardWithMarkedShoots[coords[0], coords[1]] = CellStatus.MISS;
                new ConsoleDisplayer().DisplayBoard(TemporaryBoardWithMarkedShoots);
            }

            if (Board[coords[0], coords[1]] == CellStatus.DECK)
            {
                Board[coords[0], coords[1]] = CellStatus.HIT;
                TemporaryBoardWithMarkedShoots[coords[0], coords[1]] = CellStatus.HIT;
                new ConsoleDisplayer().DisplayBoard(TemporaryBoardWithMarkedShoots);
                return true;
            }
            return false;
        }
    }
}