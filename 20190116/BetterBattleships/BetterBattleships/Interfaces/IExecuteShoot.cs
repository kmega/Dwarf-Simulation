using System;
namespace BetterBattleships
{
    public interface IShootingExecutor
    {
        void Shoot(IPlayer vicitim);
        bool PlayerHasDeckCells(CellStatus[,] Board;);
    }
}
