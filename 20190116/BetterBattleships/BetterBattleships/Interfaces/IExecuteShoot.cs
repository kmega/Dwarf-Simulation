using System;
namespace BetterBattleships
{
    public interface IShootingExecutor
    {
        void Shoot(CellStatus[,] Board, int[] coords);
        bool PlayerHasDeckCells(CellStatus[,] Board);
    }
}
