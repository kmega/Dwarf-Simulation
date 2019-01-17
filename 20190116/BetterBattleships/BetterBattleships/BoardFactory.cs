using System;

namespace BetterBattleships
{
    public class BoardFactory
    {
        CellStatus[,] playerBoard = new CellStatus[10, 10];

        public CellStatus[,] Create()
        {
            for (int i = 0; i < playerBoard.GetLength(0); i++)
                for (int j = 0; j < playerBoard.GetLength(1); j++)
                    playerBoard[i, j] = CellStatus.EMPTY;

            return playerBoard;
        }
    }
}