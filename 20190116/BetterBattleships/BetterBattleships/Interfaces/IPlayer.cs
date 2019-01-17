using System.Collections.Generic;

namespace BetterBattleships
{
    public interface IPlayer
    {
        string Name { get; }
        CellStatus[,] GetBoard();
    }
}
