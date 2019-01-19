using System;
namespace BetterBattleships
{
    public interface IShootingExecutor
    {
        bool Shoot(CellStatus[,] Board, int[] coords, CellStatus[,] TemporaryBoardWithMarkedShoots);
        bool PlayerHasDeckCells(CellStatus[,] Board);
    }
}
