using System;

namespace BetterBattleships
{
    public class Board : IBoard
    {
        CellStatus[,] playerBoard = new CellStatus[10, 10];

        public CellStatus[,] Create()
        {
            for (int i = 0; i < playerBoard.GetLength(0); i++)
                for (int j = 0; j < playerBoard.GetLength(1); j++)
                    playerBoard[i, j] = SetCellEmptyStatus();

            return playerBoard;
        }

        public CellStatus SetCellEmptyStatus()
        {
            return CellStatus.EMPTY;
        }

        public CellStatus SetCellDeckStatus()
        {
            throw new NotImplementedException();
        }

        public void ExecuteShipPlacement(string direction, int[] startCoords, ShipTypes ship)
        {
            throw new NotImplementedException();
        }
    }
}