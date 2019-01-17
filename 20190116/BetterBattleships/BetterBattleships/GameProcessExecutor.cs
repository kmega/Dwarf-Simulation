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

        public void Shoot(IPlayer vicitim)
        {
            throw new NotImplementedException();
        }
    }
}