using System;
namespace BetterBattleships
{
    public interface IShootingExecutor
    {
        bool Shoot(CellStatus[,] Board, int[] coords);
        bool PlayerHasDeckCells(CellStatus[,] Board);
    }
}
